using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudVOffice.Data.Migrations
{
    /// <inheritdoc />
    public partial class Pincodemapp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PinCodeMappings",
                columns: table => new
                {
                    PinCodeMappingId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PinCodeId = table.Column<long>(type: "bigint", nullable: false),
                    WareHuoseId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PinCodeMappings", x => x.PinCodeMappingId);
                    table.ForeignKey(
                        name: "FK_PinCodeMappings_PinCodes_PinCodeId",
                        column: x => x.PinCodeId,
                        principalTable: "PinCodes",
                        principalColumn: "PinCodeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PinCodeMappings_WareHouses_WareHuoseId",
                        column: x => x.WareHuoseId,
                        principalTable: "WareHouses",
                        principalColumn: "WareHuoseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(7364));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(7372));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(7375));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(7378));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(7381));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(7384));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(7387));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(7389));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(7392));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(7395));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(9267));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(9272));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(8135));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(8140));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(8143));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(8145));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(8147));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(8150));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(8152));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(8154));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(8156));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(8158));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(2929));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(8978));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(8983));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(8985));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(8987));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(8989));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(8992));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(8994));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(8996));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(8998));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(9001));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 18, 6, 58, 394, DateTimeKind.Local).AddTicks(5977));

            migrationBuilder.CreateIndex(
                name: "IX_PinCodeMappings_PinCodeId",
                table: "PinCodeMappings",
                column: "PinCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PinCodeMappings_WareHuoseId",
                table: "PinCodeMappings",
                column: "WareHuoseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PinCodeMappings");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(7649));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(7654));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(7657));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(7660));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(7663));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(7666));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(7669));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(7671));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(7674));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(7677));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(9070));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(9073));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(8308));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(8311));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(8314));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(8316));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(8318));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(8320));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(8322));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(8324));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(8326));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(8329));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 550, DateTimeKind.Local).AddTicks(7216));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(8869));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(8873));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(8875));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(8877));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(8880));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(8882));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(8884));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(8886));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(8889));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(8891));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 12, 9, 34, 551, DateTimeKind.Local).AddTicks(5622));
        }
    }
}
