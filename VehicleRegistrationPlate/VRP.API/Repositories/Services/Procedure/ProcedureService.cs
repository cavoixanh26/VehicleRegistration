using AutoMapper;
using Microsoft.Identity.Client;
using VRP.API.HandlingExceptions;
using VRP.API.Models;
using VRP.API.Models.InformationUser;
using VRP.API.Models.Procedure;
using VRP.API.Repositories.IServices.Locations;
using VRP.API.Repositories.IServices.Procedures;
using VRP.API.ViewModels.Procedures;

namespace VRP.API.Repositories.Services.Procedure
{
    public class ProcedureService : IProcedureService
    {
        private readonly ApplicationDbcontext context;
        private readonly IMapper mapper;
        private readonly ICommuneService communeService;
        private readonly IDistrictService districtService;
        private readonly ICityService cityService;

        public ProcedureService(
            ApplicationDbcontext context,
            IMapper mapper,
            ICommuneService communeService,
            IDistrictService districtService,
            ICityService cityService)
        {
            this.context = context;
            this.mapper = mapper;
            this.communeService = communeService;
            this.districtService = districtService;
            this.cityService = cityService;
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
                    var citizenIdentity = mapper.Map<CitizenIdentifycation>(request.CitizenIdentification);
                    await context.CitizenIdentifycations.AddAsync(citizenIdentity);

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

        private async Task CheckExistedLocation(int communeId, int districtId, int cityId)
        {
            await communeService.GetCommuneById(communeId);
            await districtService.GetDistrictById(districtId);
            await cityService.GetCityById(cityId);
        }
    }
}
