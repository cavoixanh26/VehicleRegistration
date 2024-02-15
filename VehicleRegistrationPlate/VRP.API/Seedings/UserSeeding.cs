using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VRP.API.Models.Authentication;

namespace VRP.API.Seedings
{
    public static class UserSeeding 
    {
        public static void UserData(this ModelBuilder builder)
        {
            var roleUserId = new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf");
            var roleAdminId = new Guid("cbc43a8e-f7bb-4445-baaf-1add431ffbbf");
            builder.Entity<AppRole>().HasData(
                new AppRole
                {
                    Id = roleUserId,
                    Name = "User",
                    NormalizedName = "USER",

                },
                new AppRole
                {
                    Id = roleAdminId,
                    Name = "Admin",
                    NormalizedName = "ADMIN",

                }
            );

            var hasher = new PasswordHasher<AppUser>();
            var adminId = new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9");
            var userId1 = Guid.NewGuid();
            var userId = Guid.NewGuid();

            builder.Entity<AppUser>().HasData(
                 new AppUser
                 {
                     Id = adminId,
                     Email = "admin@gmail.com",
                     NormalizedEmail = "ADMIN@GMAIL.COM",
                     UserName = "admin@gmail.com",
                     NormalizedUserName = "ADMIN@GMAIL.COM",
                     PasswordHash = hasher.HashPassword(null, "Abcd@1234"),
                     EmailConfirmed = true,
                     SecurityStamp = Guid.NewGuid().ToString(),
                     PhoneNumber = "0123456789",
                 },
                 new AppUser
                 {
                     Id = userId,
                     Email = "user@gmail.com",
                     NormalizedEmail = "USER@GMAIL.COM",
                     UserName = "user@gmail.com",
                     NormalizedUserName = "USER@GMAIL.COM",
                     PasswordHash = hasher.HashPassword(null, "Abcd@1234"),
                     EmailConfirmed = true,
                     SecurityStamp = Guid.NewGuid().ToString(),
                     PhoneNumber= "1234567890",
                 },
                 new AppUser
                 {
                     Id = userId1,
                     Email = "brett@gmail.com",
                     NormalizedEmail = "BRETT@GMAIL.COM",
                     UserName = "brett@gmail.com",
                     NormalizedUserName = "BRETT@GMAIL.COM",
                     PasswordHash = hasher.HashPassword(null, "Abcd@1234"),
                     EmailConfirmed = true,
                     SecurityStamp = Guid.NewGuid().ToString(),
                     PhoneNumber= "3234567890",
                 }
            );

            builder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = roleAdminId,
                    UserId = adminId
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = roleUserId,
                    UserId = userId
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = roleUserId,
                    UserId = userId1
                }
            );


        }
    }
}
