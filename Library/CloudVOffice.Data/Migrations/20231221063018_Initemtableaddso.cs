using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudVOffice.Data.Migrations
{
    /// <inheritdoc />
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20231221103212_ShortNames.cs
    public partial class ShortNames : Migration
========
    public partial class Initemtableaddso : Migration
>>>>>>>> 82200d46c68a940f043e4c730a7bf367bb4f8536:Library/CloudVOffice.Data/Migrations/20231221063018_Initemtableaddso.cs
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20231221103212_ShortNames.cs
            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "ItemMasterForFarmings",
                type: "nvarchar(max)",
                nullable: true);
========
            migrationBuilder.AddColumn<double>(
                name: "MRPCaseCost",
                table: "Items",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PurchaseCaseCost",
                table: "Items",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SalesCaseCost",
                table: "Items",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "ItemMasterForFarmings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "ItemMasterForFarmings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VendorId",
                table: "ItemMasterForFarmings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WareHuoseId",
                table: "ItemMasterForFarmings",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 0, 18, 392, DateTimeKind.Local).AddTicks(8123));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 0, 18, 392, DateTimeKind.Local).AddTicks(8126));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 0, 18, 392, DateTimeKind.Local).AddTicks(8128));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 0, 18, 392, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 0, 18, 392, DateTimeKind.Local).AddTicks(8131));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 0, 18, 392, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 0, 18, 392, DateTimeKind.Local).AddTicks(8134));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 0, 18, 392, DateTimeKind.Local).AddTicks(8697));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 0, 18, 392, DateTimeKind.Local).AddTicks(8699));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 0, 18, 392, DateTimeKind.Local).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 0, 18, 392, DateTimeKind.Local).AddTicks(8382));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 0, 18, 392, DateTimeKind.Local).AddTicks(8383));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 0, 18, 392, DateTimeKind.Local).AddTicks(8384));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 0, 18, 392, DateTimeKind.Local).AddTicks(8385));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 0, 18, 392, DateTimeKind.Local).AddTicks(8386));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 0, 18, 392, DateTimeKind.Local).AddTicks(8388));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 0, 18, 392, DateTimeKind.Local).AddTicks(8389));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 0, 18, 392, DateTimeKind.Local).AddTicks(8390));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 0, 18, 392, DateTimeKind.Local).AddTicks(8391));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 0, 18, 392, DateTimeKind.Local).AddTicks(6893));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 0, 18, 392, DateTimeKind.Local).AddTicks(8618));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 0, 18, 392, DateTimeKind.Local).AddTicks(8620));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 0, 18, 392, DateTimeKind.Local).AddTicks(8621));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 0, 18, 392, DateTimeKind.Local).AddTicks(8623));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 0, 18, 392, DateTimeKind.Local).AddTicks(8624));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 0, 18, 392, DateTimeKind.Local).AddTicks(8625));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 0, 18, 392, DateTimeKind.Local).AddTicks(8626));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 0, 18, 392, DateTimeKind.Local).AddTicks(8628));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 0, 18, 392, DateTimeKind.Local).AddTicks(8629));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 0, 18, 392, DateTimeKind.Local).AddTicks(8630));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 0, 18, 392, DateTimeKind.Local).AddTicks(7726));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MRPCaseCost",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "PurchaseCaseCost",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SalesCaseCost",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "ItemMasterForFarmings");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "ItemMasterForFarmings");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "ItemMasterForFarmings");

            migrationBuilder.DropColumn(
                name: "WareHuoseId",
                table: "ItemMasterForFarmings");
>>>>>>>> 82200d46c68a940f043e4c730a7bf367bb4f8536:Library/CloudVOffice.Data/Migrations/20231221063018_Initemtableaddso.cs

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 16, 2, 11, 520, DateTimeKind.Local).AddTicks(6840));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 16, 2, 11, 520, DateTimeKind.Local).AddTicks(6853));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 16, 2, 11, 520, DateTimeKind.Local).AddTicks(6857));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 16, 2, 11, 520, DateTimeKind.Local).AddTicks(6861));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 16, 2, 11, 520, DateTimeKind.Local).AddTicks(6865));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 16, 2, 11, 520, DateTimeKind.Local).AddTicks(6868));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 16, 2, 11, 520, DateTimeKind.Local).AddTicks(6872));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 16, 2, 11, 520, DateTimeKind.Local).AddTicks(9926));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 16, 2, 11, 520, DateTimeKind.Local).AddTicks(9934));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 16, 2, 11, 520, DateTimeKind.Local).AddTicks(8201));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 16, 2, 11, 520, DateTimeKind.Local).AddTicks(8210));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 16, 2, 11, 520, DateTimeKind.Local).AddTicks(8213));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 16, 2, 11, 520, DateTimeKind.Local).AddTicks(8216));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 16, 2, 11, 520, DateTimeKind.Local).AddTicks(8219));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 16, 2, 11, 520, DateTimeKind.Local).AddTicks(8222));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 16, 2, 11, 520, DateTimeKind.Local).AddTicks(8225));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 16, 2, 11, 520, DateTimeKind.Local).AddTicks(8228));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 16, 2, 11, 520, DateTimeKind.Local).AddTicks(8230));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 16, 2, 11, 520, DateTimeKind.Local).AddTicks(8233));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 16, 2, 11, 520, DateTimeKind.Local).AddTicks(2485));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 16, 2, 11, 520, DateTimeKind.Local).AddTicks(9461));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 16, 2, 11, 520, DateTimeKind.Local).AddTicks(9471));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 16, 2, 11, 520, DateTimeKind.Local).AddTicks(9476));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 16, 2, 11, 520, DateTimeKind.Local).AddTicks(9479));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 16, 2, 11, 520, DateTimeKind.Local).AddTicks(9484));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 16, 2, 11, 520, DateTimeKind.Local).AddTicks(9487));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 16, 2, 11, 520, DateTimeKind.Local).AddTicks(9490));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 16, 2, 11, 520, DateTimeKind.Local).AddTicks(9493));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 16, 2, 11, 520, DateTimeKind.Local).AddTicks(9495));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 16, 2, 11, 520, DateTimeKind.Local).AddTicks(9499));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 16, 2, 11, 520, DateTimeKind.Local).AddTicks(4963));
        }
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20231221103212_ShortNames.cs

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "ItemMasterForFarmings");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 3, 21, 939, DateTimeKind.Local).AddTicks(4866));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 3, 21, 939, DateTimeKind.Local).AddTicks(4875));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 3, 21, 939, DateTimeKind.Local).AddTicks(4878));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 3, 21, 939, DateTimeKind.Local).AddTicks(4881));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 3, 21, 939, DateTimeKind.Local).AddTicks(4884));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 3, 21, 939, DateTimeKind.Local).AddTicks(4887));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 3, 21, 939, DateTimeKind.Local).AddTicks(4891));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 3, 21, 939, DateTimeKind.Local).AddTicks(6931));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 3, 21, 939, DateTimeKind.Local).AddTicks(6938));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 3, 21, 939, DateTimeKind.Local).AddTicks(5769));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 3, 21, 939, DateTimeKind.Local).AddTicks(5774));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 3, 21, 939, DateTimeKind.Local).AddTicks(5777));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 3, 21, 939, DateTimeKind.Local).AddTicks(5779));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 3, 21, 939, DateTimeKind.Local).AddTicks(5782));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 3, 21, 939, DateTimeKind.Local).AddTicks(5784));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 3, 21, 939, DateTimeKind.Local).AddTicks(5786));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 3, 21, 939, DateTimeKind.Local).AddTicks(5789));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 3, 21, 939, DateTimeKind.Local).AddTicks(5791));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 3, 21, 939, DateTimeKind.Local).AddTicks(5793));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 3, 21, 939, DateTimeKind.Local).AddTicks(1555));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 3, 21, 939, DateTimeKind.Local).AddTicks(6606));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 3, 21, 939, DateTimeKind.Local).AddTicks(6612));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 3, 21, 939, DateTimeKind.Local).AddTicks(6614));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 3, 21, 939, DateTimeKind.Local).AddTicks(6617));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 3, 21, 939, DateTimeKind.Local).AddTicks(6619));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 3, 21, 939, DateTimeKind.Local).AddTicks(6621));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 3, 21, 939, DateTimeKind.Local).AddTicks(6624));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 3, 21, 939, DateTimeKind.Local).AddTicks(6626));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 3, 21, 939, DateTimeKind.Local).AddTicks(6628));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 3, 21, 939, DateTimeKind.Local).AddTicks(6631));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 21, 12, 3, 21, 939, DateTimeKind.Local).AddTicks(3689));
        }
========
>>>>>>>> 82200d46c68a940f043e4c730a7bf367bb4f8536:Library/CloudVOffice.Data/Migrations/20231221063018_Initemtableaddso.cs
    }
}
