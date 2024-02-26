using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VRP.API.Migrations
{
    /// <inheritdoc />
    public partial class CitizenInProcess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<int>(
                name: "TypeOfRegistration",
                table: "RegistrationProcedures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusProcudure",
                table: "RegistrationProcedures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CitizenIdentificationRequestInProcedures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CitizenId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssuanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssuanceLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcedureId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitizenIdentificationRequestInProcedures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CitizenIdentificationRequestInProcedures_RegistrationProcedures_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "RegistrationProcedures",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f18c5783-a0df-4dbf-ba0b-5275db18fc98", "AQAAAAIAAYagAAAAECDd4g88Xtaa3QqE0Ayfzbdp2pwyk3IqRndRkrWncjG+8VJbWR81kaLNq7ujS2QRQg==", "f3b6323b-eadc-45e4-a27f-dd6bccb648ac" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CityId", "CommuneId", "ConcurrencyStamp", "DistrictId", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Street", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("66127fc8-3167-403e-8f39-7880aed4ff33"), 0, null, null, "96816548-01ea-46be-ac5e-419cf9cfc73a", null, "brett@gmail.com", true, null, null, false, null, null, "BRETT@GMAIL.COM", "BRETT@GMAIL.COM", "AQAAAAIAAYagAAAAEOQMYBzBj7icZ5JeLfLIIH+U273xBaPYqixSHz4UpUEcH7iR9y6WPQCIrMIRaW/Dbg==", "3234567890", false, "fe2cb75f-861a-4ac3-8106-191b947eeb7d", null, false, "brett@gmail.com" },
                    { new Guid("facf3bae-f611-476a-914f-7bbcfd0c3d2d"), 0, null, null, "87dce894-0220-4214-a12c-7d4b25a88aab", null, "user@gmail.com", true, null, null, false, null, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAENHTBcwYiYQJVTdGwt6xXUTKSzLZolubNVmXeWjJarhDaS4/r7Ftdbl2c/Gyg9NaPA==", "1234567890", false, "753aaea6-ac97-477e-b2cc-b5886326b6c4", null, false, "user@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("66127fc8-3167-403e-8f39-7880aed4ff33") },
                    { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("facf3bae-f611-476a-914f-7bbcfd0c3d2d") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InformationUserRequestInProcedures_CityId",
                table: "InformationUserRequestInProcedures",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_InformationUserRequestInProcedures_CommuneId",
                table: "InformationUserRequestInProcedures",
                column: "CommuneId");

            migrationBuilder.CreateIndex(
                name: "IX_InformationUserRequestInProcedures_DistrictId",
                table: "InformationUserRequestInProcedures",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_CitizenIdentificationRequestInProcedures_ProcedureId",
                table: "CitizenIdentificationRequestInProcedures",
                column: "ProcedureId");

            migrationBuilder.AddForeignKey(
                name: "FK_InformationUserRequestInProcedures_Cities_CityId",
                table: "InformationUserRequestInProcedures",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InformationUserRequestInProcedures_Communes_CommuneId",
                table: "InformationUserRequestInProcedures",
                column: "CommuneId",
                principalTable: "Communes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InformationUserRequestInProcedures_Districts_DistrictId",
                table: "InformationUserRequestInProcedures",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InformationUserRequestInProcedures_Cities_CityId",
                table: "InformationUserRequestInProcedures");

            migrationBuilder.DropForeignKey(
                name: "FK_InformationUserRequestInProcedures_Communes_CommuneId",
                table: "InformationUserRequestInProcedures");

            migrationBuilder.DropForeignKey(
                name: "FK_InformationUserRequestInProcedures_Districts_DistrictId",
                table: "InformationUserRequestInProcedures");

            migrationBuilder.DropTable(
                name: "CitizenIdentificationRequestInProcedures");

            migrationBuilder.DropIndex(
                name: "IX_InformationUserRequestInProcedures_CityId",
                table: "InformationUserRequestInProcedures");

            migrationBuilder.DropIndex(
                name: "IX_InformationUserRequestInProcedures_CommuneId",
                table: "InformationUserRequestInProcedures");

            migrationBuilder.DropIndex(
                name: "IX_InformationUserRequestInProcedures_DistrictId",
                table: "InformationUserRequestInProcedures");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("66127fc8-3167-403e-8f39-7880aed4ff33") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("facf3bae-f611-476a-914f-7bbcfd0c3d2d") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("66127fc8-3167-403e-8f39-7880aed4ff33"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("facf3bae-f611-476a-914f-7bbcfd0c3d2d"));

            migrationBuilder.AlterColumn<int>(
                name: "TypeOfRegistration",
                table: "RegistrationProcedures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StatusProcudure",
                table: "RegistrationProcedures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("63ac9aa9-6cee-45cc-b8c3-cea4dc7c2523") },
                    { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("c79702ce-16c7-4314-84f1-5ce20a05d6cd") }
                });
        }
    }
}
