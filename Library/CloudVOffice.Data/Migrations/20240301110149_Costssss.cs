using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudVOffice.Data.Migrations
{
    /// <inheritdoc />
    public partial class Costssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "DistributorCaseCost",
                table: "Items",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DistributorCost",
                table: "Items",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DistributorLandingCost",
                table: "Items",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PurchaseLandingCost",
                table: "Items",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "RetailerCaseCost",
                table: "Items",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "RetailerCost",
                table: "Items",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "RetailerLandingCost",
                table: "Items",
                type: "float",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DistributorCaseCost",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "DistributorCost",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "DistributorLandingCost",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "PurchaseLandingCost",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "RetailerCaseCost",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "RetailerCost",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "RetailerLandingCost",
                table: "Items");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 28, 11, 289, DateTimeKind.Local).AddTicks(963));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 28, 11, 289, DateTimeKind.Local).AddTicks(968));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 28, 11, 289, DateTimeKind.Local).AddTicks(970));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 28, 11, 289, DateTimeKind.Local).AddTicks(971));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 28, 11, 289, DateTimeKind.Local).AddTicks(973));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 28, 11, 289, DateTimeKind.Local).AddTicks(975));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 28, 11, 289, DateTimeKind.Local).AddTicks(977));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 28, 11, 289, DateTimeKind.Local).AddTicks(2046));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 28, 11, 289, DateTimeKind.Local).AddTicks(2065));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 28, 11, 289, DateTimeKind.Local).AddTicks(1432));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 28, 11, 289, DateTimeKind.Local).AddTicks(1435));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 28, 11, 289, DateTimeKind.Local).AddTicks(1436));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 28, 11, 289, DateTimeKind.Local).AddTicks(1437));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 28, 11, 289, DateTimeKind.Local).AddTicks(1439));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 28, 11, 289, DateTimeKind.Local).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 28, 11, 289, DateTimeKind.Local).AddTicks(1441));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 28, 11, 289, DateTimeKind.Local).AddTicks(1443));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 28, 11, 289, DateTimeKind.Local).AddTicks(1444));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 28, 11, 289, DateTimeKind.Local).AddTicks(1445));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 28, 11, 288, DateTimeKind.Local).AddTicks(7993));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 28, 11, 289, DateTimeKind.Local).AddTicks(1849));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 28, 11, 289, DateTimeKind.Local).AddTicks(1852));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 28, 11, 289, DateTimeKind.Local).AddTicks(1853));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 28, 11, 289, DateTimeKind.Local).AddTicks(1855));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 28, 11, 289, DateTimeKind.Local).AddTicks(1856));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 28, 11, 289, DateTimeKind.Local).AddTicks(1857));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 28, 11, 289, DateTimeKind.Local).AddTicks(1859));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 28, 11, 289, DateTimeKind.Local).AddTicks(1860));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 28, 11, 289, DateTimeKind.Local).AddTicks(1862));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 28, 11, 289, DateTimeKind.Local).AddTicks(1863));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 1, 16, 28, 11, 289, DateTimeKind.Local).AddTicks(23));
        }
    }
}
