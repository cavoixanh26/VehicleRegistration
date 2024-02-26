﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using VRP.API.Extensions;
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

        public async Task<RequestedProcedure> GetUserInformationProcedureById(int procedureId)
        {
            var procedure = await context.RegistrationProcedures.FirstOrDefaultAsync(x => x.Id == procedureId);
            var procedureResponse = mapper.Map<RequestedProcedure>(procedure);
            if (procedureResponse == null)
                throw HttpException.NotFoundException("Not Found Procedure");

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

            procedureResponse.UserInformationProcedure = userInformationResponse;

            return procedureResponse;
        }

        public async Task<ProcedureResponse> GetProcedures(ProcedureRequest request)
        {
            var procedures = context.RegistrationProcedures
                .Where(x => string.IsNullOrEmpty(request.KeyWords)
                         || x.User.Email.Contains(request.KeyWords)
                         || x.User.PhoneNumber.Equals(request.KeyWords)
                         && (!request.TypeOfRegistration.HasValue || (int)x.TypeOfRegistration == request.StatusProcedure)
                         && (!request.StatusProcedure.HasValue || (int)x.StatusProcudure == request.StatusProcedure))
                .Include(x => x.User);

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
    }
}
