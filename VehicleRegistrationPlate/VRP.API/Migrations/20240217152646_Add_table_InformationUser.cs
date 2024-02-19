using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VRP.API.Migrations
{
    /// <inheritdoc />
    public partial class Add_table_InformationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("588fc9e2-3697-4da8-8ebb-9d9d7479ccd2") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("a4cfb107-767a-481b-a6cc-d1bf5eed8306") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("588fc9e2-3697-4da8-8ebb-9d9d7479ccd2"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a4cfb107-767a-481b-a6cc-d1bf5eed8306"));

            migrationBuilder.CreateTable(
                name: "InformationUserRequestInProcedures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MidlleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    CommuneId = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcedureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformationUserRequestInProcedures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InformationUserRequestInProcedures_RegistrationProcedures_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "RegistrationProcedures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9ba7d2e-17e2-44e3-bb92-0c466c73d1d8", "AQAAAAIAAYagAAAAEOODnPvT2BtEEkwiEqRrq969AMuhpHdBbh85+uyUDN9JigvXi/8lGVIGg1cB42D8Gw==", "c88e976c-ffe5-40ad-bd2d-ee754814ec10" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CityId", "CommuneId", "ConcurrencyStamp", "DistrictId", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Street", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("63ac9aa9-6cee-45cc-b8c3-cea4dc7c2523"), 0, null, null, "cd93cc2a-8670-42d7-920e-6162b0f0e685", null, "user@gmail.com", true, null, null, false, null, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAENJCFMlYgeHxf0dIzQ2GQu6mV3SmcNeSQb8E0uykRTSJaGu3zViZUB0xSe2Qy941hA==", "1234567890", false, "652223b5-6508-488a-878d-3e803cf40c53", null, false, "user@gmail.com" },
                    { new Guid("c79702ce-16c7-4314-84f1-5ce20a05d6cd"), 0, null, null, "70524723-79ca-4f2b-90de-81ae80d8a7c5", null, "brett@gmail.com", true, null, null, false, null, null, "BRETT@GMAIL.COM", "BRETT@GMAIL.COM", "AQAAAAIAAYagAAAAEES0FSQOa9IikwybWgP/vsQY01r9NRcN9FenEmo2B+7m7u8v1fzguh1Ojz/RhScAvg==", "3234567890", false, "b2f1fc43-4eba-422d-b1de-1e2bbc08615c", null, false, "brett@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 10,
                column: "NumberIdentify",
                value: "X5");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("63ac9aa9-6cee-45cc-b8c3-cea4dc7c2523") },
                    { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("c79702ce-16c7-4314-84f1-5ce20a05d6cd") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InformationUserRequestInProcedures_ProcedureId",
                table: "InformationUserRequestInProcedures",
                column: "ProcedureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InformationUserRequestInProcedures");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("63ac9aa9-6cee-45cc-b8c3-cea4dc7c2523") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("c79702ce-16c7-4314-84f1-5ce20a05d6cd") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("63ac9aa9-6cee-45cc-b8c3-cea4dc7c2523"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c79702ce-16c7-4314-84f1-5ce20a05d6cd"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa3e3c3c-2236-4b46-b394-df1b533f4e3e", "AQAAAAIAAYagAAAAEGEYxwF22BomxtPvByQ6jFfgJPqL8IRBgG4jgxc46R7Tcv92lsHM+F4z870oydWoUw==", "d957e749-c095-496b-9a05-1be948385605" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CityId", "CommuneId", "ConcurrencyStamp", "DistrictId", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Street", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("588fc9e2-3697-4da8-8ebb-9d9d7479ccd2"), 0, null, null, "5acb2a43-aeec-43e4-8738-45ba8c310bd1", null, "user@gmail.com", true, null, null, false, null, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAEEkW/Zr6WOAvgnwxdAATx/5sVrHTw2+SG9lxcnUX3dHGqNSfwRSgHrj00UCBoIBOnQ==", "1234567890", false, "eee59466-9f73-4983-beea-b61c0dc21fc6", null, false, "user@gmail.com" },
                    { new Guid("a4cfb107-767a-481b-a6cc-d1bf5eed8306"), 0, null, null, "a9b7e51d-8830-4b5e-b6e0-cee5646c36f2", null, "brett@gmail.com", true, null, null, false, null, null, "BRETT@GMAIL.COM", "BRETT@GMAIL.COM", "AQAAAAIAAYagAAAAEMWg15Yv/UjwTY78swObF0SYulvpMcI6uXtboVc0h+GWbdw1ePPahDeS9jDTttLvSg==", "3234567890", false, "38c52e1b-57a8-4d19-b371-5923ca22b78e", null, false, "brett@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 10,
                column: "NumberIdentify",
                value: "Hoài Đức");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("588fc9e2-3697-4da8-8ebb-9d9d7479ccd2") },
                    { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("a4cfb107-767a-481b-a6cc-d1bf5eed8306") }
                });
        }
    }
}
