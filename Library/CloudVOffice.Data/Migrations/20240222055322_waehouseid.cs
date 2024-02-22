using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudVOffice.Data.Migrations
{
    /// <inheritdoc />
    public partial class waehouseid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "WareHuoseId",
                table: "PurchaseOrderParents",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 11, 23, 21, 679, DateTimeKind.Local).AddTicks(5129));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 11, 23, 21, 679, DateTimeKind.Local).AddTicks(5135));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 11, 23, 21, 679, DateTimeKind.Local).AddTicks(5138));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 11, 23, 21, 679, DateTimeKind.Local).AddTicks(5140));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 11, 23, 21, 679, DateTimeKind.Local).AddTicks(5144));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 11, 23, 21, 679, DateTimeKind.Local).AddTicks(5146));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 11, 23, 21, 679, DateTimeKind.Local).AddTicks(5148));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 11, 23, 21, 679, DateTimeKind.Local).AddTicks(6303));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 11, 23, 21, 679, DateTimeKind.Local).AddTicks(6370));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 11, 23, 21, 679, DateTimeKind.Local).AddTicks(5623));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 11, 23, 21, 679, DateTimeKind.Local).AddTicks(5626));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 11, 23, 21, 679, DateTimeKind.Local).AddTicks(5628));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 11, 23, 21, 679, DateTimeKind.Local).AddTicks(5630));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 11, 23, 21, 679, DateTimeKind.Local).AddTicks(5632));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 11, 23, 21, 679, DateTimeKind.Local).AddTicks(5633));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 11, 23, 21, 679, DateTimeKind.Local).AddTicks(5635));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 11, 23, 21, 679, DateTimeKind.Local).AddTicks(5636));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 11, 23, 21, 679, DateTimeKind.Local).AddTicks(5638));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 11, 23, 21, 679, DateTimeKind.Local).AddTicks(5640));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 11, 23, 21, 679, DateTimeKind.Local).AddTicks(2976));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 11, 23, 21, 679, DateTimeKind.Local).AddTicks(6115));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 11, 23, 21, 679, DateTimeKind.Local).AddTicks(6119));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 11, 23, 21, 679, DateTimeKind.Local).AddTicks(6121));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 11, 23, 21, 679, DateTimeKind.Local).AddTicks(6123));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 11, 23, 21, 679, DateTimeKind.Local).AddTicks(6125));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 11, 23, 21, 679, DateTimeKind.Local).AddTicks(6127));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 11, 23, 21, 679, DateTimeKind.Local).AddTicks(6129));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 11, 23, 21, 679, DateTimeKind.Local).AddTicks(6131));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 11, 23, 21, 679, DateTimeKind.Local).AddTicks(6133));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 11, 23, 21, 679, DateTimeKind.Local).AddTicks(6136));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 11, 23, 21, 679, DateTimeKind.Local).AddTicks(4336));

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderParents_WareHuoseId",
                table: "PurchaseOrderParents",
                column: "WareHuoseId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderParents_WareHouses_WareHuoseId",
                table: "PurchaseOrderParents",
                column: "WareHuoseId",
                principalTable: "WareHouses",
                principalColumn: "WareHuoseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderParents_WareHouses_WareHuoseId",
                table: "PurchaseOrderParents");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrderParents_WareHuoseId",
                table: "PurchaseOrderParents");

            migrationBuilder.DropColumn(
                name: "WareHuoseId",
                table: "PurchaseOrderParents");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 15, 33, 31, 622, DateTimeKind.Local).AddTicks(5696));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 15, 33, 31, 622, DateTimeKind.Local).AddTicks(5701));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 15, 33, 31, 622, DateTimeKind.Local).AddTicks(5703));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 15, 33, 31, 622, DateTimeKind.Local).AddTicks(5705));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 15, 33, 31, 622, DateTimeKind.Local).AddTicks(5707));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 15, 33, 31, 622, DateTimeKind.Local).AddTicks(5709));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 15, 33, 31, 622, DateTimeKind.Local).AddTicks(5749));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 15, 33, 31, 622, DateTimeKind.Local).AddTicks(6814));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 15, 33, 31, 622, DateTimeKind.Local).AddTicks(6816));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 15, 33, 31, 622, DateTimeKind.Local).AddTicks(6186));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 15, 33, 31, 622, DateTimeKind.Local).AddTicks(6189));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 15, 33, 31, 622, DateTimeKind.Local).AddTicks(6190));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 15, 33, 31, 622, DateTimeKind.Local).AddTicks(6192));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 15, 33, 31, 622, DateTimeKind.Local).AddTicks(6193));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 15, 33, 31, 622, DateTimeKind.Local).AddTicks(6195));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 15, 33, 31, 622, DateTimeKind.Local).AddTicks(6196));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 15, 33, 31, 622, DateTimeKind.Local).AddTicks(6197));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 15, 33, 31, 622, DateTimeKind.Local).AddTicks(6199));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 15, 33, 31, 622, DateTimeKind.Local).AddTicks(6200));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 15, 33, 31, 622, DateTimeKind.Local).AddTicks(3748));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 15, 33, 31, 622, DateTimeKind.Local).AddTicks(6636));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 15, 33, 31, 622, DateTimeKind.Local).AddTicks(6638));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 15, 33, 31, 622, DateTimeKind.Local).AddTicks(6640));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 15, 33, 31, 622, DateTimeKind.Local).AddTicks(6642));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 15, 33, 31, 622, DateTimeKind.Local).AddTicks(6643));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 15, 33, 31, 622, DateTimeKind.Local).AddTicks(6645));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 15, 33, 31, 622, DateTimeKind.Local).AddTicks(6646));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 15, 33, 31, 622, DateTimeKind.Local).AddTicks(6648));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 15, 33, 31, 622, DateTimeKind.Local).AddTicks(6650));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 15, 33, 31, 622, DateTimeKind.Local).AddTicks(6651));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 21, 15, 33, 31, 622, DateTimeKind.Local).AddTicks(5014));
        }
    }
}
