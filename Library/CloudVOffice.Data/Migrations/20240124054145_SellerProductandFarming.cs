using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudVOffice.Data.Migrations
{
    /// <inheritdoc />
    public partial class SellerProductandFarming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SellerFarmingProducts",
                columns: table => new
                {
                    SellerFarmingProductId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubCategory1Id = table.Column<int>(type: "int", nullable: false),
                    SubCategory2Id = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinQty = table.Column<double>(type: "float", nullable: true),
                    GSTId = table.Column<long>(type: "bigint", nullable: false),
                    HSN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    QtyPerKg = table.Column<double>(type: "float", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<long>(type: "bigint", nullable: false),
                    ProductWeight = table.Column<double>(type: "float", nullable: false),
                    UnitId = table.Column<long>(type: "bigint", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarvestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerFarmingProducts", x => x.SellerFarmingProductId);
                    table.ForeignKey(
                        name: "FK_SellerFarmingProducts_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellerFarmingProducts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellerFarmingProducts_GSTs_GSTId",
                        column: x => x.GSTId,
                        principalTable: "GSTs",
                        principalColumn: "GSTId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellerFarmingProducts_SubCategories1_SubCategory1Id",
                        column: x => x.SubCategory1Id,
                        principalTable: "SubCategories1",
                        principalColumn: "SubCategory1Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellerFarmingProducts_SubCategories2_SubCategory2Id",
                        column: x => x.SubCategory2Id,
                        principalTable: "SubCategories2",
                        principalColumn: "SubCategory2Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellerFarmingProducts_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellerProductEntrys",
                columns: table => new
                {
                    SellerProductEntryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerProductCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubCategory1Id = table.Column<int>(type: "int", nullable: false),
                    SubCategory2Id = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HSN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<long>(type: "bigint", nullable: false),
                    ProductWeight = table.Column<double>(type: "float", nullable: false),
                    UnitId = table.Column<long>(type: "bigint", nullable: false),
                    CaseWeight = table.Column<double>(type: "float", nullable: true),
                    UnitPerCase = table.Column<double>(type: "float", nullable: true),
                    ManufactureDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MRP = table.Column<double>(type: "float", nullable: false),
                    MRPCaseCost = table.Column<double>(type: "float", nullable: true),
                    SalesCost = table.Column<double>(type: "float", nullable: false),
                    SalesCaseCost = table.Column<double>(type: "float", nullable: true),
                    GSTId = table.Column<long>(type: "bigint", nullable: false),
                    HandlingTypeId = table.Column<int>(type: "int", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerProductEntrys", x => x.SellerProductEntryId);
                    table.ForeignKey(
                        name: "FK_SellerProductEntrys_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellerProductEntrys_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellerProductEntrys_GSTs_GSTId",
                        column: x => x.GSTId,
                        principalTable: "GSTs",
                        principalColumn: "GSTId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellerProductEntrys_HandlingTypes_HandlingTypeId",
                        column: x => x.HandlingTypeId,
                        principalTable: "HandlingTypes",
                        principalColumn: "HandlingTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellerProductEntrys_SubCategories1_SubCategory1Id",
                        column: x => x.SubCategory1Id,
                        principalTable: "SubCategories1",
                        principalColumn: "SubCategory1Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellerProductEntrys_SubCategories2_SubCategory2Id",
                        column: x => x.SubCategory2Id,
                        principalTable: "SubCategories2",
                        principalColumn: "SubCategory2Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellerProductEntrys_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 24, 11, 11, 44, 936, DateTimeKind.Local).AddTicks(1488));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 24, 11, 11, 44, 936, DateTimeKind.Local).AddTicks(1495));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 24, 11, 11, 44, 936, DateTimeKind.Local).AddTicks(1498));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 24, 11, 11, 44, 936, DateTimeKind.Local).AddTicks(1500));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 24, 11, 11, 44, 936, DateTimeKind.Local).AddTicks(1502));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 24, 11, 11, 44, 936, DateTimeKind.Local).AddTicks(1504));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 24, 11, 11, 44, 936, DateTimeKind.Local).AddTicks(1506));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 24, 11, 11, 44, 936, DateTimeKind.Local).AddTicks(3048));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 24, 11, 11, 44, 936, DateTimeKind.Local).AddTicks(3063));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 24, 11, 11, 44, 936, DateTimeKind.Local).AddTicks(2064));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 24, 11, 11, 44, 936, DateTimeKind.Local).AddTicks(2069));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 24, 11, 11, 44, 936, DateTimeKind.Local).AddTicks(2119));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 24, 11, 11, 44, 936, DateTimeKind.Local).AddTicks(2121));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 24, 11, 11, 44, 936, DateTimeKind.Local).AddTicks(2122));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 24, 11, 11, 44, 936, DateTimeKind.Local).AddTicks(2124));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 24, 11, 11, 44, 936, DateTimeKind.Local).AddTicks(2125));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 24, 11, 11, 44, 936, DateTimeKind.Local).AddTicks(2127));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 24, 11, 11, 44, 936, DateTimeKind.Local).AddTicks(2128));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 24, 11, 11, 44, 936, DateTimeKind.Local).AddTicks(2130));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 24, 11, 11, 44, 935, DateTimeKind.Local).AddTicks(8022));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 24, 11, 11, 44, 936, DateTimeKind.Local).AddTicks(2796));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 24, 11, 11, 44, 936, DateTimeKind.Local).AddTicks(2800));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 24, 11, 11, 44, 936, DateTimeKind.Local).AddTicks(2802));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 24, 11, 11, 44, 936, DateTimeKind.Local).AddTicks(2804));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 24, 11, 11, 44, 936, DateTimeKind.Local).AddTicks(2806));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 24, 11, 11, 44, 936, DateTimeKind.Local).AddTicks(2807));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 24, 11, 11, 44, 936, DateTimeKind.Local).AddTicks(2809));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 24, 11, 11, 44, 936, DateTimeKind.Local).AddTicks(2810));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 24, 11, 11, 44, 936, DateTimeKind.Local).AddTicks(2812));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 24, 11, 11, 44, 936, DateTimeKind.Local).AddTicks(2813));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 24, 11, 11, 44, 936, DateTimeKind.Local).AddTicks(1));

            migrationBuilder.CreateIndex(
                name: "IX_SellerFarmingProducts_BrandId",
                table: "SellerFarmingProducts",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerFarmingProducts_CategoryId",
                table: "SellerFarmingProducts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerFarmingProducts_GSTId",
                table: "SellerFarmingProducts",
                column: "GSTId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerFarmingProducts_SubCategory1Id",
                table: "SellerFarmingProducts",
                column: "SubCategory1Id");

            migrationBuilder.CreateIndex(
                name: "IX_SellerFarmingProducts_SubCategory2Id",
                table: "SellerFarmingProducts",
                column: "SubCategory2Id");

            migrationBuilder.CreateIndex(
                name: "IX_SellerFarmingProducts_UnitId",
                table: "SellerFarmingProducts",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerProductEntrys_BrandId",
                table: "SellerProductEntrys",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerProductEntrys_CategoryId",
                table: "SellerProductEntrys",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerProductEntrys_GSTId",
                table: "SellerProductEntrys",
                column: "GSTId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerProductEntrys_HandlingTypeId",
                table: "SellerProductEntrys",
                column: "HandlingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerProductEntrys_SubCategory1Id",
                table: "SellerProductEntrys",
                column: "SubCategory1Id");

            migrationBuilder.CreateIndex(
                name: "IX_SellerProductEntrys_SubCategory2Id",
                table: "SellerProductEntrys",
                column: "SubCategory2Id");

            migrationBuilder.CreateIndex(
                name: "IX_SellerProductEntrys_UnitId",
                table: "SellerProductEntrys",
                column: "UnitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SellerFarmingProducts");

            migrationBuilder.DropTable(
                name: "SellerProductEntrys");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 16, 17, 12, 402, DateTimeKind.Local).AddTicks(4391));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 16, 17, 12, 402, DateTimeKind.Local).AddTicks(4397));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 16, 17, 12, 402, DateTimeKind.Local).AddTicks(4399));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 16, 17, 12, 402, DateTimeKind.Local).AddTicks(4402));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 16, 17, 12, 402, DateTimeKind.Local).AddTicks(4404));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 16, 17, 12, 402, DateTimeKind.Local).AddTicks(4406));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 16, 17, 12, 402, DateTimeKind.Local).AddTicks(4408));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 16, 17, 12, 402, DateTimeKind.Local).AddTicks(5875));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 16, 17, 12, 402, DateTimeKind.Local).AddTicks(5880));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 16, 17, 12, 402, DateTimeKind.Local).AddTicks(5036));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 16, 17, 12, 402, DateTimeKind.Local).AddTicks(5039));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 16, 17, 12, 402, DateTimeKind.Local).AddTicks(5041));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 16, 17, 12, 402, DateTimeKind.Local).AddTicks(5042));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 16, 17, 12, 402, DateTimeKind.Local).AddTicks(5044));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 16, 17, 12, 402, DateTimeKind.Local).AddTicks(5045));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 16, 17, 12, 402, DateTimeKind.Local).AddTicks(5047));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 16, 17, 12, 402, DateTimeKind.Local).AddTicks(5048));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 16, 17, 12, 402, DateTimeKind.Local).AddTicks(5049));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 16, 17, 12, 402, DateTimeKind.Local).AddTicks(5051));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 16, 17, 12, 402, DateTimeKind.Local).AddTicks(1310));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 16, 17, 12, 402, DateTimeKind.Local).AddTicks(5604));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 16, 17, 12, 402, DateTimeKind.Local).AddTicks(5608));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 16, 17, 12, 402, DateTimeKind.Local).AddTicks(5611));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 16, 17, 12, 402, DateTimeKind.Local).AddTicks(5613));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 16, 17, 12, 402, DateTimeKind.Local).AddTicks(5617));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 16, 17, 12, 402, DateTimeKind.Local).AddTicks(5619));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 16, 17, 12, 402, DateTimeKind.Local).AddTicks(5621));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 16, 17, 12, 402, DateTimeKind.Local).AddTicks(5623));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 16, 17, 12, 402, DateTimeKind.Local).AddTicks(5625));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 16, 17, 12, 402, DateTimeKind.Local).AddTicks(5627));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 16, 17, 12, 402, DateTimeKind.Local).AddTicks(3466));
        }
    }
}
