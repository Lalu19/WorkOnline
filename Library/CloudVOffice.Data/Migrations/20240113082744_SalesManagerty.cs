using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudVOffice.Data.Migrations
{
    /// <inheritdoc />
    public partial class SalesManagerty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesManagerTargets_Brands_BrandId",
                table: "SalesManagerTargets");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesManagerTargets_States_StateId",
                table: "SalesManagerTargets");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesManagerTargets_Units_UnitId",
                table: "SalesManagerTargets");

            migrationBuilder.DropIndex(
                name: "IX_SalesManagerTargets_BrandId",
                table: "SalesManagerTargets");

            migrationBuilder.DropIndex(
                name: "IX_SalesManagerTargets_StateId",
                table: "SalesManagerTargets");

            migrationBuilder.DropIndex(
                name: "IX_SalesManagerTargets_UnitId",
                table: "SalesManagerTargets");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "SalesManagerTargets");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "SalesManagerTargets");

            migrationBuilder.AlterColumn<long>(
                name: "BrandId",
                table: "SalesManagerTargets",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 13, 57, 44, 83, DateTimeKind.Local).AddTicks(4429));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 13, 57, 44, 83, DateTimeKind.Local).AddTicks(4449));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 13, 57, 44, 83, DateTimeKind.Local).AddTicks(4454));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 13, 57, 44, 83, DateTimeKind.Local).AddTicks(4457));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 13, 57, 44, 83, DateTimeKind.Local).AddTicks(4462));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 13, 57, 44, 83, DateTimeKind.Local).AddTicks(4465));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 13, 57, 44, 83, DateTimeKind.Local).AddTicks(4468));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 13, 57, 44, 83, DateTimeKind.Local).AddTicks(7389));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 13, 57, 44, 83, DateTimeKind.Local).AddTicks(7414));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 13, 57, 44, 83, DateTimeKind.Local).AddTicks(5655));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 13, 57, 44, 83, DateTimeKind.Local).AddTicks(5665));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 13, 57, 44, 83, DateTimeKind.Local).AddTicks(5667));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 13, 57, 44, 83, DateTimeKind.Local).AddTicks(5668));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 13, 57, 44, 83, DateTimeKind.Local).AddTicks(5670));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 13, 57, 44, 83, DateTimeKind.Local).AddTicks(5672));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 13, 57, 44, 83, DateTimeKind.Local).AddTicks(5674));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 13, 57, 44, 83, DateTimeKind.Local).AddTicks(5676));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 13, 57, 44, 83, DateTimeKind.Local).AddTicks(5677));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 13, 57, 44, 83, DateTimeKind.Local).AddTicks(5679));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 13, 57, 44, 81, DateTimeKind.Local).AddTicks(825));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 13, 57, 44, 83, DateTimeKind.Local).AddTicks(6936));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 13, 57, 44, 83, DateTimeKind.Local).AddTicks(6943));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 13, 57, 44, 83, DateTimeKind.Local).AddTicks(6945));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 13, 57, 44, 83, DateTimeKind.Local).AddTicks(6947));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 13, 57, 44, 83, DateTimeKind.Local).AddTicks(6949));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 13, 57, 44, 83, DateTimeKind.Local).AddTicks(6951));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 13, 57, 44, 83, DateTimeKind.Local).AddTicks(6953));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 13, 57, 44, 83, DateTimeKind.Local).AddTicks(6955));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 13, 57, 44, 83, DateTimeKind.Local).AddTicks(6956));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 13, 57, 44, 83, DateTimeKind.Local).AddTicks(6962));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 13, 57, 44, 83, DateTimeKind.Local).AddTicks(943));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "BrandId",
                table: "SalesManagerTargets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "StateId",
                table: "SalesManagerTargets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UnitId",
                table: "SalesManagerTargets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 14, 51, 30, 976, DateTimeKind.Local).AddTicks(7138));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 14, 51, 30, 976, DateTimeKind.Local).AddTicks(7146));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 14, 51, 30, 976, DateTimeKind.Local).AddTicks(7150));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 14, 51, 30, 976, DateTimeKind.Local).AddTicks(7153));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 14, 51, 30, 976, DateTimeKind.Local).AddTicks(7155));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 14, 51, 30, 976, DateTimeKind.Local).AddTicks(7158));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 14, 51, 30, 976, DateTimeKind.Local).AddTicks(7160));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 14, 51, 30, 977, DateTimeKind.Local).AddTicks(104));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 14, 51, 30, 977, DateTimeKind.Local).AddTicks(126));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 14, 51, 30, 976, DateTimeKind.Local).AddTicks(8689));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 14, 51, 30, 976, DateTimeKind.Local).AddTicks(8695));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 14, 51, 30, 976, DateTimeKind.Local).AddTicks(8697));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 14, 51, 30, 976, DateTimeKind.Local).AddTicks(8699));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 14, 51, 30, 976, DateTimeKind.Local).AddTicks(8701));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 14, 51, 30, 976, DateTimeKind.Local).AddTicks(8703));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 14, 51, 30, 976, DateTimeKind.Local).AddTicks(8705));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 14, 51, 30, 976, DateTimeKind.Local).AddTicks(8708));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 14, 51, 30, 976, DateTimeKind.Local).AddTicks(8710));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 14, 51, 30, 976, DateTimeKind.Local).AddTicks(8711));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 14, 51, 30, 976, DateTimeKind.Local).AddTicks(2148));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 14, 51, 30, 976, DateTimeKind.Local).AddTicks(9742));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 14, 51, 30, 976, DateTimeKind.Local).AddTicks(9748));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 14, 51, 30, 976, DateTimeKind.Local).AddTicks(9751));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 14, 51, 30, 976, DateTimeKind.Local).AddTicks(9753));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 14, 51, 30, 976, DateTimeKind.Local).AddTicks(9755));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 14, 51, 30, 976, DateTimeKind.Local).AddTicks(9757));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 14, 51, 30, 976, DateTimeKind.Local).AddTicks(9759));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 14, 51, 30, 976, DateTimeKind.Local).AddTicks(9761));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 14, 51, 30, 976, DateTimeKind.Local).AddTicks(9763));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 14, 51, 30, 976, DateTimeKind.Local).AddTicks(9765));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 12, 14, 51, 30, 976, DateTimeKind.Local).AddTicks(5361));

            migrationBuilder.CreateIndex(
                name: "IX_SalesManagerTargets_BrandId",
                table: "SalesManagerTargets",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesManagerTargets_StateId",
                table: "SalesManagerTargets",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesManagerTargets_UnitId",
                table: "SalesManagerTargets",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesManagerTargets_Brands_BrandId",
                table: "SalesManagerTargets",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesManagerTargets_States_StateId",
                table: "SalesManagerTargets",
                column: "StateId",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesManagerTargets_Units_UnitId",
                table: "SalesManagerTargets",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
