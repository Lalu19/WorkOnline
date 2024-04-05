using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudVOffice.Data.Migrations
{
    /// <inheritdoc />
    public partial class DATasksDistributorsssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DATasksDistributorId",
                table: "WareHouseDAAccepts",
                type: "bigint",
                nullable: true);

            //migrationBuilder.AddColumn<long>(
            //    name: "BuyerOrderId",
            //    table: "DSO",
            //    type: "bigint",
            //    nullable: true);

            //migrationBuilder.AddColumn<double>(
            //    name: "TotalWaight",
            //    table: "DSO",
            //    type: "float",
            //    nullable: true);

            migrationBuilder.CreateTable(
                name: "DATasksDistributors",
                columns: table => new
                {
                    DATasksDistributorId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryPartnerId = table.Column<long>(type: "bigint", nullable: true),
                    DistributorRegistrationId = table.Column<long>(type: "bigint", nullable: true),
                    Orderweight = table.Column<double>(type: "float", nullable: true),
                    OrderAmount = table.Column<double>(type: "float", nullable: true),
                    TaskAccepted = table.Column<bool>(type: "bit", nullable: false),
                    OrderUniqueNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyerRegistrationId = table.Column<long>(type: "bigint", nullable: true),
                    AssignmentCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotificationSent = table.Column<bool>(type: "bit", nullable: false),
                    TaskDone = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DATasksDistributors", x => x.DATasksDistributorId);
                });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4126));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4131));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4132));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4134));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4136));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4138));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4140));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(5284));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(5310));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4621));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4623));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4625));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4626));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4627));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4629));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4630));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4631));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4633));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4634));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(1730));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(5044));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(5047));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(5048));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(5050));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(5051));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(5052));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(5054));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(5055));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(5057));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(5058));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(3266));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DATasksDistributors");

            migrationBuilder.DropColumn(
                name: "DATasksDistributorId",
                table: "WareHouseDAAccepts");

            migrationBuilder.DropColumn(
                name: "BuyerOrderId",
                table: "DSO");

            migrationBuilder.DropColumn(
                name: "TotalWaight",
                table: "DSO");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 18, 8, 55, 48, DateTimeKind.Local).AddTicks(6813));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 18, 8, 55, 48, DateTimeKind.Local).AddTicks(6817));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 18, 8, 55, 48, DateTimeKind.Local).AddTicks(6819));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 18, 8, 55, 48, DateTimeKind.Local).AddTicks(6821));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 18, 8, 55, 48, DateTimeKind.Local).AddTicks(6823));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 18, 8, 55, 48, DateTimeKind.Local).AddTicks(6825));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 18, 8, 55, 48, DateTimeKind.Local).AddTicks(6828));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 18, 8, 55, 48, DateTimeKind.Local).AddTicks(7985));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 18, 8, 55, 48, DateTimeKind.Local).AddTicks(8005));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 18, 8, 55, 48, DateTimeKind.Local).AddTicks(7308));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 18, 8, 55, 48, DateTimeKind.Local).AddTicks(7312));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 18, 8, 55, 48, DateTimeKind.Local).AddTicks(7313));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 18, 8, 55, 48, DateTimeKind.Local).AddTicks(7315));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 18, 8, 55, 48, DateTimeKind.Local).AddTicks(7316));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 18, 8, 55, 48, DateTimeKind.Local).AddTicks(7318));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 18, 8, 55, 48, DateTimeKind.Local).AddTicks(7320));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 18, 8, 55, 48, DateTimeKind.Local).AddTicks(7321));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 18, 8, 55, 48, DateTimeKind.Local).AddTicks(7323));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 18, 8, 55, 48, DateTimeKind.Local).AddTicks(7324));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 18, 8, 55, 48, DateTimeKind.Local).AddTicks(4539));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 18, 8, 55, 48, DateTimeKind.Local).AddTicks(7765));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 18, 8, 55, 48, DateTimeKind.Local).AddTicks(7768));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 18, 8, 55, 48, DateTimeKind.Local).AddTicks(7769));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 18, 8, 55, 48, DateTimeKind.Local).AddTicks(7771));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 18, 8, 55, 48, DateTimeKind.Local).AddTicks(7773));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 18, 8, 55, 48, DateTimeKind.Local).AddTicks(7775));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 18, 8, 55, 48, DateTimeKind.Local).AddTicks(7776));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 18, 8, 55, 48, DateTimeKind.Local).AddTicks(7778));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 18, 8, 55, 48, DateTimeKind.Local).AddTicks(7780));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 18, 8, 55, 48, DateTimeKind.Local).AddTicks(7782));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 18, 8, 55, 48, DateTimeKind.Local).AddTicks(6086));
        }
    }
}
