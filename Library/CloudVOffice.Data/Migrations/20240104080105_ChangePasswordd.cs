using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudVOffice.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangePasswordd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SellerRegistrations_PinCodes_PinCodeId",
                table: "SellerRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_SellerRegistrations_Sectors_SectorId",
                table: "SellerRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_SellerRegistrations_WareHouses_WareHuoseId",
                table: "SellerRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_SellerRegistrations_PinCodeId",
                table: "SellerRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_SellerRegistrations_SectorId",
                table: "SellerRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_SellerRegistrations_WareHuoseId",
                table: "SellerRegistrations");

            migrationBuilder.AlterColumn<long>(
                name: "WareHuoseId",
                table: "SellerRegistrations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "SectorId",
                table: "SellerRegistrations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "ChangePasswords",
                columns: table => new
                {
                    ChangePasswordId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OldPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RetypePassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangePasswords", x => x.ChangePasswordId);
                });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 31, 5, 385, DateTimeKind.Local).AddTicks(2405));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 31, 5, 385, DateTimeKind.Local).AddTicks(2436));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 31, 5, 385, DateTimeKind.Local).AddTicks(2444));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 31, 5, 385, DateTimeKind.Local).AddTicks(2451));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 31, 5, 385, DateTimeKind.Local).AddTicks(2458));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 31, 5, 385, DateTimeKind.Local).AddTicks(2465));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 31, 5, 385, DateTimeKind.Local).AddTicks(2472));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 31, 5, 385, DateTimeKind.Local).AddTicks(6787));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 31, 5, 385, DateTimeKind.Local).AddTicks(6913));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 31, 5, 385, DateTimeKind.Local).AddTicks(4282));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 31, 5, 385, DateTimeKind.Local).AddTicks(4290));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 31, 5, 385, DateTimeKind.Local).AddTicks(4295));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 31, 5, 385, DateTimeKind.Local).AddTicks(4300));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 31, 5, 385, DateTimeKind.Local).AddTicks(4305));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 31, 5, 385, DateTimeKind.Local).AddTicks(4310));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 31, 5, 385, DateTimeKind.Local).AddTicks(4315));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 31, 5, 385, DateTimeKind.Local).AddTicks(4321));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 31, 5, 385, DateTimeKind.Local).AddTicks(4326));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 31, 5, 385, DateTimeKind.Local).AddTicks(4331));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 31, 5, 236, DateTimeKind.Local).AddTicks(7789));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 31, 5, 385, DateTimeKind.Local).AddTicks(6144));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 31, 5, 385, DateTimeKind.Local).AddTicks(6153));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 31, 5, 385, DateTimeKind.Local).AddTicks(6159));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 31, 5, 385, DateTimeKind.Local).AddTicks(6165));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 31, 5, 385, DateTimeKind.Local).AddTicks(6170));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 31, 5, 385, DateTimeKind.Local).AddTicks(6175));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 31, 5, 385, DateTimeKind.Local).AddTicks(6181));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 31, 5, 385, DateTimeKind.Local).AddTicks(6187));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 31, 5, 385, DateTimeKind.Local).AddTicks(6192));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 31, 5, 385, DateTimeKind.Local).AddTicks(6198));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 13, 31, 5, 379, DateTimeKind.Local).AddTicks(4236));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangePasswords");

            migrationBuilder.AlterColumn<long>(
                name: "WareHuoseId",
                table: "SellerRegistrations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SectorId",
                table: "SellerRegistrations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 10, 23, 6, 0, DateTimeKind.Local).AddTicks(8486));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 10, 23, 6, 0, DateTimeKind.Local).AddTicks(8500));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 10, 23, 6, 0, DateTimeKind.Local).AddTicks(8505));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 10, 23, 6, 0, DateTimeKind.Local).AddTicks(8507));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 10, 23, 6, 0, DateTimeKind.Local).AddTicks(8509));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 10, 23, 6, 0, DateTimeKind.Local).AddTicks(8511));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 10, 23, 6, 0, DateTimeKind.Local).AddTicks(8513));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 10, 23, 6, 1, DateTimeKind.Local).AddTicks(1024));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 10, 23, 6, 1, DateTimeKind.Local).AddTicks(1027));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 10, 23, 6, 0, DateTimeKind.Local).AddTicks(9757));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 10, 23, 6, 0, DateTimeKind.Local).AddTicks(9760));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 10, 23, 6, 0, DateTimeKind.Local).AddTicks(9762));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 10, 23, 6, 0, DateTimeKind.Local).AddTicks(9764));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 10, 23, 6, 0, DateTimeKind.Local).AddTicks(9765));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 10, 23, 6, 0, DateTimeKind.Local).AddTicks(9767));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 10, 23, 6, 0, DateTimeKind.Local).AddTicks(9768));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 10, 23, 6, 0, DateTimeKind.Local).AddTicks(9770));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 10, 23, 6, 0, DateTimeKind.Local).AddTicks(9772));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 10, 23, 6, 0, DateTimeKind.Local).AddTicks(9774));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 10, 23, 5, 999, DateTimeKind.Local).AddTicks(1911));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 10, 23, 6, 1, DateTimeKind.Local).AddTicks(671));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 10, 23, 6, 1, DateTimeKind.Local).AddTicks(674));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 10, 23, 6, 1, DateTimeKind.Local).AddTicks(675));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 10, 23, 6, 1, DateTimeKind.Local).AddTicks(677));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 10, 23, 6, 1, DateTimeKind.Local).AddTicks(679));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 10, 23, 6, 1, DateTimeKind.Local).AddTicks(680));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 10, 23, 6, 1, DateTimeKind.Local).AddTicks(682));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 10, 23, 6, 1, DateTimeKind.Local).AddTicks(683));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 10, 23, 6, 1, DateTimeKind.Local).AddTicks(685));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 10, 23, 6, 1, DateTimeKind.Local).AddTicks(686));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 4, 10, 23, 6, 0, DateTimeKind.Local).AddTicks(5390));

            migrationBuilder.CreateIndex(
                name: "IX_SellerRegistrations_PinCodeId",
                table: "SellerRegistrations",
                column: "PinCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerRegistrations_SectorId",
                table: "SellerRegistrations",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerRegistrations_WareHuoseId",
                table: "SellerRegistrations",
                column: "WareHuoseId");

            migrationBuilder.AddForeignKey(
                name: "FK_SellerRegistrations_PinCodes_PinCodeId",
                table: "SellerRegistrations",
                column: "PinCodeId",
                principalTable: "PinCodes",
                principalColumn: "PinCodeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SellerRegistrations_Sectors_SectorId",
                table: "SellerRegistrations",
                column: "SectorId",
                principalTable: "Sectors",
                principalColumn: "SectorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SellerRegistrations_WareHouses_WareHuoseId",
                table: "SellerRegistrations",
                column: "WareHuoseId",
                principalTable: "WareHouses",
                principalColumn: "WareHuoseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
