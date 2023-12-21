using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CloudVOffice.Data.Migrations
{
    /// <inheritdoc />
    public partial class ForModelbuilder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 10);

            migrationBuilder.AlterColumn<long>(
                name: "UserWiseViewMapperId",
                table: "UserWiseViewMappers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "10000, 1");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 56, 58, 479, DateTimeKind.Local).AddTicks(2742));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 56, 58, 479, DateTimeKind.Local).AddTicks(2747));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 56, 58, 479, DateTimeKind.Local).AddTicks(2750));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 56, 58, 479, DateTimeKind.Local).AddTicks(2753));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 56, 58, 479, DateTimeKind.Local).AddTicks(2756));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 56, 58, 479, DateTimeKind.Local).AddTicks(2759));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 56, 58, 479, DateTimeKind.Local).AddTicks(2762));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 56, 58, 479, DateTimeKind.Local).AddTicks(3483));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 56, 58, 479, DateTimeKind.Local).AddTicks(3486));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 56, 58, 479, DateTimeKind.Local).AddTicks(3275));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 56, 58, 479, DateTimeKind.Local).AddTicks(3278));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 56, 58, 479, DateTimeKind.Local).AddTicks(3281));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 56, 58, 479, DateTimeKind.Local).AddTicks(3283));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 56, 58, 479, DateTimeKind.Local).AddTicks(3285));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 56, 58, 479, DateTimeKind.Local).AddTicks(3287));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 56, 58, 479, DateTimeKind.Local).AddTicks(3289));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 56, 58, 479, DateTimeKind.Local).AddTicks(3292));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 56, 58, 479, DateTimeKind.Local).AddTicks(3294));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 56, 58, 479, DateTimeKind.Local).AddTicks(3296));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 56, 58, 479, DateTimeKind.Local).AddTicks(226));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 56, 58, 479, DateTimeKind.Local).AddTicks(1948));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "UserWiseViewMapperId",
                table: "UserWiseViewMappers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "10000, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(8969));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(8972));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(8974));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(8976));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(8978));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(8980));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(8982));

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "ApplicationId", "ApplicationId1", "ApplicationName", "AreaName", "CreatedBy", "CreatedDate", "Deleted", "IconClass", "IconImageUrl", "IsGroup", "Parent", "UpdatedBy", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 8, null, "Email Setup", "Setup", 1L, new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(8984), false, "icon-envelop", null, true, 2, null, null, "" },
                    { 9, null, "Domain", "Setup", 1L, new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(8987), false, null, null, true, 8, null, null, "/Setup/EmailDomain/EmailDomainView" },
                    { 10, null, "Email Account", "Setup", 1L, new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(8988), false, null, null, true, 8, null, null, "/Setup/EmailAccount/EmailAccountView" }
                });

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 43, 55, 350, DateTimeKind.Local).AddTicks(26));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 43, 55, 350, DateTimeKind.Local).AddTicks(28));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(9500));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(9502));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(9504));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(9505));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(9507));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(9510));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(9512));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(9513));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(9515));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(6887));

            migrationBuilder.InsertData(
                table: "UserWiseViewMappers",
                columns: new[] { "UserWiseViewMapperId", "ApplicationId", "CreatedBy", "CreatedDate", "Deleted", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1L, 1, 1L, new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(9886), false, null, null, 1L },
                    { 2L, 2, 1L, new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(9888), false, null, null, 1L },
                    { 3L, 3, 1L, new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(9890), false, null, null, 1L },
                    { 4L, 4, 1L, new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(9892), false, null, null, 1L },
                    { 5L, 5, 1L, new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(9893), false, null, null, 1L },
                    { 6L, 6, 1L, new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(9895), false, null, null, 1L },
                    { 7L, 7, 1L, new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(9897), false, null, null, 1L }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(8304));

            migrationBuilder.InsertData(
                table: "UserWiseViewMappers",
                columns: new[] { "UserWiseViewMapperId", "ApplicationId", "CreatedBy", "CreatedDate", "Deleted", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 8L, 8, 1L, new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(9898), false, null, null, 1L },
                    { 9L, 9, 1L, new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(9900), false, null, null, 1L },
                    { 10L, 10, 1L, new DateTime(2023, 12, 18, 17, 43, 55, 349, DateTimeKind.Local).AddTicks(9901), false, null, null, 1L }
                });
        }
    }
}
