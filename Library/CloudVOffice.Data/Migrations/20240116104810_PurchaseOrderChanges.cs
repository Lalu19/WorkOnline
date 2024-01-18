using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudVOffice.Data.Migrations
{
    /// <inheritdoc />
    public partial class PurchaseOrderChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UnitId",
                table: "PurchaseOrders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<double>(
                name: "Value",
                table: "PurchaseOrders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 18, 9, 983, DateTimeKind.Local).AddTicks(32));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 18, 9, 983, DateTimeKind.Local).AddTicks(35));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 18, 9, 983, DateTimeKind.Local).AddTicks(37));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 18, 9, 983, DateTimeKind.Local).AddTicks(39));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 18, 9, 983, DateTimeKind.Local).AddTicks(40));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 18, 9, 983, DateTimeKind.Local).AddTicks(42));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 18, 9, 983, DateTimeKind.Local).AddTicks(44));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 18, 9, 983, DateTimeKind.Local).AddTicks(887));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 18, 9, 983, DateTimeKind.Local).AddTicks(889));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 18, 9, 983, DateTimeKind.Local).AddTicks(410));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 18, 9, 983, DateTimeKind.Local).AddTicks(413));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 18, 9, 983, DateTimeKind.Local).AddTicks(414));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 18, 9, 983, DateTimeKind.Local).AddTicks(415));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 18, 9, 983, DateTimeKind.Local).AddTicks(416));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 18, 9, 983, DateTimeKind.Local).AddTicks(418));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 18, 9, 983, DateTimeKind.Local).AddTicks(419));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 18, 9, 983, DateTimeKind.Local).AddTicks(421));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 18, 9, 983, DateTimeKind.Local).AddTicks(422));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 18, 9, 983, DateTimeKind.Local).AddTicks(423));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 18, 9, 982, DateTimeKind.Local).AddTicks(8145));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 18, 9, 983, DateTimeKind.Local).AddTicks(764));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 18, 9, 983, DateTimeKind.Local).AddTicks(767));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 18, 9, 983, DateTimeKind.Local).AddTicks(768));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 18, 9, 983, DateTimeKind.Local).AddTicks(770));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 18, 9, 983, DateTimeKind.Local).AddTicks(771));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 18, 9, 983, DateTimeKind.Local).AddTicks(772));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 18, 9, 983, DateTimeKind.Local).AddTicks(774));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 18, 9, 983, DateTimeKind.Local).AddTicks(775));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 18, 9, 983, DateTimeKind.Local).AddTicks(777));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 18, 9, 983, DateTimeKind.Local).AddTicks(778));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 16, 18, 9, 982, DateTimeKind.Local).AddTicks(9489));

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_UnitId",
                table: "PurchaseOrders",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_Units_UnitId",
                table: "PurchaseOrders",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_Units_UnitId",
                table: "PurchaseOrders");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrders_UnitId",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "PurchaseOrders");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 14, 41, 43, 548, DateTimeKind.Local).AddTicks(3451));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 14, 41, 43, 548, DateTimeKind.Local).AddTicks(3466));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 14, 41, 43, 548, DateTimeKind.Local).AddTicks(3470));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 14, 41, 43, 548, DateTimeKind.Local).AddTicks(3472));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 14, 41, 43, 548, DateTimeKind.Local).AddTicks(3474));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 14, 41, 43, 548, DateTimeKind.Local).AddTicks(3476));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 14, 41, 43, 548, DateTimeKind.Local).AddTicks(3479));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 14, 41, 43, 548, DateTimeKind.Local).AddTicks(6198));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 14, 41, 43, 548, DateTimeKind.Local).AddTicks(6226));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 14, 41, 43, 548, DateTimeKind.Local).AddTicks(4847));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 14, 41, 43, 548, DateTimeKind.Local).AddTicks(4856));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 14, 41, 43, 548, DateTimeKind.Local).AddTicks(4858));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 14, 41, 43, 548, DateTimeKind.Local).AddTicks(4861));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 14, 41, 43, 548, DateTimeKind.Local).AddTicks(4863));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 14, 41, 43, 548, DateTimeKind.Local).AddTicks(4865));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 14, 41, 43, 548, DateTimeKind.Local).AddTicks(4867));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 14, 41, 43, 548, DateTimeKind.Local).AddTicks(4869));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 14, 41, 43, 548, DateTimeKind.Local).AddTicks(4871));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 14, 41, 43, 548, DateTimeKind.Local).AddTicks(4874));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 14, 41, 43, 547, DateTimeKind.Local).AddTicks(2413));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 14, 41, 43, 548, DateTimeKind.Local).AddTicks(5841));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 14, 41, 43, 548, DateTimeKind.Local).AddTicks(5848));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 14, 41, 43, 548, DateTimeKind.Local).AddTicks(5851));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 14, 41, 43, 548, DateTimeKind.Local).AddTicks(5853));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 14, 41, 43, 548, DateTimeKind.Local).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 14, 41, 43, 548, DateTimeKind.Local).AddTicks(5858));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 14, 41, 43, 548, DateTimeKind.Local).AddTicks(5860));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 14, 41, 43, 548, DateTimeKind.Local).AddTicks(5862));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 14, 41, 43, 548, DateTimeKind.Local).AddTicks(5864));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 14, 41, 43, 548, DateTimeKind.Local).AddTicks(5866));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 14, 41, 43, 548, DateTimeKind.Local).AddTicks(15));
        }
    }
}
