using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudVOffice.Data.Migrations
{
    /// <inheritdoc />
    public partial class UOMandPWeightt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitOfMeasurement",
                table: "Items",
                newName: "ProductWeight");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseYear",
                table: "Vehicles",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<long>(
                name: "UnitId",
                table: "Items",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(3287));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(3290));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(3292));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(3304));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(3306));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(3308));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(3310));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(3311));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(3313));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(3315));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(4398));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(4401));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(3716));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(3718));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(3719));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(3720));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(3721));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(3723));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(3724));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(3725));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(3727));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(3728));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 171, DateTimeKind.Local).AddTicks(8430));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(4178));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(4180));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(4182));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(4183));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(4184));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(4186));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(4187));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(4188));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(4190));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(4191));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 14, 37, 14, 172, DateTimeKind.Local).AddTicks(2301));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "ProductWeight",
                table: "Items",
                newName: "UnitOfMeasurement");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseYear",
                table: "Vehicles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(4165));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(4167));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(4169));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(4171));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(4173));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(4174));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(4176));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(4178));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(4180));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(4181));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(5019));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(5021));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(4556));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(4559));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(4560));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(4561));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(4563));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(4564));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(4565));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(4567));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(4568));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(4569));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 216, DateTimeKind.Local).AddTicks(9204));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(4886));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(4889));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(4890));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(4892));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(4893));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(4895));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(4896));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(4897));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(4899));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(4900));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 12, 11, 21, 53, 217, DateTimeKind.Local).AddTicks(3367));
        }
    }
}
