using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VRP.API.Models.Authentication;
using Microsoft.AspNetCore.Identity;
using VRP.API.Models.Address;
using VRP.API.Models.InformationUser;
using VRP.API.Models.Procedure;
using VRP.API.Models.Vehicle;
using VRP.API.Seedings;

namespace VRP.API.Models
{
    public class ApplicationDbcontext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options): base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Commune> Communes { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<CitizenIdentifycation> CitizenIdentifycations { get; set; }
        public DbSet<RegistrationProcedure> RegistrationProcedures { get; set; }
        public DbSet<TypeOfVehicle> TypeOfVehicles { get; set; }
        public DbSet<VehicleRegistration> VehicleRegistrations { get; set; }
        public DbSet<InformationUserRequestInProcedure> InformationUserRequestInProcedures { get; set; }
        public DbSet<CitizenIdentificationRequestInProcedure> CitizenIdentificationRequestInProcedures{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.LocationData();
            builder.UserData();
        }
    }
}
