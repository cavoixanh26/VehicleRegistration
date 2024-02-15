﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VRP.API.Models;

#nullable disable

namespace VRP.API.Migrations
{
    [DbContext(typeof(ApplicationDbcontext))]
    [Migration("20240215092509_Seed_data")]
    partial class Seed_data
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                            RoleId = new Guid("cbc43a8e-f7bb-4445-baaf-1add431ffbbf")
                        },
                        new
                        {
                            UserId = new Guid("588fc9e2-3697-4da8-8ebb-9d9d7479ccd2"),
                            RoleId = new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf")
                        },
                        new
                        {
                            UserId = new Guid("a4cfb107-767a-481b-a6cc-d1bf5eed8306"),
                            RoleId = new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("VRP.API.Models.Address.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberIdentify")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Hà Nội",
                            NumberIdentify = "29"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Hải Dương",
                            NumberIdentify = "34"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Hải Phòng",
                            NumberIdentify = "15"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Hưng Yên",
                            NumberIdentify = "89"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Nam Định",
                            NumberIdentify = "18"
                        });
                });

            modelBuilder.Entity("VRP.API.Models.Address.Commune", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DistrictId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberIdentify")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.ToTable("Communes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DistrictId = 10,
                            Name = "Thị trấn Trạm Trôi",
                            NumberIdentify = ""
                        },
                        new
                        {
                            Id = 2,
                            DistrictId = 10,
                            Name = "Xã An Khánh",
                            NumberIdentify = ""
                        },
                        new
                        {
                            Id = 3,
                            DistrictId = 10,
                            Name = "Xã Lại Yên",
                            NumberIdentify = ""
                        },
                        new
                        {
                            Id = 4,
                            DistrictId = 1,
                            Name = "Phường Vĩnh Phúc",
                            NumberIdentify = ""
                        },
                        new
                        {
                            Id = 5,
                            DistrictId = 1,
                            Name = "Phường Trúc Bạch",
                            NumberIdentify = ""
                        });
                });

            modelBuilder.Entity("VRP.API.Models.Address.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberIdentify")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Districts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            Name = "Quận Ba Đình",
                            NumberIdentify = "B1"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            Name = "Quận Hoàn Kiếm",
                            NumberIdentify = "C1"
                        },
                        new
                        {
                            Id = 3,
                            CityId = 1,
                            Name = "Quận Hai Bà Trưng",
                            NumberIdentify = "D1"
                        },
                        new
                        {
                            Id = 4,
                            CityId = 1,
                            Name = "Quận Tây Hồ",
                            NumberIdentify = "F1"
                        },
                        new
                        {
                            Id = 5,
                            CityId = 1,
                            Name = "Quận Cầu Giấy",
                            NumberIdentify = "P1"
                        },
                        new
                        {
                            Id = 6,
                            CityId = 1,
                            Name = "Quận Hà Đông",
                            NumberIdentify = "T1"
                        },
                        new
                        {
                            Id = 7,
                            CityId = 1,
                            Name = "Huyện Gia Lâm",
                            NumberIdentify = "N1"
                        },
                        new
                        {
                            Id = 8,
                            CityId = 1,
                            Name = "Huyện Đông Anh",
                            NumberIdentify = "S1"
                        },
                        new
                        {
                            Id = 9,
                            CityId = 1,
                            Name = "Huyện Thạch Thất",
                            NumberIdentify = "V5"
                        },
                        new
                        {
                            Id = 10,
                            CityId = 1,
                            Name = "Huyện Hoài Đức",
                            NumberIdentify = "Hoài Đức"
                        });
                });

            modelBuilder.Entity("VRP.API.Models.Authentication.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"),
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = new Guid("cbc43a8e-f7bb-4445-baaf-1add431ffbbf"),
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("VRP.API.Models.Authentication.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<int?>("CommuneId")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DistrictId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CommuneId");

                    b.HasIndex("DistrictId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "fa3e3c3c-2236-4b46-b394-df1b533f4e3e",
                            Email = "admin@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEGEYxwF22BomxtPvByQ6jFfgJPqL8IRBgG4jgxc46R7Tcv92lsHM+F4z870oydWoUw==",
                            PhoneNumber = "0123456789",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d957e749-c095-496b-9a05-1be948385605",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        },
                        new
                        {
                            Id = new Guid("588fc9e2-3697-4da8-8ebb-9d9d7479ccd2"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5acb2a43-aeec-43e4-8738-45ba8c310bd1",
                            Email = "user@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@GMAIL.COM",
                            NormalizedUserName = "USER@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEEkW/Zr6WOAvgnwxdAATx/5sVrHTw2+SG9lxcnUX3dHGqNSfwRSgHrj00UCBoIBOnQ==",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "eee59466-9f73-4983-beea-b61c0dc21fc6",
                            TwoFactorEnabled = false,
                            UserName = "user@gmail.com"
                        },
                        new
                        {
                            Id = new Guid("a4cfb107-767a-481b-a6cc-d1bf5eed8306"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a9b7e51d-8830-4b5e-b6e0-cee5646c36f2",
                            Email = "brett@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "BRETT@GMAIL.COM",
                            NormalizedUserName = "BRETT@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEMWg15Yv/UjwTY78swObF0SYulvpMcI6uXtboVc0h+GWbdw1ePPahDeS9jDTttLvSg==",
                            PhoneNumber = "3234567890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "38c52e1b-57a8-4d19-b371-5923ca22b78e",
                            TwoFactorEnabled = false,
                            UserName = "brett@gmail.com"
                        });
                });

            modelBuilder.Entity("VRP.API.Models.InformationUser.CitizenIdentifycation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CitizenId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("IssuanceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IssuanceLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("CitizenIdentifycations");
                });

            modelBuilder.Entity("VRP.API.Models.Procedure.RegistrationProcedure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("StatusProcudure")
                        .HasColumnType("int");

                    b.Property<int?>("TypeOfRegistration")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VehicleId");

                    b.ToTable("RegistrationProcedures");
                });

            modelBuilder.Entity("VRP.API.Models.Vehicle.TypeOfVehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeOfVehicles");
                });

            modelBuilder.Entity("VRP.API.Models.Vehicle.VehicleRegistration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CarBrand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClassisN0")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EngineN0")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicencePlate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TypeOfVehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeOfVehicleId");

                    b.ToTable("VehicleRegistrations");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("VRP.API.Models.Authentication.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("VRP.API.Models.Authentication.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("VRP.API.Models.Authentication.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("VRP.API.Models.Authentication.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VRP.API.Models.Authentication.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("VRP.API.Models.Authentication.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VRP.API.Models.Address.Commune", b =>
                {
                    b.HasOne("VRP.API.Models.Address.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictId");

                    b.Navigation("District");
                });

            modelBuilder.Entity("VRP.API.Models.Address.District", b =>
                {
                    b.HasOne("VRP.API.Models.Address.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.Navigation("City");
                });

            modelBuilder.Entity("VRP.API.Models.Authentication.AppUser", b =>
                {
                    b.HasOne("VRP.API.Models.Address.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("VRP.API.Models.Address.Commune", "Commune")
                        .WithMany()
                        .HasForeignKey("CommuneId");

                    b.HasOne("VRP.API.Models.Address.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictId");

                    b.Navigation("City");

                    b.Navigation("Commune");

                    b.Navigation("District");
                });

            modelBuilder.Entity("VRP.API.Models.InformationUser.CitizenIdentifycation", b =>
                {
                    b.HasOne("VRP.API.Models.Authentication.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("VRP.API.Models.Procedure.RegistrationProcedure", b =>
                {
                    b.HasOne("VRP.API.Models.Authentication.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("VRP.API.Models.Vehicle.VehicleRegistration", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId");

                    b.Navigation("User");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("VRP.API.Models.Vehicle.VehicleRegistration", b =>
                {
                    b.HasOne("VRP.API.Models.Vehicle.TypeOfVehicle", "TypeOfVehicle")
                        .WithMany()
                        .HasForeignKey("TypeOfVehicleId");

                    b.Navigation("TypeOfVehicle");
                });
#pragma warning restore 612, 618
        }
    }
}
