using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudVOffice.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeliveryAgentChangess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<long>(
            //    name: "BuyerOrderId",
            //    table: "DSO",
            //    type: "bigint",
            //    nullable: false,
            //    defaultValue: 0L,
            //    oldClrType: typeof(long),
            //    oldType: "bigint",
            //    oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssignedUnder",
                table: "DeliveryPartners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 19, 15, 48, 996, DateTimeKind.Local).AddTicks(2526));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 19, 15, 48, 996, DateTimeKind.Local).AddTicks(2530));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 19, 15, 48, 996, DateTimeKind.Local).AddTicks(2532));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 19, 15, 48, 996, DateTimeKind.Local).AddTicks(2534));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 19, 15, 48, 996, DateTimeKind.Local).AddTicks(2536));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 19, 15, 48, 996, DateTimeKind.Local).AddTicks(2537));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 19, 15, 48, 996, DateTimeKind.Local).AddTicks(2539));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 19, 15, 48, 996, DateTimeKind.Local).AddTicks(3618));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 19, 15, 48, 996, DateTimeKind.Local).AddTicks(3633));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 19, 15, 48, 996, DateTimeKind.Local).AddTicks(2993));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 19, 15, 48, 996, DateTimeKind.Local).AddTicks(2996));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 19, 15, 48, 996, DateTimeKind.Local).AddTicks(2997));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 19, 15, 48, 996, DateTimeKind.Local).AddTicks(2998));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 19, 15, 48, 996, DateTimeKind.Local).AddTicks(3000));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 19, 15, 48, 996, DateTimeKind.Local).AddTicks(3001));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 19, 15, 48, 996, DateTimeKind.Local).AddTicks(3002));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 19, 15, 48, 996, DateTimeKind.Local).AddTicks(3004));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 19, 15, 48, 996, DateTimeKind.Local).AddTicks(3005));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 19, 15, 48, 996, DateTimeKind.Local).AddTicks(3007));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 19, 15, 48, 996, DateTimeKind.Local).AddTicks(342));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 19, 15, 48, 996, DateTimeKind.Local).AddTicks(3396));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 19, 15, 48, 996, DateTimeKind.Local).AddTicks(3399));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 19, 15, 48, 996, DateTimeKind.Local).AddTicks(3401));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 19, 15, 48, 996, DateTimeKind.Local).AddTicks(3402));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 19, 15, 48, 996, DateTimeKind.Local).AddTicks(3404));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 19, 15, 48, 996, DateTimeKind.Local).AddTicks(3405));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 19, 15, 48, 996, DateTimeKind.Local).AddTicks(3407));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 19, 15, 48, 996, DateTimeKind.Local).AddTicks(3408));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 19, 15, 48, 996, DateTimeKind.Local).AddTicks(3441));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 19, 15, 48, 996, DateTimeKind.Local).AddTicks(3442));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 19, 15, 48, 996, DateTimeKind.Local).AddTicks(1829));

            migrationBuilder.CreateIndex(
                name: "IX_DSO_BuyerOrderId",
                table: "DSO",
                column: "BuyerOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_DSO_BuyerOrders_BuyerOrderId",
                table: "DSO",
                column: "BuyerOrderId",
                principalTable: "BuyerOrders",
                principalColumn: "BuyerOrderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DSO_BuyerOrders_BuyerOrderId",
                table: "DSO");

            migrationBuilder.DropIndex(
                name: "IX_DSO_BuyerOrderId",
                table: "DSO");

            migrationBuilder.DropColumn(
                name: "AssignedUnder",
                table: "DeliveryPartners");

            migrationBuilder.AlterColumn<long>(
                name: "BuyerOrderId",
                table: "DSO",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4126));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4131));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4132));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4134));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4136));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4138));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4140));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(5284));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(5310));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4621));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4623));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4625));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4626));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4627));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4629));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4630));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4631));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4633));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(4634));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(1730));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(5044));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(5047));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(5048));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(5050));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(5051));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(5052));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(5054));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(5055));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(5057));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(5058));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 14, 7, 41, 604, DateTimeKind.Local).AddTicks(3266));
        }
    }
}
