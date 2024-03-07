using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudVOffice.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeliveryAgentSalesExecutive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryPartners",
                columns: table => new
                {
                    DeliveryPartnerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoadCapacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChassisNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationYear = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VehicleNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PollutionCertificate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Insurance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mileage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleFrontPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleBackPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryPartners", x => x.DeliveryPartnerId);
                });

            migrationBuilder.CreateTable(
                name: "SalesExecutiveRegistrations",
                columns: table => new
                {
                    SalesExecutiveRegistrationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesExecutiveName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PANCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AadharCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesExecutiveUniqueNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WareHuoseId = table.Column<long>(type: "bigint", nullable: true),
                    PrimaryPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlternatePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesExecutiveRegistrations", x => x.SalesExecutiveRegistrationId);
                });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 11, 23, 51, 993, DateTimeKind.Local).AddTicks(1968));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 11, 23, 51, 993, DateTimeKind.Local).AddTicks(1971));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 11, 23, 51, 993, DateTimeKind.Local).AddTicks(1973));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 11, 23, 51, 993, DateTimeKind.Local).AddTicks(1975));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 11, 23, 51, 993, DateTimeKind.Local).AddTicks(1976));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 11, 23, 51, 993, DateTimeKind.Local).AddTicks(1978));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 11, 23, 51, 993, DateTimeKind.Local).AddTicks(1980));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 11, 23, 51, 993, DateTimeKind.Local).AddTicks(3066));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 11, 23, 51, 993, DateTimeKind.Local).AddTicks(3082));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 11, 23, 51, 993, DateTimeKind.Local).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 11, 23, 51, 993, DateTimeKind.Local).AddTicks(2417));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 11, 23, 51, 993, DateTimeKind.Local).AddTicks(2418));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 11, 23, 51, 993, DateTimeKind.Local).AddTicks(2419));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 11, 23, 51, 993, DateTimeKind.Local).AddTicks(2495));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 11, 23, 51, 993, DateTimeKind.Local).AddTicks(2496));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 11, 23, 51, 993, DateTimeKind.Local).AddTicks(2498));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 11, 23, 51, 993, DateTimeKind.Local).AddTicks(2499));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 11, 23, 51, 993, DateTimeKind.Local).AddTicks(2500));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 11, 23, 51, 993, DateTimeKind.Local).AddTicks(2502));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 11, 23, 51, 992, DateTimeKind.Local).AddTicks(8232));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 11, 23, 51, 993, DateTimeKind.Local).AddTicks(2851));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 11, 23, 51, 993, DateTimeKind.Local).AddTicks(2854));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 11, 23, 51, 993, DateTimeKind.Local).AddTicks(2855));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 11, 23, 51, 993, DateTimeKind.Local).AddTicks(2857));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 11, 23, 51, 993, DateTimeKind.Local).AddTicks(2858));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 11, 23, 51, 993, DateTimeKind.Local).AddTicks(2860));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 11, 23, 51, 993, DateTimeKind.Local).AddTicks(2861));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 11, 23, 51, 993, DateTimeKind.Local).AddTicks(2863));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 11, 23, 51, 993, DateTimeKind.Local).AddTicks(2864));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 11, 23, 51, 993, DateTimeKind.Local).AddTicks(2865));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 11, 23, 51, 993, DateTimeKind.Local).AddTicks(882));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryPartners");

            migrationBuilder.DropTable(
                name: "SalesExecutiveRegistrations");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 31, 48, 782, DateTimeKind.Local).AddTicks(8248));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 31, 48, 782, DateTimeKind.Local).AddTicks(8253));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 31, 48, 782, DateTimeKind.Local).AddTicks(8256));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 31, 48, 782, DateTimeKind.Local).AddTicks(8257));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 31, 48, 782, DateTimeKind.Local).AddTicks(8259));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 31, 48, 782, DateTimeKind.Local).AddTicks(8261));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 31, 48, 782, DateTimeKind.Local).AddTicks(8264));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 31, 48, 782, DateTimeKind.Local).AddTicks(9678));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 31, 48, 782, DateTimeKind.Local).AddTicks(9680));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 31, 48, 782, DateTimeKind.Local).AddTicks(8977));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 31, 48, 782, DateTimeKind.Local).AddTicks(8979));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 31, 48, 782, DateTimeKind.Local).AddTicks(8981));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 31, 48, 782, DateTimeKind.Local).AddTicks(8982));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 31, 48, 782, DateTimeKind.Local).AddTicks(8983));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 31, 48, 782, DateTimeKind.Local).AddTicks(8984));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 31, 48, 782, DateTimeKind.Local).AddTicks(8986));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 31, 48, 782, DateTimeKind.Local).AddTicks(8987));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 31, 48, 782, DateTimeKind.Local).AddTicks(8988));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 31, 48, 782, DateTimeKind.Local).AddTicks(8990));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 31, 48, 781, DateTimeKind.Local).AddTicks(8650));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 31, 48, 782, DateTimeKind.Local).AddTicks(9476));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 31, 48, 782, DateTimeKind.Local).AddTicks(9478));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 31, 48, 782, DateTimeKind.Local).AddTicks(9480));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 31, 48, 782, DateTimeKind.Local).AddTicks(9481));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 31, 48, 782, DateTimeKind.Local).AddTicks(9483));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 31, 48, 782, DateTimeKind.Local).AddTicks(9484));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 31, 48, 782, DateTimeKind.Local).AddTicks(9485));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 31, 48, 782, DateTimeKind.Local).AddTicks(9487));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 31, 48, 782, DateTimeKind.Local).AddTicks(9488));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 31, 48, 782, DateTimeKind.Local).AddTicks(9489));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 31, 48, 782, DateTimeKind.Local).AddTicks(5415));
        }
    }
}
