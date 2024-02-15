using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VRP.API.Migrations
{
    /// <inheritdoc />
    public partial class Seed_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), null, "User", "USER" },
                    { new Guid("cbc43a8e-f7bb-4445-baaf-1add431ffbbf"), null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CityId", "CommuneId", "ConcurrencyStamp", "DistrictId", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Street", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("588fc9e2-3697-4da8-8ebb-9d9d7479ccd2"), 0, null, null, "5acb2a43-aeec-43e4-8738-45ba8c310bd1", null, "user@gmail.com", true, null, null, false, null, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAEEkW/Zr6WOAvgnwxdAATx/5sVrHTw2+SG9lxcnUX3dHGqNSfwRSgHrj00UCBoIBOnQ==", "1234567890", false, "eee59466-9f73-4983-beea-b61c0dc21fc6", null, false, "user@gmail.com" },
                    { new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), 0, null, null, "fa3e3c3c-2236-4b46-b394-df1b533f4e3e", null, "admin@gmail.com", true, null, null, false, null, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEGEYxwF22BomxtPvByQ6jFfgJPqL8IRBgG4jgxc46R7Tcv92lsHM+F4z870oydWoUw==", "0123456789", false, "d957e749-c095-496b-9a05-1be948385605", null, false, "admin@gmail.com" },
                    { new Guid("a4cfb107-767a-481b-a6cc-d1bf5eed8306"), 0, null, null, "a9b7e51d-8830-4b5e-b6e0-cee5646c36f2", null, "brett@gmail.com", true, null, null, false, null, null, "BRETT@GMAIL.COM", "BRETT@GMAIL.COM", "AQAAAAIAAYagAAAAEMWg15Yv/UjwTY78swObF0SYulvpMcI6uXtboVc0h+GWbdw1ePPahDeS9jDTttLvSg==", "3234567890", false, "38c52e1b-57a8-4d19-b371-5923ca22b78e", null, false, "brett@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "NumberIdentify" },
                values: new object[,]
                {
                    { 1, "Hà Nội", "29" },
                    { 2, "Hải Dương", "34" },
                    { 3, "Hải Phòng", "15" },
                    { 4, "Hưng Yên", "89" },
                    { 5, "Nam Định", "18" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("588fc9e2-3697-4da8-8ebb-9d9d7479ccd2") },
                    { new Guid("cbc43a8e-f7bb-4445-baaf-1add431ffbbf"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9") },
                    { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("a4cfb107-767a-481b-a6cc-d1bf5eed8306") }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "CityId", "Name", "NumberIdentify" },
                values: new object[,]
                {
                    { 1, 1, "Quận Ba Đình", "B1" },
                    { 2, 1, "Quận Hoàn Kiếm", "C1" },
                    { 3, 1, "Quận Hai Bà Trưng", "D1" },
                    { 4, 1, "Quận Tây Hồ", "F1" },
                    { 5, 1, "Quận Cầu Giấy", "P1" },
                    { 6, 1, "Quận Hà Đông", "T1" },
                    { 7, 1, "Huyện Gia Lâm", "N1" },
                    { 8, 1, "Huyện Đông Anh", "S1" },
                    { 9, 1, "Huyện Thạch Thất", "V5" },
                    { 10, 1, "Huyện Hoài Đức", "Hoài Đức" }
                });

            migrationBuilder.InsertData(
                table: "Communes",
                columns: new[] { "Id", "DistrictId", "Name", "NumberIdentify" },
                values: new object[,]
                {
                    { 1, 10, "Thị trấn Trạm Trôi", "" },
                    { 2, 10, "Xã An Khánh", "" },
                    { 3, 10, "Xã Lại Yên", "" },
                    { 4, 1, "Phường Vĩnh Phúc", "" },
                    { 5, 1, "Phường Trúc Bạch", "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("588fc9e2-3697-4da8-8ebb-9d9d7479ccd2") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cbc43a8e-f7bb-4445-baaf-1add431ffbbf"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("a4cfb107-767a-481b-a6cc-d1bf5eed8306") });

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Communes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Communes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Communes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Communes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Communes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cbc43a8e-f7bb-4445-baaf-1add431ffbbf"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("588fc9e2-3697-4da8-8ebb-9d9d7479ccd2"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a4cfb107-767a-481b-a6cc-d1bf5eed8306"));

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
