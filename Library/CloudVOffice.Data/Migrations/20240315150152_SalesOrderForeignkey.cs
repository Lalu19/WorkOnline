using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudVOffice.Data.Migrations
{
    /// <inheritdoc />
    public partial class SalesOrderForeignkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "WareHuoseId",
                table: "SalesOrderParents",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 20, 31, 51, 232, DateTimeKind.Local).AddTicks(1692));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 20, 31, 51, 232, DateTimeKind.Local).AddTicks(1709));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 20, 31, 51, 232, DateTimeKind.Local).AddTicks(1716));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 20, 31, 51, 232, DateTimeKind.Local).AddTicks(1722));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 20, 31, 51, 232, DateTimeKind.Local).AddTicks(1728));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 20, 31, 51, 232, DateTimeKind.Local).AddTicks(1736));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 20, 31, 51, 232, DateTimeKind.Local).AddTicks(1739));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 20, 31, 51, 232, DateTimeKind.Local).AddTicks(7076));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 20, 31, 51, 232, DateTimeKind.Local).AddTicks(7107));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 20, 31, 51, 232, DateTimeKind.Local).AddTicks(3820));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 20, 31, 51, 232, DateTimeKind.Local).AddTicks(3832));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 20, 31, 51, 232, DateTimeKind.Local).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 20, 31, 51, 232, DateTimeKind.Local).AddTicks(3837));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 20, 31, 51, 232, DateTimeKind.Local).AddTicks(3840));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 20, 31, 51, 232, DateTimeKind.Local).AddTicks(3843));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 20, 31, 51, 232, DateTimeKind.Local).AddTicks(3845));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 20, 31, 51, 232, DateTimeKind.Local).AddTicks(3848));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 20, 31, 51, 232, DateTimeKind.Local).AddTicks(3850));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 20, 31, 51, 232, DateTimeKind.Local).AddTicks(3852));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 20, 31, 51, 231, DateTimeKind.Local).AddTicks(4458));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 20, 31, 51, 232, DateTimeKind.Local).AddTicks(6042));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 20, 31, 51, 232, DateTimeKind.Local).AddTicks(6055));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 20, 31, 51, 232, DateTimeKind.Local).AddTicks(6059));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 20, 31, 51, 232, DateTimeKind.Local).AddTicks(6061));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 20, 31, 51, 232, DateTimeKind.Local).AddTicks(6064));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 20, 31, 51, 232, DateTimeKind.Local).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 20, 31, 51, 232, DateTimeKind.Local).AddTicks(6070));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 20, 31, 51, 232, DateTimeKind.Local).AddTicks(6072));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 20, 31, 51, 232, DateTimeKind.Local).AddTicks(6075));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 20, 31, 51, 232, DateTimeKind.Local).AddTicks(6077));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 15, 20, 31, 51, 231, DateTimeKind.Local).AddTicks(8700));

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderParents_WareHuoseId",
                table: "SalesOrderParents",
                column: "WareHuoseId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderItems_ItemId",
                table: "SalesOrderItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderItems_SalesOrderParentId",
                table: "SalesOrderItems",
                column: "SalesOrderParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderItems_Items_ItemId",
                table: "SalesOrderItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderItems_SalesOrderParents_SalesOrderParentId",
                table: "SalesOrderItems",
                column: "SalesOrderParentId",
                principalTable: "SalesOrderParents",
                principalColumn: "SalesOrderParentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderParents_WareHouses_WareHuoseId",
                table: "SalesOrderParents",
                column: "WareHuoseId",
                principalTable: "WareHouses",
                principalColumn: "WareHuoseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderItems_Items_ItemId",
                table: "SalesOrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderItems_SalesOrderParents_SalesOrderParentId",
                table: "SalesOrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderParents_WareHouses_WareHuoseId",
                table: "SalesOrderParents");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrderParents_WareHuoseId",
                table: "SalesOrderParents");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrderItems_ItemId",
                table: "SalesOrderItems");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrderItems_SalesOrderParentId",
                table: "SalesOrderItems");

            migrationBuilder.AlterColumn<long>(
                name: "WareHuoseId",
                table: "SalesOrderParents",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 15, 28, 55, 592, DateTimeKind.Local).AddTicks(3511));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 15, 28, 55, 592, DateTimeKind.Local).AddTicks(3522));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 15, 28, 55, 592, DateTimeKind.Local).AddTicks(3527));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 15, 28, 55, 592, DateTimeKind.Local).AddTicks(3531));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 15, 28, 55, 592, DateTimeKind.Local).AddTicks(3535));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 15, 28, 55, 592, DateTimeKind.Local).AddTicks(3539));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 15, 28, 55, 592, DateTimeKind.Local).AddTicks(3543));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 15, 28, 55, 592, DateTimeKind.Local).AddTicks(6419));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 15, 28, 55, 592, DateTimeKind.Local).AddTicks(6441));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 15, 28, 55, 592, DateTimeKind.Local).AddTicks(5081));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 15, 28, 55, 592, DateTimeKind.Local).AddTicks(5089));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 15, 28, 55, 592, DateTimeKind.Local).AddTicks(5093));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 15, 28, 55, 592, DateTimeKind.Local).AddTicks(5096));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 15, 28, 55, 592, DateTimeKind.Local).AddTicks(5099));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 15, 28, 55, 592, DateTimeKind.Local).AddTicks(5102));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 15, 28, 55, 592, DateTimeKind.Local).AddTicks(5105));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 15, 28, 55, 592, DateTimeKind.Local).AddTicks(5107));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 15, 28, 55, 592, DateTimeKind.Local).AddTicks(5110));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 15, 28, 55, 592, DateTimeKind.Local).AddTicks(5113));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 15, 28, 55, 591, DateTimeKind.Local).AddTicks(9673));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 15, 28, 55, 592, DateTimeKind.Local).AddTicks(6037));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 15, 28, 55, 592, DateTimeKind.Local).AddTicks(6044));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 15, 28, 55, 592, DateTimeKind.Local).AddTicks(6048));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 15, 28, 55, 592, DateTimeKind.Local).AddTicks(6051));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 15, 28, 55, 592, DateTimeKind.Local).AddTicks(6054));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 15, 28, 55, 592, DateTimeKind.Local).AddTicks(6057));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 15, 28, 55, 592, DateTimeKind.Local).AddTicks(6060));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 15, 28, 55, 592, DateTimeKind.Local).AddTicks(6064));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 15, 28, 55, 592, DateTimeKind.Local).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 15, 28, 55, 592, DateTimeKind.Local).AddTicks(6070));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 15, 28, 55, 592, DateTimeKind.Local).AddTicks(1859));
        }
    }
}
