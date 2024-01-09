using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudVOffice.Data.Migrations
{
    /// <inheritdoc />
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
    public partial class Sellersss : Migration
========
    public partial class sss : Migration
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
========
            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                });

>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs
            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
                value: new DateTime(2024, 1, 9, 15, 32, 58, 310, DateTimeKind.Local).AddTicks(7715));
========
                value: new DateTime(2024, 1, 9, 14, 57, 7, 557, DateTimeKind.Local).AddTicks(5638));
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
                value: new DateTime(2024, 1, 9, 15, 32, 58, 310, DateTimeKind.Local).AddTicks(7718));
========
                value: new DateTime(2024, 1, 9, 14, 57, 7, 557, DateTimeKind.Local).AddTicks(5643));
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
                value: new DateTime(2024, 1, 9, 15, 32, 58, 310, DateTimeKind.Local).AddTicks(7720));
========
                value: new DateTime(2024, 1, 9, 14, 57, 7, 557, DateTimeKind.Local).AddTicks(5645));
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
                value: new DateTime(2024, 1, 9, 15, 32, 58, 310, DateTimeKind.Local).AddTicks(7722));
========
                value: new DateTime(2024, 1, 9, 14, 57, 7, 557, DateTimeKind.Local).AddTicks(5647));
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
                value: new DateTime(2024, 1, 9, 15, 32, 58, 310, DateTimeKind.Local).AddTicks(7724));
========
                value: new DateTime(2024, 1, 9, 14, 57, 7, 557, DateTimeKind.Local).AddTicks(5649));
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
                value: new DateTime(2024, 1, 9, 15, 32, 58, 310, DateTimeKind.Local).AddTicks(7725));
========
                value: new DateTime(2024, 1, 9, 14, 57, 7, 557, DateTimeKind.Local).AddTicks(5651));
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
                value: new DateTime(2024, 1, 9, 15, 32, 58, 310, DateTimeKind.Local).AddTicks(7727));
========
                value: new DateTime(2024, 1, 9, 14, 57, 7, 557, DateTimeKind.Local).AddTicks(5655));
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
                value: new DateTime(2024, 1, 9, 15, 32, 58, 310, DateTimeKind.Local).AddTicks(8171));
========
                value: new DateTime(2024, 1, 9, 14, 57, 7, 557, DateTimeKind.Local).AddTicks(7046));
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
                value: new DateTime(2024, 1, 9, 15, 32, 58, 310, DateTimeKind.Local).AddTicks(8173));
========
                value: new DateTime(2024, 1, 9, 14, 57, 7, 557, DateTimeKind.Local).AddTicks(7050));
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
                value: new DateTime(2024, 1, 9, 15, 32, 58, 310, DateTimeKind.Local).AddTicks(7900));
========
                value: new DateTime(2024, 1, 9, 14, 57, 7, 557, DateTimeKind.Local).AddTicks(6246));
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
                value: new DateTime(2024, 1, 9, 15, 32, 58, 310, DateTimeKind.Local).AddTicks(7902));
========
                value: new DateTime(2024, 1, 9, 14, 57, 7, 557, DateTimeKind.Local).AddTicks(6250));
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
                value: new DateTime(2024, 1, 9, 15, 32, 58, 310, DateTimeKind.Local).AddTicks(7904));
========
                value: new DateTime(2024, 1, 9, 14, 57, 7, 557, DateTimeKind.Local).AddTicks(6252));
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
                value: new DateTime(2024, 1, 9, 15, 32, 58, 310, DateTimeKind.Local).AddTicks(7905));
========
                value: new DateTime(2024, 1, 9, 14, 57, 7, 557, DateTimeKind.Local).AddTicks(6253));
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
                value: new DateTime(2024, 1, 9, 15, 32, 58, 310, DateTimeKind.Local).AddTicks(7906));
========
                value: new DateTime(2024, 1, 9, 14, 57, 7, 557, DateTimeKind.Local).AddTicks(6254));
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
                value: new DateTime(2024, 1, 9, 15, 32, 58, 310, DateTimeKind.Local).AddTicks(7907));
========
                value: new DateTime(2024, 1, 9, 14, 57, 7, 557, DateTimeKind.Local).AddTicks(6256));
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
                value: new DateTime(2024, 1, 9, 15, 32, 58, 310, DateTimeKind.Local).AddTicks(7908));
========
                value: new DateTime(2024, 1, 9, 14, 57, 7, 557, DateTimeKind.Local).AddTicks(6257));
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
                value: new DateTime(2024, 1, 9, 15, 32, 58, 310, DateTimeKind.Local).AddTicks(7909));
========
                value: new DateTime(2024, 1, 9, 14, 57, 7, 557, DateTimeKind.Local).AddTicks(6258));
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
                value: new DateTime(2024, 1, 9, 15, 32, 58, 310, DateTimeKind.Local).AddTicks(7910));
========
                value: new DateTime(2024, 1, 9, 14, 57, 7, 557, DateTimeKind.Local).AddTicks(6261));
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
                value: new DateTime(2024, 1, 9, 15, 32, 58, 310, DateTimeKind.Local).AddTicks(7911));
========
                value: new DateTime(2024, 1, 9, 14, 57, 7, 557, DateTimeKind.Local).AddTicks(6262));
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
                value: new DateTime(2024, 1, 9, 15, 32, 58, 310, DateTimeKind.Local).AddTicks(6481));
========
                value: new DateTime(2024, 1, 9, 14, 57, 7, 557, DateTimeKind.Local).AddTicks(2857));
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
                value: new DateTime(2024, 1, 9, 15, 32, 58, 310, DateTimeKind.Local).AddTicks(8087));
========
                value: new DateTime(2024, 1, 9, 14, 57, 7, 557, DateTimeKind.Local).AddTicks(6770));
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
                value: new DateTime(2024, 1, 9, 15, 32, 58, 310, DateTimeKind.Local).AddTicks(8089));
========
                value: new DateTime(2024, 1, 9, 14, 57, 7, 557, DateTimeKind.Local).AddTicks(6774));
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
                value: new DateTime(2024, 1, 9, 15, 32, 58, 310, DateTimeKind.Local).AddTicks(8091));
========
                value: new DateTime(2024, 1, 9, 14, 57, 7, 557, DateTimeKind.Local).AddTicks(6776));
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
                value: new DateTime(2024, 1, 9, 15, 32, 58, 310, DateTimeKind.Local).AddTicks(8092));
========
                value: new DateTime(2024, 1, 9, 14, 57, 7, 557, DateTimeKind.Local).AddTicks(6778));
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
                value: new DateTime(2024, 1, 9, 15, 32, 58, 310, DateTimeKind.Local).AddTicks(8094));
========
                value: new DateTime(2024, 1, 9, 14, 57, 7, 557, DateTimeKind.Local).AddTicks(6780));
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
                value: new DateTime(2024, 1, 9, 15, 32, 58, 310, DateTimeKind.Local).AddTicks(8095));
========
                value: new DateTime(2024, 1, 9, 14, 57, 7, 557, DateTimeKind.Local).AddTicks(6782));
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
                value: new DateTime(2024, 1, 9, 15, 32, 58, 310, DateTimeKind.Local).AddTicks(8096));
========
                value: new DateTime(2024, 1, 9, 14, 57, 7, 557, DateTimeKind.Local).AddTicks(6784));
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
                value: new DateTime(2024, 1, 9, 15, 32, 58, 310, DateTimeKind.Local).AddTicks(8097));
========
                value: new DateTime(2024, 1, 9, 14, 57, 7, 557, DateTimeKind.Local).AddTicks(6785));
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
                value: new DateTime(2024, 1, 9, 15, 32, 58, 310, DateTimeKind.Local).AddTicks(8098));
========
                value: new DateTime(2024, 1, 9, 14, 57, 7, 557, DateTimeKind.Local).AddTicks(6790));
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
                value: new DateTime(2024, 1, 9, 15, 32, 58, 310, DateTimeKind.Local).AddTicks(8100));
========
                value: new DateTime(2024, 1, 9, 14, 57, 7, 557, DateTimeKind.Local).AddTicks(6792));
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
                value: new DateTime(2024, 1, 9, 15, 32, 58, 310, DateTimeKind.Local).AddTicks(7409));
========
                value: new DateTime(2024, 1, 9, 14, 57, 7, 557, DateTimeKind.Local).AddTicks(4629));
>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
<<<<<<<< HEAD:Library/CloudVOffice.Data/Migrations/20240109100258_Sellersss.cs
========
            migrationBuilder.DropTable(
                name: "States");

>>>>>>>> 57ef7dca0f122226059992e1ad0935e9d2d5d10d:Library/CloudVOffice.Data/Migrations/20240109092708_sss.cs
            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 5, 10, 25, 34, 154, DateTimeKind.Local).AddTicks(6986));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 5, 10, 25, 34, 154, DateTimeKind.Local).AddTicks(6988));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 5, 10, 25, 34, 154, DateTimeKind.Local).AddTicks(6991));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 5, 10, 25, 34, 154, DateTimeKind.Local).AddTicks(6993));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 5, 10, 25, 34, 154, DateTimeKind.Local).AddTicks(6995));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 5, 10, 25, 34, 154, DateTimeKind.Local).AddTicks(6996));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 5, 10, 25, 34, 154, DateTimeKind.Local).AddTicks(6998));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 5, 10, 25, 34, 154, DateTimeKind.Local).AddTicks(7531));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 5, 10, 25, 34, 154, DateTimeKind.Local).AddTicks(7533));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 5, 10, 25, 34, 154, DateTimeKind.Local).AddTicks(7257));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 5, 10, 25, 34, 154, DateTimeKind.Local).AddTicks(7258));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 5, 10, 25, 34, 154, DateTimeKind.Local).AddTicks(7259));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 5, 10, 25, 34, 154, DateTimeKind.Local).AddTicks(7261));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 5, 10, 25, 34, 154, DateTimeKind.Local).AddTicks(7262));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 5, 10, 25, 34, 154, DateTimeKind.Local).AddTicks(7263));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 5, 10, 25, 34, 154, DateTimeKind.Local).AddTicks(7264));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 5, 10, 25, 34, 154, DateTimeKind.Local).AddTicks(7265));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 5, 10, 25, 34, 154, DateTimeKind.Local).AddTicks(7266));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 5, 10, 25, 34, 154, DateTimeKind.Local).AddTicks(7267));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 5, 10, 25, 34, 153, DateTimeKind.Local).AddTicks(9789));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 5, 10, 25, 34, 154, DateTimeKind.Local).AddTicks(7426));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 5, 10, 25, 34, 154, DateTimeKind.Local).AddTicks(7428));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 5, 10, 25, 34, 154, DateTimeKind.Local).AddTicks(7430));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 5, 10, 25, 34, 154, DateTimeKind.Local).AddTicks(7431));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 5, 10, 25, 34, 154, DateTimeKind.Local).AddTicks(7432));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 5, 10, 25, 34, 154, DateTimeKind.Local).AddTicks(7433));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 5, 10, 25, 34, 154, DateTimeKind.Local).AddTicks(7435));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 5, 10, 25, 34, 154, DateTimeKind.Local).AddTicks(7436));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 5, 10, 25, 34, 154, DateTimeKind.Local).AddTicks(7437));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 5, 10, 25, 34, 154, DateTimeKind.Local).AddTicks(7439));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 5, 10, 25, 34, 154, DateTimeKind.Local).AddTicks(6087));
        }
    }
}
