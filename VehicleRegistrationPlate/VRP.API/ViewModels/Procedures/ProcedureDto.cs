﻿using VRP.API.Models.Procedure;

namespace VRP.API.ViewModels.Procedures
{
    public class ProcedureDto
    {
        public int Id { get; set; }
        public int? VehicleId { get; set; }
        public Guid? UserId { get; set; }
        public string? UserName { get; set; }
        public int TypeOfRegistration { get; set; }
        public string TypeOfRegistrationName 
        { 
            get 
            {
                return Enum.GetName(typeof(TypeOfRegistrationLicencePlateEnum), TypeOfRegistration);
            }
            set { } 
        }
        public int StatusProcudure { get; set; }
    }
}
