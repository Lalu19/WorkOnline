using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudVOffice.Data.Migrations
{
    /// <inheritdoc />
    public partial class RetailModelAddition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalesRepresentativeContact",
                table: "BuyerRegistrations");

            migrationBuilder.DropColumn(
                name: "SalesRepresentativeId",
                table: "BuyerRegistrations");

            migrationBuilder.AddColumn<long>(
                name: "RetailModelId",
                table: "SellerRegistrations",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RetailModelId",
                table: "SalesExecutiveRegistrations",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RetailModelId",
                table: "DeliveryPartners",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RetailModelId",
                table: "BuyerRegistrations",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesExecutiveContact",
                table: "BuyerRegistrations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesExecutiveUniqueNumber",
                table: "BuyerRegistrations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 5, 11, 30, 50, 45, DateTimeKind.Local).AddTicks(6982));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 5, 11, 30, 50, 45, DateTimeKind.Local).AddTicks(6989));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 5, 11, 30, 50, 45, DateTimeKind.Local).AddTicks(6991));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 5, 11, 30, 50, 45, DateTimeKind.Local).AddTicks(6994));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 5, 11, 30, 50, 45, DateTimeKind.Local).AddTicks(6997));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 5, 11, 30, 50, 45, DateTimeKind.Local).AddTicks(7000));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 5, 11, 30, 50, 45, DateTimeKind.Local).AddTicks(7003));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 5, 11, 30, 50, 45, DateTimeKind.Local).AddTicks(8434));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 5, 11, 30, 50, 45, DateTimeKind.Local).AddTicks(8469));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 5, 11, 30, 50, 45, DateTimeKind.Local).AddTicks(7636));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 5, 11, 30, 50, 45, DateTimeKind.Local).AddTicks(7640));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 5, 11, 30, 50, 45, DateTimeKind.Local).AddTicks(7642));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 5, 11, 30, 50, 45, DateTimeKind.Local).AddTicks(7644));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 5, 11, 30, 50, 45, DateTimeKind.Local).AddTicks(7646));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 5, 11, 30, 50, 45, DateTimeKind.Local).AddTicks(7649));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 5, 11, 30, 50, 45, DateTimeKind.Local).AddTicks(7651));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 5, 11, 30, 50, 45, DateTimeKind.Local).AddTicks(7653));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 5, 11, 30, 50, 45, DateTimeKind.Local).AddTicks(7655));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 5, 11, 30, 50, 45, DateTimeKind.Local).AddTicks(7657));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 5, 11, 30, 50, 45, DateTimeKind.Local).AddTicks(239));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 5, 11, 30, 50, 45, DateTimeKind.Local).AddTicks(8152));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 5, 11, 30, 50, 45, DateTimeKind.Local).AddTicks(8199));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 5, 11, 30, 50, 45, DateTimeKind.Local).AddTicks(8202));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 5, 11, 30, 50, 45, DateTimeKind.Local).AddTicks(8204));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 5, 11, 30, 50, 45, DateTimeKind.Local).AddTicks(8206));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 5, 11, 30, 50, 45, DateTimeKind.Local).AddTicks(8209));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 5, 11, 30, 50, 45, DateTimeKind.Local).AddTicks(8211));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 5, 11, 30, 50, 45, DateTimeKind.Local).AddTicks(8213));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 5, 11, 30, 50, 45, DateTimeKind.Local).AddTicks(8215));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 5, 11, 30, 50, 45, DateTimeKind.Local).AddTicks(8217));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 5, 11, 30, 50, 45, DateTimeKind.Local).AddTicks(4656));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RetailModelId",
                table: "SellerRegistrations");

            migrationBuilder.DropColumn(
                name: "RetailModelId",
                table: "SalesExecutiveRegistrations");

            migrationBuilder.DropColumn(
                name: "RetailModelId",
                table: "DeliveryPartners");

            migrationBuilder.DropColumn(
                name: "RetailModelId",
                table: "BuyerRegistrations");

            migrationBuilder.DropColumn(
                name: "SalesExecutiveContact",
                table: "BuyerRegistrations");

            migrationBuilder.DropColumn(
                name: "SalesExecutiveUniqueNumber",
                table: "BuyerRegistrations");

            migrationBuilder.AddColumn<string>(
                name: "SalesRepresentativeContact",
                table: "BuyerRegistrations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SalesRepresentativeId",
                table: "BuyerRegistrations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 14, 51, 12, 818, DateTimeKind.Local).AddTicks(404));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 14, 51, 12, 818, DateTimeKind.Local).AddTicks(417));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 14, 51, 12, 818, DateTimeKind.Local).AddTicks(420));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 14, 51, 12, 818, DateTimeKind.Local).AddTicks(423));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 14, 51, 12, 818, DateTimeKind.Local).AddTicks(426));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 14, 51, 12, 818, DateTimeKind.Local).AddTicks(429));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 14, 51, 12, 818, DateTimeKind.Local).AddTicks(432));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 14, 51, 12, 818, DateTimeKind.Local).AddTicks(2857));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 14, 51, 12, 818, DateTimeKind.Local).AddTicks(2875));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 14, 51, 12, 818, DateTimeKind.Local).AddTicks(1355));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 14, 51, 12, 818, DateTimeKind.Local).AddTicks(1362));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 14, 51, 12, 818, DateTimeKind.Local).AddTicks(1364));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 14, 51, 12, 818, DateTimeKind.Local).AddTicks(1367));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 14, 51, 12, 818, DateTimeKind.Local).AddTicks(1369));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 14, 51, 12, 818, DateTimeKind.Local).AddTicks(1371));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 14, 51, 12, 818, DateTimeKind.Local).AddTicks(1373));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 14, 51, 12, 818, DateTimeKind.Local).AddTicks(1375));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 14, 51, 12, 818, DateTimeKind.Local).AddTicks(1377));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 14, 51, 12, 818, DateTimeKind.Local).AddTicks(1379));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 14, 51, 12, 817, DateTimeKind.Local).AddTicks(6873));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 14, 51, 12, 818, DateTimeKind.Local).AddTicks(2463));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 14, 51, 12, 818, DateTimeKind.Local).AddTicks(2471));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 14, 51, 12, 818, DateTimeKind.Local).AddTicks(2474));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 14, 51, 12, 818, DateTimeKind.Local).AddTicks(2476));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 14, 51, 12, 818, DateTimeKind.Local).AddTicks(2479));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 14, 51, 12, 818, DateTimeKind.Local).AddTicks(2481));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 14, 51, 12, 818, DateTimeKind.Local).AddTicks(2483));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 14, 51, 12, 818, DateTimeKind.Local).AddTicks(2486));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 14, 51, 12, 818, DateTimeKind.Local).AddTicks(2488));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 14, 51, 12, 818, DateTimeKind.Local).AddTicks(2490));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 4, 14, 51, 12, 817, DateTimeKind.Local).AddTicks(8833));
        }
    }
}
