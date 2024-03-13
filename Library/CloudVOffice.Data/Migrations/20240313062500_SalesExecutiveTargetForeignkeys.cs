using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudVOffice.Data.Migrations
{
    /// <inheritdoc />
    public partial class SalesExecutiveTargetForeignkeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SectorId",
                table: "SalesExecutiveTargets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "SalesExecutiveRegistrationId",
                table: "SalesExecutiveTargets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "MonthId",
                table: "SalesExecutiveTargets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "SalesExecutiveTargets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 54, 58, 42, DateTimeKind.Local).AddTicks(3958));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 54, 58, 42, DateTimeKind.Local).AddTicks(3973));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 54, 58, 42, DateTimeKind.Local).AddTicks(3978));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 54, 58, 42, DateTimeKind.Local).AddTicks(3983));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 54, 58, 42, DateTimeKind.Local).AddTicks(3987));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 54, 58, 42, DateTimeKind.Local).AddTicks(3991));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 54, 58, 42, DateTimeKind.Local).AddTicks(3995));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 54, 58, 42, DateTimeKind.Local).AddTicks(7223));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 54, 58, 42, DateTimeKind.Local).AddTicks(7253));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 54, 58, 42, DateTimeKind.Local).AddTicks(5196));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 54, 58, 42, DateTimeKind.Local).AddTicks(5204));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 54, 58, 42, DateTimeKind.Local).AddTicks(5207));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 54, 58, 42, DateTimeKind.Local).AddTicks(5210));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 54, 58, 42, DateTimeKind.Local).AddTicks(5213));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 54, 58, 42, DateTimeKind.Local).AddTicks(5215));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 54, 58, 42, DateTimeKind.Local).AddTicks(5218));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 54, 58, 42, DateTimeKind.Local).AddTicks(5220));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 54, 58, 42, DateTimeKind.Local).AddTicks(5223));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 54, 58, 42, DateTimeKind.Local).AddTicks(5225));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 54, 58, 41, DateTimeKind.Local).AddTicks(4027));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 54, 58, 42, DateTimeKind.Local).AddTicks(6663));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 54, 58, 42, DateTimeKind.Local).AddTicks(6672));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 54, 58, 42, DateTimeKind.Local).AddTicks(6675));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 54, 58, 42, DateTimeKind.Local).AddTicks(6678));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 54, 58, 42, DateTimeKind.Local).AddTicks(6681));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 54, 58, 42, DateTimeKind.Local).AddTicks(6684));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 54, 58, 42, DateTimeKind.Local).AddTicks(6687));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 54, 58, 42, DateTimeKind.Local).AddTicks(6690));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 54, 58, 42, DateTimeKind.Local).AddTicks(6693));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 54, 58, 42, DateTimeKind.Local).AddTicks(6696));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 54, 58, 42, DateTimeKind.Local).AddTicks(1164));

            migrationBuilder.CreateIndex(
                name: "IX_SalesExecutiveTargets_CategoryId",
                table: "SalesExecutiveTargets",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesExecutiveTargets_MonthId",
                table: "SalesExecutiveTargets",
                column: "MonthId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesExecutiveTargets_SalesExecutiveRegistrationId",
                table: "SalesExecutiveTargets",
                column: "SalesExecutiveRegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesExecutiveTargets_SectorId",
                table: "SalesExecutiveTargets",
                column: "SectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesExecutiveTargets_Categories_CategoryId",
                table: "SalesExecutiveTargets",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesExecutiveTargets_Months_MonthId",
                table: "SalesExecutiveTargets",
                column: "MonthId",
                principalTable: "Months",
                principalColumn: "MonthId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesExecutiveTargets_SalesExecutiveRegistrations_SalesExecutiveRegistrationId",
                table: "SalesExecutiveTargets",
                column: "SalesExecutiveRegistrationId",
                principalTable: "SalesExecutiveRegistrations",
                principalColumn: "SalesExecutiveRegistrationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesExecutiveTargets_Sectors_SectorId",
                table: "SalesExecutiveTargets",
                column: "SectorId",
                principalTable: "Sectors",
                principalColumn: "SectorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesExecutiveTargets_Categories_CategoryId",
                table: "SalesExecutiveTargets");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesExecutiveTargets_Months_MonthId",
                table: "SalesExecutiveTargets");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesExecutiveTargets_SalesExecutiveRegistrations_SalesExecutiveRegistrationId",
                table: "SalesExecutiveTargets");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesExecutiveTargets_Sectors_SectorId",
                table: "SalesExecutiveTargets");

            migrationBuilder.DropIndex(
                name: "IX_SalesExecutiveTargets_CategoryId",
                table: "SalesExecutiveTargets");

            migrationBuilder.DropIndex(
                name: "IX_SalesExecutiveTargets_MonthId",
                table: "SalesExecutiveTargets");

            migrationBuilder.DropIndex(
                name: "IX_SalesExecutiveTargets_SalesExecutiveRegistrationId",
                table: "SalesExecutiveTargets");

            migrationBuilder.DropIndex(
                name: "IX_SalesExecutiveTargets_SectorId",
                table: "SalesExecutiveTargets");

            migrationBuilder.AlterColumn<long>(
                name: "SectorId",
                table: "SalesExecutiveTargets",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "SalesExecutiveRegistrationId",
                table: "SalesExecutiveTargets",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "MonthId",
                table: "SalesExecutiveTargets",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CategoryId",
                table: "SalesExecutiveTargets",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 18, 40, 553, DateTimeKind.Local).AddTicks(8783));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 18, 40, 553, DateTimeKind.Local).AddTicks(8786));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 18, 40, 553, DateTimeKind.Local).AddTicks(8788));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 18, 40, 553, DateTimeKind.Local).AddTicks(8790));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 18, 40, 553, DateTimeKind.Local).AddTicks(8792));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 18, 40, 553, DateTimeKind.Local).AddTicks(8793));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 18, 40, 553, DateTimeKind.Local).AddTicks(8798));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 18, 40, 553, DateTimeKind.Local).AddTicks(9822));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 18, 40, 553, DateTimeKind.Local).AddTicks(9824));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 18, 40, 553, DateTimeKind.Local).AddTicks(9270));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 18, 40, 553, DateTimeKind.Local).AddTicks(9272));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 18, 40, 553, DateTimeKind.Local).AddTicks(9274));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 18, 40, 553, DateTimeKind.Local).AddTicks(9275));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 18, 40, 553, DateTimeKind.Local).AddTicks(9276));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 18, 40, 553, DateTimeKind.Local).AddTicks(9277));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 18, 40, 553, DateTimeKind.Local).AddTicks(9279));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 18, 40, 553, DateTimeKind.Local).AddTicks(9280));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 18, 40, 553, DateTimeKind.Local).AddTicks(9281));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 18, 40, 553, DateTimeKind.Local).AddTicks(9283));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 18, 40, 553, DateTimeKind.Local).AddTicks(2692));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 18, 40, 553, DateTimeKind.Local).AddTicks(9670));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 18, 40, 553, DateTimeKind.Local).AddTicks(9672));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 18, 40, 553, DateTimeKind.Local).AddTicks(9673));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 18, 40, 553, DateTimeKind.Local).AddTicks(9674));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 18, 40, 553, DateTimeKind.Local).AddTicks(9676));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 18, 40, 553, DateTimeKind.Local).AddTicks(9677));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 18, 40, 553, DateTimeKind.Local).AddTicks(9679));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 18, 40, 553, DateTimeKind.Local).AddTicks(9680));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 18, 40, 553, DateTimeKind.Local).AddTicks(9681));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 18, 40, 553, DateTimeKind.Local).AddTicks(9683));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 13, 11, 18, 40, 553, DateTimeKind.Local).AddTicks(7441));
        }
    }
}
