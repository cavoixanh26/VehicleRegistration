using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using VRP.API.Extensions;
using VRP.API.HandlingExceptions;
using VRP.API.Models;
using VRP.API.Models.Authentication;
using VRP.API.Models.InformationUser;
using VRP.API.Models.Procedure;
using VRP.API.Models.Vehicle;
using VRP.API.Repositories.IServices.Locations;
using VRP.API.Repositories.IServices.Procedures;
using VRP.API.Repositories.IServices.Vehicles;
using VRP.API.ViewModels.Procedures;
using VRP.API.ViewModels.Procedures.HanldeRequest;
using VRP.API.ViewModels.Procedures.NumberRotatorLicensePlate;
using VRP.API.ViewModels.Procedures.VehicleInformationProcedures;

namespace VRP.API.Repositories.Services.Procedure
{
    public class ProcedureService : IProcedureService
    {
        private readonly ApplicationDbcontext context;
        private readonly IMapper mapper;
        private readonly ICommuneService communeService;
        private readonly IDistrictService districtService;
        private readonly ICityService cityService;
        private readonly UserManager<AppUser> userManager;
        private readonly ITypeOfVehicleService typeOfVehicleService;

        public ProcedureService(
            ApplicationDbcontext context,
            IMapper mapper,
            ICommuneService communeService,
            IDistrictService districtService,
            ICityService cityService,
            UserManager<AppUser> userManager,
            ITypeOfVehicleService typeOfVehicleService)
        {
            this.context = context;
            this.mapper = mapper;
            this.communeService = communeService;
            this.districtService = districtService;
            this.cityService = cityService;
            this.userManager = userManager;
            this.typeOfVehicleService = typeOfVehicleService;
        }
        public async Task<CarLicensePlateResponse> CreateCarLicensePlate(CarLicensePlateRequest request, Guid userId)
        {
            using (var transation = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    var procedure = new RegistrationProcedure
                    {
                        UserId = userId,
                    };
                    await context.RegistrationProcedures.AddAsync(procedure);
                    await context.SaveChangesAsync();

                    // check exist location
                    await CheckExistedLocation(
                        request.InformationUser.CommuneId,
                        request.InformationUser.DistrictId,
                        request.InformationUser.CityId);

                    var informationUser = mapper.Map<InformationUserRequestInProcedure>(request.InformationUser);
                    informationUser.ProcedureId = procedure.Id;
                    await context.InformationUserRequestInProcedures.AddAsync(informationUser);
                    var citizenIdentity = mapper.Map<CitizenIdentificationRequestInProcedure>(request.CitizenIdentification);
                    citizenIdentity.ProcedureId = procedure.Id;
                    await context.CitizenIdentificationRequestInProcedures.AddAsync(citizenIdentity);

                    await context.SaveChangesAsync();
                    await transation.CommitAsync();
                    return new CarLicensePlateResponse
                    {
                        Status = "Send Request success"
                    };
                }
                catch (HttpException ex)
                {
                    await transation.RollbackAsync();
                    throw HttpException.BadRequestException(ex.Message);
                }
            }
        }

        public async Task<RequestedProcedure> GetUserInformationProcedureById(int procedureId, AppUser currentUser)
        {
            var procedure = await context.RegistrationProcedures
                .FirstOrDefaultAsync(x => x.Id == procedureId);
            if (procedure == null)
                throw HttpException.NotFoundException("Not found procedure");

            var procedureResponse = mapper.Map<RequestedProcedure>(procedure);
            if (procedureResponse == null)
                throw HttpException.NotFoundException("Not Found Procedure");

            var userInformationResponse = await GetUserInformationInProcedure(procedureId);

            procedureResponse.UserInformationProcedure = userInformationResponse;

            if (procedure.VehicleId.HasValue)
            {
                var vehicleInProcedure = await context.VehicleRegistrations
                    .Include(x => x.TypeOfVehicle)
                    .FirstOrDefaultAsync(x => x.Id == procedure.VehicleId);
                var vehicleInformation = mapper.Map<VehicleInformationProcedure>(vehicleInProcedure);
                procedureResponse.VehicleInformationProcedure = vehicleInformation;
            }

            return procedureResponse;
        }

        private async Task<UserInformationProcedure> GetUserInformationInProcedure(int procedureId)
        {
            var informationUserInProcedure = await context.InformationUserRequestInProcedures
               .Include(x => x.Procedure)
               .Include(x => x.City)
               .Include(x => x.District)
               .Include(x => x.Commune)
               .FirstOrDefaultAsync(x => x.ProcedureId == procedureId);
            if (informationUserInProcedure == null)
                throw HttpException.NotFoundException("Not Found procedure");

            var citizenIdentifycationOfUser = await context.CitizenIdentificationRequestInProcedures
                .Include(x => x.Procedure)
                .FirstOrDefaultAsync(x => x.ProcedureId == procedureId);
            if (citizenIdentifycationOfUser == null)
                throw HttpException.NotFoundException("Not Found citizen");

            var userInformationResponse = mapper.Map<UserInformationProcedure>(informationUserInProcedure);
            userInformationResponse.CitizenId = citizenIdentifycationOfUser.CitizenId;
            userInformationResponse.CitizenIssuanceDate = citizenIdentifycationOfUser.IssuanceDate;
            userInformationResponse.CitizenIssuanceLocation = citizenIdentifycationOfUser.IssuanceLocation;

            return userInformationResponse;
        }


        public async Task<ProcedureResponse> GetProcedures(
            ProcedureRequest request,
            AppUser currentUser)
        {
            if (currentUser == null)
                throw HttpException.NoPermissionException("");

            var procedures = context.RegistrationProcedures
                .Where(x => string.IsNullOrEmpty(request.KeyWords)
                         || x.User.Email.Contains(request.KeyWords)
                         || x.User.PhoneNumber.Equals(request.KeyWords)
                         && (!request.TypeOfRegistration.HasValue
                                || (int)x.TypeOfRegistration == request.StatusProcedure)
                         && (!request.StatusProcedure.HasValue
                                || (int)x.StatusProcudure == request.StatusProcedure))
                .Include(x => x.User);

            if (await userManager.IsInRoleAsync(currentUser, "User"))
            {
                procedures = procedures
                    .Where(x => x.UserId == currentUser.Id)
                    .Include(x => x.User);
            }

            var procedureDtos = mapper.Map<List<ProcedureDto>>
                (procedures.Paginate(request).OrderByDescending(x => x.Id));

            return new ProcedureResponse
            {
                Procedures = procedureDtos,
                Page = request.GetPagingResponse(procedures.Count())
            };
        }

        private async Task CheckExistedLocation(int communeId, int districtId, int cityId)
        {
            await communeService.GetCommuneById(communeId);
            await districtService.GetDistrictById(districtId);
            await cityService.GetCityById(cityId);
        }

        public async Task<ProcedureDto> ApproveRequestedProcedure(ApproveRequestedProcedure request)
        {
            var procedure = await GetProcedureInProcess(request.ProcedureId, StatusProcudureEnum.VerifyInformationOfRequester, StatusProcudureEnum.VerifyVehicle);

            // up positive of enum
            procedure.StatusProcudure += 1;
            context.Entry(procedure).State = EntityState.Modified;
            await context.SaveChangesAsync();
            var response = mapper.Map<ProcedureDto>(procedure);
            return response;
        }

        public async Task<ProcedureDto> RejectRequestProcedure(RejectRequestedProcedure request)
        {
            var procedure = await GetProcedureInProcess(request.ProcedureId, StatusProcudureEnum.VerifyInformationOfRequester, StatusProcudureEnum.VerifyVehicle);

            // up positive of enum
            procedure.StatusProcudure += 2;
            context.Entry(procedure).State = EntityState.Modified;
            await context.SaveChangesAsync();
            var response = mapper.Map<ProcedureDto>(procedure);
            return response;
        }

        // get procedure and check satified status
        private async Task<RegistrationProcedure> GetProcedureInProcess(int procedureId, params StatusProcudureEnum[] statusProcudure)
        {
            var procedure = await context.RegistrationProcedures
                .FirstOrDefaultAsync(x => x.Id == procedureId);
            if (procedure == null)
                throw HttpException.NotFoundException("Not found procedure");

            if (!statusProcudure.Contains(procedure.StatusProcudure))
            {
                throw HttpException.BadRequestException("Can't handle this requested procedure");
            }

            return procedure;
        }

        public async Task<RequestedProcedure> UpdateVehicleInformation(int procedureId, VehicleRequest request, AppUser currentUser)
        {

            var procedure = await GetProcedureInProcess(procedureId, StatusProcudureEnum.ApprovalInformationOfRequester);

            if (currentUser.Id != procedure.UserId)
            {
                throw HttpException.NoPermissionException("Can't access processing");
            }

            var vehicle = typeOfVehicleService.GetTypeVehicleDetail(request.TypeOfVehicleId);
            if (vehicle == null)
            {
                throw HttpException.NotFoundException("Not found vehicle");
            }

            using (var transation = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    var registerVehicle = mapper.Map<VehicleRegistration>(request);
                    await context.VehicleRegistrations.AddAsync(registerVehicle);
                    await context.SaveChangesAsync();
                    var vehicleInformation = mapper.Map<VehicleInformationProcedure>(registerVehicle);
                    vehicleInformation.TypeOfVehicle = vehicle.Name;

                    procedure.VehicleId = registerVehicle.Id;
                    procedure.StatusProcudure = StatusProcudureEnum.VerifyVehicle;
                    context.RegistrationProcedures.Update(procedure);
                    await context.SaveChangesAsync();
                    await transation.CommitAsync();

                    var response = mapper.Map<RequestedProcedure>(procedure);
                    response.VehicleInformationProcedure = vehicleInformation;
                    response.UserInformationProcedure = await GetUserInformationInProcedure(procedureId);

                    return response;
                }
                catch (Exception ex)
                {
                    await transation.RollbackAsync();
                    throw HttpException.BadRequestException("Handle fail");
                }
            }
        }

        public async Task<InformationLicensePlate> GetInformationUserInRotatorProcess(int procedureId, AppUser currentUser)
        {
            var procedure = await GetProcedureInProcess(procedureId, StatusProcudureEnum.ApprovalVehicle);
            if (procedure.UserId != currentUser.Id)
                throw HttpException.NoPermissionException("You cann't access");

            var informationUserInProcedure = await context.InformationUserRequestInProcedures
                .Include(x => x.City)
                .Include(x => x.District)
                .FirstOrDefaultAsync(x => x.ProcedureId == procedureId);

            var informationLicensePlate = mapper.Map<InformationLicensePlate>(informationUserInProcedure);
            informationLicensePlate.ProcedureId = procedureId;
            informationLicensePlate.StatusProcudure = procedure.StatusProcudure;

            return informationLicensePlate;
        }

        public async Task<VehicleInformationProcedure> UpdateNumberLicensePlate(UpdateNumberLicensePlateRequest request, AppUser? currentUser)
        {
            using (var transition = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    var procedure = await GetProcedureInProcess(request.ProcedureId, StatusProcudureEnum.ApprovalVehicle);
                    if (procedure.UserId != currentUser.Id)
                        throw HttpException.NoPermissionException("You cann't access");

                    var vehicle = await context.VehicleRegistrations.FirstOrDefaultAsync(x => x.Id == procedure.VehicleId);
                    if (vehicle == null)
                    {
                        throw HttpException.NotFoundException("Not Found vehicle");
                    }

                    vehicle.LicencePlate = request.NumberLicensePlate;
                    procedure.StatusProcudure = StatusProcudureEnum.RotatedNumberLicensePlate;

                    context.Entry(procedure).State = EntityState.Modified;
                    context.Entry(vehicle).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                    await transition.CommitAsync();
                    var vehicleInformation = mapper.Map<VehicleInformationProcedure>(vehicle);
                    return vehicleInformation;
                }
                catch (HttpException ex)
                {
                    await transition.RollbackAsync();
                    throw HttpException.BadRequestException("Error");
                }
            }
        }

        public async Task CancelProcedure(int procedureId, AppUser currentUser)
        {
            var listStatusProcedure = new StatusProcudureEnum[]
            {
                StatusProcudureEnum.VerifyInformationOfRequester,
                StatusProcudureEnum.ApprovalInformationOfRequester,
                StatusProcudureEnum.VerifyVehicle
            };

            var procedure = await GetProcedureInProcess(procedureId, listStatusProcedure);

            if (procedure == null)
                throw HttpException.BadRequestException("Can't cancel procedure");

            if (procedure.UserId != currentUser.Id)
                throw HttpException.NoPermissionException("Can't access function");

            procedure.StatusProcudure = StatusProcudureEnum.CancelProcedure;
            context.Entry(procedure).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
