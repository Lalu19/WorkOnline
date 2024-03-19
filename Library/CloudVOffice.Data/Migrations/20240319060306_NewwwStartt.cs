using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CloudVOffice.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewwwStartt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityLogTypeId = table.Column<int>(type: "int", nullable: true),
                    EntityId = table.Column<int>(type: "int", nullable: true),
                    EntityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    LogInTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LogOutTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivityLogTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemKeyword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLogTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AddDistricts",
                columns: table => new
                {
                    AddDistrictId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddDistricts", x => x.AddDistrictId);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "10000, 1"),
                    ApplicationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parent = table.Column<int>(type: "int", nullable: true),
                    IsGroup = table.Column<bool>(type: "bit", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IconImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_Applications_Applications_ApplicationId1",
                        column: x => x.ApplicationId1,
                        principalTable: "Applications",
                        principalColumn: "ApplicationId");
                });

            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    BannerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BannerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BannerImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.BannerId);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "BuyerOrders",
                columns: table => new
                {
                    BuyerOrderId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderUniqueNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    TotalQuantity = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pincode = table.Column<long>(type: "bigint", nullable: true),
                    BuyerCustomerLoginID = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerOrders", x => x.BuyerOrderId);
                });

            migrationBuilder.CreateTable(
                name: "BuyerRegistrations",
                columns: table => new
                {
                    BuyerRegistrationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PinCodeId = table.Column<long>(type: "bigint", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlternatePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesExecutiveUniqueNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesExecutiveContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RetailModelId = table.Column<long>(type: "bigint", nullable: true),
                    GSTNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WareHuoseId = table.Column<long>(type: "bigint", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstLogin = table.Column<bool>(type: "bit", nullable: false),
                    SectorId = table.Column<int>(type: "int", nullable: true),
                    ShopImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerRegistrations", x => x.BuyerRegistrationId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectorId = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ChangePasswords",
                columns: table => new
                {
                    ChangePasswordId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserMobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "CompanyDetails",
                columns: table => new
                {
                    CompanyDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ABBR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Domain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfEstablishment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfIncorporation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDetails", x => x.CompanyDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "DamageItemForFarmings",
                columns: table => new
                {
                    DamageItemForFarmingId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemMasterForFarmingId = table.Column<long>(type: "bigint", nullable: true),
                    WareHouseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitId = table.Column<long>(type: "bigint", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QtyPerKg = table.Column<double>(type: "float", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    MinQty = table.Column<double>(type: "float", nullable: true),
                    GST = table.Column<double>(type: "float", nullable: true),
                    HSN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarvestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DamagePic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DamageUnits = table.Column<double>(type: "float", nullable: true),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageItemForFarmings", x => x.DamageItemForFarmingId);
                });

            migrationBuilder.CreateTable(
                name: "DamageItems",
                columns: table => new
                {
                    DamageItemId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WareHouseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitId = table.Column<long>(type: "bigint", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductWeight = table.Column<double>(type: "float", nullable: false),
                    CaseWeight = table.Column<double>(type: "float", nullable: true),
                    UnitPerCase = table.Column<double>(type: "float", nullable: true),
                    ManufactureDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MRP = table.Column<double>(type: "float", nullable: false),
                    PurchaseCost = table.Column<double>(type: "float", nullable: false),
                    SalesCost = table.Column<double>(type: "float", nullable: false),
                    CGST = table.Column<double>(type: "float", nullable: true),
                    SGST = table.Column<double>(type: "float", nullable: true),
                    HandlingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DamagePics = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DamageUnits = table.Column<double>(type: "float", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageItems", x => x.DamageItemId);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryPartners",
                columns: table => new
                {
                    DeliveryPartnerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WareHuoseId = table.Column<long>(type: "bigint", nullable: true),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignedCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoadCapacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RetailModelId = table.Column<long>(type: "bigint", nullable: true),
                    VehicleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChassisNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationYear = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VehicleNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PollutionCertificate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Insurance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mileage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleFrontPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleBackPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryPartners", x => x.DeliveryPartnerId);
                });

            migrationBuilder.CreateTable(
                name: "DistrictMappings",
                columns: table => new
                {
                    DistrictMappingId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PinCodeId = table.Column<long>(type: "bigint", nullable: false),
                    AddDistrictId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistrictMappings", x => x.DistrictMappingId);
                });

            migrationBuilder.CreateTable(
                name: "DSO",
                columns: table => new
                {
                    DSOId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderUniqueNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    TotalQuantity = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PincodeId = table.Column<long>(type: "bigint", nullable: false),
                    DistributorId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DSO", x => x.DSOId);
                });

            migrationBuilder.CreateTable(
                name: "EmailDomains",
                columns: table => new
                {
                    EmailDomainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DomainName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncomingServer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncomingPort = table.Column<int>(type: "int", nullable: false),
                    IncomingIsIMAP = table.Column<bool>(type: "bit", nullable: false),
                    IncomingIsSsl = table.Column<bool>(type: "bit", nullable: false),
                    IncomingIsStartTLs = table.Column<bool>(type: "bit", nullable: false),
                    OutingServer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutgoingPort = table.Column<int>(type: "int", nullable: false),
                    OutgoingIsTLs = table.Column<bool>(type: "bit", nullable: false),
                    OutgoingIsSsl = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailDomains", x => x.EmailDomainId);
                });

            migrationBuilder.CreateTable(
                name: "EmailTemplates",
                columns: table => new
                {
                    EmailTemplateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailTemplateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailTemplateDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultSendingAccount = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplates", x => x.EmailTemplateId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssignedWareHouse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "ErrorLogs",
                columns: table => new
                {
                    ErrorLogId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    StatusCode = table.Column<int>(type: "int", nullable: false),
                    AreaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControllerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLogs", x => x.ErrorLogId);
                });

            migrationBuilder.CreateTable(
                name: "GSTs",
                columns: table => new
                {
                    GSTId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GSTValue = table.Column<double>(type: "float", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GSTs", x => x.GSTId);
                });

            migrationBuilder.CreateTable(
                name: "HandlingTypes",
                columns: table => new
                {
                    HandlingTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HandlingTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HandlingTypes", x => x.HandlingTypeId);
                });

            migrationBuilder.CreateTable(
                name: "InstalledApplications",
                columns: table => new
                {
                    InstalledApplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<double>(type: "float", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstalledApplications", x => x.InstalledApplicationId);
                });

            migrationBuilder.CreateTable(
                name: "ItemMasterForFarmings",
                columns: table => new
                {
                    ItemMasterForFarmingId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WareHuoseId = table.Column<int>(type: "int", nullable: true),
                    WareHouseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorId = table.Column<int>(type: "int", nullable: true),
                    VendorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddDistrictId = table.Column<int>(type: "int", nullable: true),
                    DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectorId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    SubCategory1Id = table.Column<int>(type: "int", nullable: true),
                    SubCategory2Id = table.Column<int>(type: "int", nullable: true),
                    Sector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubCategory1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubCategory2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarCodeNotAvailable = table.Column<bool>(type: "bit", nullable: false),
                    UnitId = table.Column<long>(type: "bigint", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QtyPerKg = table.Column<double>(type: "float", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    MinQty = table.Column<double>(type: "float", nullable: true),
                    GST = table.Column<double>(type: "float", nullable: true),
                    HSN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarvestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemMasterForFarmings", x => x.ItemMasterForFarmingId);
                });

            migrationBuilder.CreateTable(
                name: "LetterHeads",
                columns: table => new
                {
                    LetterHeadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LetterHeadName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LetterHeadImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LetterHeadImageHeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LetterHeadImageWidth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LetterHeadAlign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LetterHeadFooterImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LetterHeadImageFooterHeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LetterHeadImageFooterWidth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LetterHeadFooterAlign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LetterHeads", x => x.LetterHeadId);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogLevelId = table.Column<int>(type: "int", nullable: false),
                    ShortMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    PageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferrerUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Months",
                columns: table => new
                {
                    MonthId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonthName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Months", x => x.MonthId);
                });

            migrationBuilder.CreateTable(
                name: "PinCodes",
                columns: table => new
                {
                    PinCodeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lat = table.Column<double>(type: "float", nullable: true),
                    Long = table.Column<double>(type: "float", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PinCodes", x => x.PinCodeId);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    RefreshTokenId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Refresh_Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.RefreshTokenId);
                });

            migrationBuilder.CreateTable(
                name: "RetailLogins",
                columns: table => new
                {
                    RetailLoginId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserMobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstLogin = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetailLogins", x => x.RetailLoginId);
                });

            migrationBuilder.CreateTable(
                name: "RetailModels",
                columns: table => new
                {
                    RetailModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RetailerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetailModels", x => x.RetailModelId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "SalesExecutiveRegistrations",
                columns: table => new
                {
                    SalesExecutiveRegistrationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesExecutiveName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PANCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AadharCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesExecutiveUniqueNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WareHuoseId = table.Column<long>(type: "bigint", nullable: true),
                    PrimaryPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlternatePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RetailModelId = table.Column<long>(type: "bigint", nullable: true),
                    MailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesExecutiveRegistrations", x => x.SalesExecutiveRegistrationId);
                });

            migrationBuilder.CreateTable(
                name: "SalesManagers",
                columns: table => new
                {
                    SalesManagerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesManagerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateId = table.Column<long>(type: "bigint", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesManagers", x => x.SalesManagerId);
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    SectorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.SectorId);
                });

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

            migrationBuilder.CreateTable(
                name: "SubCategories1",
                columns: table => new
                {
                    SubCategory1Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubCategory1Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCategory1Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GSTId = table.Column<long>(type: "bigint", nullable: true),
                    HSN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories1", x => x.SubCategory1Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories2",
                columns: table => new
                {
                    SubCategory2Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubCategory1Id = table.Column<int>(type: "int", nullable: false),
                    SubCategory2Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCategory2Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories2", x => x.SubCategory2Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories3",
                columns: table => new
                {
                    SubCategory3Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubCategory1Id = table.Column<int>(type: "int", nullable: false),
                    SubCategory2Id = table.Column<int>(type: "int", nullable: false),
                    SubCategory3Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCategory3Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories3", x => x.SubCategory3Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories4",
                columns: table => new
                {
                    SubCategory4Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectorId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    SubCategory1Id = table.Column<int>(type: "int", nullable: true),
                    SubCategory2Id = table.Column<int>(type: "int", nullable: true),
                    SubCategory3Id = table.Column<int>(type: "int", nullable: true),
                    SubCategory4Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCategory4Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories4", x => x.SubCategory4Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitGroups",
                columns: table => new
                {
                    UnitGroupId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitGroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitGroups", x => x.UnitGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FailedLoginAttempts = table.Column<int>(type: "int", nullable: true),
                    LastIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastActivityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ResetPasswordToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetPasswordTokenExpirey = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChasisNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsuranceDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseYear = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                });

            migrationBuilder.CreateTable(
                name: "VendorOnboardings",
                columns: table => new
                {
                    VendorOnboardingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectorId = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorOnboardings", x => x.VendorOnboardingId);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    VendorId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    WareHuoseId = table.Column<long>(type: "bigint", nullable: false),
                    VendorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GSTNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoCName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.VendorId);
                });

            migrationBuilder.CreateTable(
                name: "WareHouses",
                columns: table => new
                {
                    WareHuoseId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GSTNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WareHouseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignmentCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WareHouses", x => x.WareHuoseId);
                });

            migrationBuilder.CreateTable(
                name: "WareHouseSalesOrderItems",
                columns: table => new
                {
                    WareHouseSalesOrderItemId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseSalesOrderParentId = table.Column<long>(type: "bigint", nullable: false),
                    WareHuoseId = table.Column<long>(type: "bigint", nullable: true),
                    ItemId = table.Column<long>(type: "bigint", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WareHouseSalesOrderItems", x => x.WareHouseSalesOrderItemId);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseSalesOrderParents",
                columns: table => new
                {
                    WarehouseSalesOrderParentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseSalesOrderUniqueNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DPOUniqueNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistributorRegistrationId = table.Column<long>(type: "bigint", nullable: false),
                    WareHuoseId = table.Column<long>(type: "bigint", nullable: true),
                    TotalQuantity = table.Column<double>(type: "float", nullable: true),
                    TotalAmount = table.Column<double>(type: "float", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseSalesOrderParents", x => x.WarehouseSalesOrderParentId);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectorId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    SubCategory1Id = table.Column<int>(type: "int", nullable: true),
                    SubCategory2Id = table.Column<int>(type: "int", nullable: true),
                    WareHuoseId = table.Column<int>(type: "int", nullable: true),
                    WareHouseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddDistrictId = table.Column<int>(type: "int", nullable: true),
                    DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorId = table.Column<int>(type: "int", nullable: true),
                    VendorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubCategory1Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubCategory2Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HSN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<long>(type: "bigint", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductWeight = table.Column<double>(type: "float", nullable: false),
                    UnitId = table.Column<long>(type: "bigint", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellerMargin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseWeight = table.Column<double>(type: "float", nullable: true),
                    UnitPerCase = table.Column<double>(type: "float", nullable: true),
                    ManufactureDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarCodeNotAvailable = table.Column<bool>(type: "bit", nullable: false),
                    MRP = table.Column<double>(type: "float", nullable: false),
                    MRPCaseCost = table.Column<double>(type: "float", nullable: true),
                    PurchaseCost = table.Column<double>(type: "float", nullable: false),
                    PurchaseCaseCost = table.Column<double>(type: "float", nullable: true),
                    SalesCost = table.Column<double>(type: "float", nullable: false),
                    SalesCaseCost = table.Column<double>(type: "float", nullable: true),
                    PartnerSalesCost = table.Column<double>(type: "float", nullable: false),
                    PartnerSalesCaseCost = table.Column<double>(type: "float", nullable: true),
                    CGST = table.Column<double>(type: "float", nullable: true),
                    SGST = table.Column<double>(type: "float", nullable: true),
                    IGST = table.Column<double>(type: "float", nullable: true),
                    SellerRegistrationId = table.Column<long>(type: "bigint", nullable: true),
                    PurchaseLandingCost = table.Column<double>(type: "float", nullable: true),
                    DistributorCost = table.Column<double>(type: "float", nullable: true),
                    DistributorLandingCost = table.Column<double>(type: "float", nullable: true),
                    DistributorCaseCost = table.Column<double>(type: "float", nullable: true),
                    RetailerCost = table.Column<double>(type: "float", nullable: true),
                    RetailerLandingCost = table.Column<double>(type: "float", nullable: true),
                    RetailerCaseCost = table.Column<double>(type: "float", nullable: true),
                    DistributorMargin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RetailerMargin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseCGSTValue = table.Column<double>(type: "float", nullable: true),
                    PurchaseSGSTValue = table.Column<double>(type: "float", nullable: true),
                    PurchaseIGSTValue = table.Column<double>(type: "float", nullable: true),
                    DistributorCGSTValue = table.Column<double>(type: "float", nullable: true),
                    DistributorSGSTValue = table.Column<double>(type: "float", nullable: true),
                    RetailerCGSTValue = table.Column<double>(type: "float", nullable: true),
                    RetailerSGSTValue = table.Column<double>(type: "float", nullable: true),
                    HandlingTypeId = table.Column<int>(type: "int", nullable: true),
                    HandlingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Videos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailAccounts",
                columns: table => new
                {
                    EmailAccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Domain = table.Column<int>(type: "int", nullable: false),
                    EmailAccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlternativeEmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefaultSending = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAccounts", x => x.EmailAccountId);
                    table.ForeignKey(
                        name: "FK_EmailAccounts_EmailDomains_Domain",
                        column: x => x.Domain,
                        principalTable: "EmailDomains",
                        principalColumn: "EmailDomainId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleAndApplicationWisePermissions",
                columns: table => new
                {
                    RoleAndApplicationWisePermissionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "10000, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleAndApplicationWisePermissions", x => x.RoleAndApplicationWisePermissionId);
                    table.ForeignKey(
                        name: "FK_RoleAndApplicationWisePermissions_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleAndApplicationWisePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BrandWiseTargets",
                columns: table => new
                {
                    BrandWiseTargetId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<long>(type: "bigint", nullable: false),
                    MonthId = table.Column<long>(type: "bigint", nullable: false),
                    UnitId = table.Column<long>(type: "bigint", nullable: true),
                    SalesManagerID = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    WareHuoseId = table.Column<long>(type: "bigint", nullable: true),
                    SalesExecutiveRegistrationId = table.Column<long>(type: "bigint", nullable: true),
                    MonthlyBrandWiseTarget = table.Column<double>(type: "float", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandWiseTargets", x => x.BrandWiseTargetId);
                    table.ForeignKey(
                        name: "FK_BrandWiseTargets_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrandWiseTargets_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrandWiseTargets_Months_MonthId",
                        column: x => x.MonthId,
                        principalTable: "Months",
                        principalColumn: "MonthId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrandWiseTargets_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "SectorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesAdminTargets",
                columns: table => new
                {
                    SalesAdminTargetId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesManagerId = table.Column<long>(type: "bigint", nullable: false),
                    SalesAdminTargetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonthId = table.Column<long>(type: "bigint", nullable: false),
                    SectorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<long>(type: "bigint", nullable: true),
                    MonthlyCategoryWiseTarget = table.Column<double>(type: "float", nullable: true),
                    MonthlySectorWiseTarget = table.Column<double>(type: "float", nullable: true),
                    MonthlyBrandWiseTarget = table.Column<double>(type: "float", nullable: true),
                    UnitId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesAdminTargets", x => x.SalesAdminTargetId);
                    table.ForeignKey(
                        name: "FK_SalesAdminTargets_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesAdminTargets_Months_MonthId",
                        column: x => x.MonthId,
                        principalTable: "Months",
                        principalColumn: "MonthId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesAdminTargets_SalesManagers_SalesManagerId",
                        column: x => x.SalesManagerId,
                        principalTable: "SalesManagers",
                        principalColumn: "SalesManagerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesAdminTargets_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "SectorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesExecutiveTargets",
                columns: table => new
                {
                    SalesExecutiveTargetId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonthId = table.Column<long>(type: "bigint", nullable: false),
                    SectorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<long>(type: "bigint", nullable: true),
                    SalesExecutiveRegistrationId = table.Column<long>(type: "bigint", nullable: false),
                    MonthlyCategoryWiseTarget = table.Column<double>(type: "float", nullable: true),
                    MonthlySectorWiseTarget = table.Column<double>(type: "float", nullable: true),
                    MonthlyBrandWiseTarget = table.Column<double>(type: "float", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesExecutiveTargets", x => x.SalesExecutiveTargetId);
                    table.ForeignKey(
                        name: "FK_SalesExecutiveTargets_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesExecutiveTargets_Months_MonthId",
                        column: x => x.MonthId,
                        principalTable: "Months",
                        principalColumn: "MonthId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesExecutiveTargets_SalesExecutiveRegistrations_SalesExecutiveRegistrationId",
                        column: x => x.SalesExecutiveRegistrationId,
                        principalTable: "SalesExecutiveRegistrations",
                        principalColumn: "SalesExecutiveRegistrationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesExecutiveTargets_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "SectorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitGroupId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitId);
                    table.ForeignKey(
                        name: "FK_Units_UnitGroups_UnitGroupId",
                        column: x => x.UnitGroupId,
                        principalTable: "UnitGroups",
                        principalColumn: "UnitGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesManagerTargets",
                columns: table => new
                {
                    SalesManagerTargetId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    MonthId = table.Column<long>(type: "bigint", nullable: false),
                    SectorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<long>(type: "bigint", nullable: true),
                    MonthlyCategoryWiseTarget = table.Column<double>(type: "float", nullable: true),
                    MonthlySectorWiseTargetByAdmin = table.Column<double>(type: "float", nullable: true),
                    MonthlyBrandWiseTarget = table.Column<double>(type: "float", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesManagerTargets", x => x.SalesManagerTargetId);
                    table.ForeignKey(
                        name: "FK_SalesManagerTargets_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesManagerTargets_Months_MonthId",
                        column: x => x.MonthId,
                        principalTable: "Months",
                        principalColumn: "MonthId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesManagerTargets_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "SectorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesManagerTargets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleMappings",
                columns: table => new
                {
                    UserRoleMappingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleMappings", x => x.UserRoleMappingId);
                    table.ForeignKey(
                        name: "FK_UserRoleMappings_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleMappings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserWiseViewMappers",
                columns: table => new
                {
                    UserWiseViewMapperId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "10000, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWiseViewMappers", x => x.UserWiseViewMapperId);
                    table.ForeignKey(
                        name: "FK_UserWiseViewMappers_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserWiseViewMappers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "DistributorRegistrations",
                columns: table => new
                {
                    DistributorRegistrationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlternatePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GSTNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WareHuoseId = table.Column<long>(type: "bigint", nullable: false),
                    AssignmentCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistributorRegistrations", x => x.DistributorRegistrationId);
                    table.ForeignKey(
                        name: "FK_DistributorRegistrations_WareHouses_WareHuoseId",
                        column: x => x.WareHuoseId,
                        principalTable: "WareHouses",
                        principalColumn: "WareHuoseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DPO",
                columns: table => new
                {
                    DPOId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DPOUniqueNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WareHuoseId = table.Column<long>(type: "bigint", nullable: false),
                    DistributorId = table.Column<long>(type: "bigint", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    TotalQuantity = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DPO", x => x.DPOId);
                    table.ForeignKey(
                        name: "FK_DPO_WareHouses_WareHuoseId",
                        column: x => x.WareHuoseId,
                        principalTable: "WareHouses",
                        principalColumn: "WareHuoseId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "SalesOrderParents",
                columns: table => new
                {
                    SalesOrderParentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesOrderUniqueNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WareHuoseId = table.Column<long>(type: "bigint", nullable: false),
                    POPUniqueNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalQuantity = table.Column<double>(type: "float", nullable: true),
                    TotalAmount = table.Column<double>(type: "float", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderParents", x => x.SalesOrderParentId);
                    table.ForeignKey(
                        name: "FK_SalesOrderParents_WareHouses_WareHuoseId",
                        column: x => x.WareHuoseId,
                        principalTable: "WareHouses",
                        principalColumn: "WareHuoseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellerRegistrations",
                columns: table => new
                {
                    SellerRegistrationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PinCodeId = table.Column<long>(type: "bigint", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlternatePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesRepresentativeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesRepresentativeContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RetailModelId = table.Column<long>(type: "bigint", nullable: true),
                    GSTNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WareHuoseId = table.Column<long>(type: "bigint", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstLogin = table.Column<bool>(type: "bit", nullable: false),
                    SectorId = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerRegistrations", x => x.SellerRegistrationId);
                    table.ForeignKey(
                        name: "FK_SellerRegistrations_WareHouses_WareHuoseId",
                        column: x => x.WareHuoseId,
                        principalTable: "WareHouses",
                        principalColumn: "WareHuoseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserWareHouseMappings",
                columns: table => new
                {
                    UserWareHouseMappingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WareHuoseId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWareHouseMappings", x => x.UserWareHouseMappingId);
                    table.ForeignKey(
                        name: "FK_UserWareHouseMappings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserWareHouseMappings_WareHouses_WareHuoseId",
                        column: x => x.WareHuoseId,
                        principalTable: "WareHouses",
                        principalColumn: "WareHuoseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuyerOrderItems",
                columns: table => new
                {
                    BuyerOrderItemsId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerOrderId = table.Column<long>(type: "bigint", nullable: false),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerOrderItems", x => x.BuyerOrderItemsId);
                    table.ForeignKey(
                        name: "FK_BuyerOrderItems_BuyerOrders_BuyerOrderId",
                        column: x => x.BuyerOrderId,
                        principalTable: "BuyerOrders",
                        principalColumn: "BuyerOrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuyerOrderItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Checkouts",
                columns: table => new
                {
                    CheckoutId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkouts", x => x.CheckoutId);
                    table.ForeignKey(
                        name: "FK_Checkouts_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DSOItems",
                columns: table => new
                {
                    DSOItemsId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DSOId = table.Column<long>(type: "bigint", nullable: false),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DSOItems", x => x.DSOItemsId);
                    table.ForeignKey(
                        name: "FK_DSOItems_DSO_DSOId",
                        column: x => x.DSOId,
                        principalTable: "DSO",
                        principalColumn: "DSOId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DSOItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    StockId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    SectorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<long>(type: "bigint", nullable: true),
                    WareHuoseId = table.Column<long>(type: "bigint", nullable: false),
                    UnitId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.StockId);
                    table.ForeignKey(
                        name: "FK_Stocks_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "SectorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks_WareHouses_WareHuoseId",
                        column: x => x.WareHuoseId,
                        principalTable: "WareHouses",
                        principalColumn: "WareHuoseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnitConversionFactors",
                columns: table => new
                {
                    UnitConversionFactorsId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromUnitId = table.Column<long>(type: "bigint", nullable: false),
                    ToUnitId = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitConversionFactors", x => x.UnitConversionFactorsId);
                    table.ForeignKey(
                        name: "FK_UnitConversionFactors_Units_FromUnitId",
                        column: x => x.FromUnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DistributorAssigns",
                columns: table => new
                {
                    DistributorAssignId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistributorRegistrationId = table.Column<long>(type: "bigint", nullable: false),
                    PinCodeId = table.Column<long>(type: "bigint", nullable: false),
                    BrandId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistributorAssigns", x => x.DistributorAssignId);
                    table.ForeignKey(
                        name: "FK_DistributorAssigns_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DistributorAssigns_DistributorRegistrations_DistributorRegistrationId",
                        column: x => x.DistributorRegistrationId,
                        principalTable: "DistributorRegistrations",
                        principalColumn: "DistributorRegistrationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DistributorAssigns_PinCodes_PinCodeId",
                        column: x => x.PinCodeId,
                        principalTable: "PinCodes",
                        principalColumn: "PinCodeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DPOItems",
                columns: table => new
                {
                    DPOItemsId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DPOId = table.Column<long>(type: "bigint", nullable: false),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DPOItems", x => x.DPOItemsId);
                    table.ForeignKey(
                        name: "FK_DPOItems_DPO_DPOId",
                        column: x => x.DPOId,
                        principalTable: "DPO",
                        principalColumn: "DPOId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DPOItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderItems",
                columns: table => new
                {
                    SalesOrderItemId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesOrderParentId = table.Column<long>(type: "bigint", nullable: false),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CGST = table.Column<double>(type: "float", nullable: true),
                    SGST = table.Column<double>(type: "float", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderItems", x => x.SalesOrderItemId);
                    table.ForeignKey(
                        name: "FK_SalesOrderItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrderItems_SalesOrderParents_SalesOrderParentId",
                        column: x => x.SalesOrderParentId,
                        principalTable: "SalesOrderParents",
                        principalColumn: "SalesOrderParentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderParents",
                columns: table => new
                {
                    PurchaseOrderParentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WareHuoseId = table.Column<long>(type: "bigint", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: true),
                    TotalQuantity = table.Column<double>(type: "float", nullable: true),
                    SellerRegistrationId = table.Column<long>(type: "bigint", nullable: false),
                    POPUniqueNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderShipped = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderParents", x => x.PurchaseOrderParentId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderParents_SellerRegistrations_SellerRegistrationId",
                        column: x => x.SellerRegistrationId,
                        principalTable: "SellerRegistrations",
                        principalColumn: "SellerRegistrationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderParents_WareHouses_WareHuoseId",
                        column: x => x.WareHuoseId,
                        principalTable: "WareHouses",
                        principalColumn: "WareHuoseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    PurchaseOrderId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseOrderParentId = table.Column<long>(type: "bigint", nullable: true),
                    SellerRegistrationId = table.Column<long>(type: "bigint", nullable: false),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    Value = table.Column<double>(type: "float", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.PurchaseOrderId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_PurchaseOrderParents_PurchaseOrderParentId",
                        column: x => x.PurchaseOrderParentId,
                        principalTable: "PurchaseOrderParents",
                        principalColumn: "PurchaseOrderParentId");
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_SellerRegistrations_SellerRegistrationId",
                        column: x => x.SellerRegistrationId,
                        principalTable: "SellerRegistrations",
                        principalColumn: "SellerRegistrationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "ApplicationId", "ApplicationId1", "ApplicationName", "AreaName", "CreatedBy", "CreatedDate", "Deleted", "IconClass", "IconImageUrl", "IsGroup", "Parent", "UpdatedBy", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, null, "Applications", "Application", 1L, new DateTime(2024, 3, 19, 11, 33, 5, 608, DateTimeKind.Local).AddTicks(196), false, "icon-th-large-outline", "/appstatic/images/applications.png", true, null, null, null, "/Application/Applications/InstalledApps" },
                    { 2, null, "Setup", "Setup", 1L, new DateTime(2024, 3, 19, 11, 33, 5, 608, DateTimeKind.Local).AddTicks(204), false, "icon-cogs", "/appstatic/images/setup.png", true, null, null, null, "/Setup/Setup/Dashboard" },
                    { 3, null, "Company Settings", "Setup", 1L, new DateTime(2024, 3, 19, 11, 33, 5, 608, DateTimeKind.Local).AddTicks(208), false, "icon-office", null, true, 2, null, null, "" },
                    { 4, null, "Company", "Setup", 1L, new DateTime(2024, 3, 19, 11, 33, 5, 608, DateTimeKind.Local).AddTicks(212), false, null, null, false, 3, null, null, "/Setup/CompanyDetails/CompanyDetailsView" },
                    { 5, null, "Letter Head", "Setup", 1L, new DateTime(2024, 3, 19, 11, 33, 5, 608, DateTimeKind.Local).AddTicks(215), false, null, null, false, 3, null, null, "/Setup/LetterHead/LetterHeadView" },
                    { 6, null, "User", "Setup", 1L, new DateTime(2024, 3, 19, 11, 33, 5, 608, DateTimeKind.Local).AddTicks(219), false, "icon-users", null, true, 2, null, null, "" },
                    { 7, null, "User List", "Setup", 1L, new DateTime(2024, 3, 19, 11, 33, 5, 608, DateTimeKind.Local).AddTicks(223), false, null, null, false, 6, null, null, "/Setup/User/UserList" }
                });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "EmailTemplateId", "CreatedBy", "CreatedDate", "DefaultSendingAccount", "Deleted", "EmailTemplateDescription", "EmailTemplateName", "Subject", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1L, new DateTime(2024, 3, 19, 11, 33, 5, 608, DateTimeKind.Local).AddTicks(2214), null, false, "<div role=\"document\">\r\n    <div class=\"_rp_T4 _rp_U4 ms-font-weight-regular ms-font-color-neutralDark\" style=\"display: none;\"></div>  <div autoid=\"_rp_w\" class=\"_rp_T4\" style=\"display: none;\"></div>  <div autoid=\"_rp_x\" class=\"_rp_T4\" id=\"Item.MessagePartBody\" style=\"\">\r\n        <div class=\"_rp_U4 ms-font-weight-regular ms-font-color-neutralDark rpHighlightAllClass rpHighlightBodyClass\" id=\"Item.MessageUniqueBody\" style=\"font-family: wf_segoe-ui_normal, &quot;Segoe UI&quot;, &quot;Segoe WP&quot;, Tahoma, Arial, sans-serif, serif, EmojiFont;\">\r\n            <div class=\"rps_ad57\">\r\n                <div>\r\n                    <div>\r\n                        <div style=\"margin: 0px; padding: 0px; font-family: Verdana, Helvetica, Arial, sans-serif, serif, EmojiFont; color: rgb(103, 103, 103);\">\r\n                            <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"padding-top:0px; background-color:#FFFFFF; width:100%; border-collapse:separate\">\r\n                                <tbody>\r\n                                    <tr>\r\n                                        <td align=\"center\">\r\n                                            <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"600\" style=\"padding:0px 24px 10px; background-color:white; border-collapse:separate; border:1px solid #e7e7e7; border-bottom:none\">\r\n                                                <tbody>\r\n                                                    <tr>\r\n                                                        <td></td>\r\n                                                    </tr>\r\n                                                    <tr>\r\n                                                        <td align=\"center\" style=\"min-width:590px\">\r\n                                                            <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"padding:20px 0 0; border-collapse:separate\">\r\n                                                                <tbody>\r\n                                                                    <tr>\r\n                                                                        <td valign=\"middle\">\r\n                                                                            <h1 style=\"color:#676767; font-weight:400; margin:0px\">{%welcometitle%} </h1>\r\n                                                                        </td>\r\n                                                                        <td valign=\"middle\" align=\"right\" width=\"200px\">{%emailogo%}</td>\r\n                                                                    </tr>\r\n                                                                    <tr>\r\n                                                                        <td colspan=\"2\" style=\"text-align:center\">\r\n                                                                            <hr width=\"100%\" style=\"background-color:rgb(204,204,204); border:medium none; clear:both; display:block; font-size:0px; min-height:1px; line-height:0; margin:4px 0px 16px 0px\">\r\n                                                                        </td>\r\n                                                                    </tr>\r\n                                                                </tbody>\r\n                                                            </table>\r\n                                                        </td>\r\n                                                    </tr>\r\n                                                    <tr>\r\n                                                        <td style=\"min-width:590px\">\r\n                                                            <table border=\"0\">\r\n                                                                <tbody>\r\n                                                                    <tr>\r\n                                                                        <td>\r\n                                                                            <div style=\"margin-left:1.2rem; margin-bottom:1em\">\r\n                                                                                <h5 style=\"font-weight:400; margin-bottom:0; font-size:16px; color:#676767\"><span style=\"color:rgb(22,123,158); font-size:16px; margin-right:2px; font-weight:600\"></span>{%helloname%}</h5>\r\n                                                                                <p style=\"color:#676767; line-height:145%; margin:10px 0 0 0; font-size:16px\">{%accountcreatetionmessage%}</p>\r\n\r\n                                                                                <p style=\"color:#676767; line-height:145%; margin:10px 0 0 0; font-size:16px\">{%loginidmessage%}</p>\r\n\r\n\r\n                                                                                <p style=\"color:#676767; line-height:145%; margin:10px 0 0 0; font-size:16px\">{%aditionalmessage%}</p>\r\n                                                                                <div style=\"margin:20px 0 0 0; text-align:center\">{%setpasswordlink%}</div>\r\n                                                                                <br />\r\n                                                                                {%copylinkfrommessage%}\r\n                                                                            </div>\r\n                                                                         \r\n                                                                            <div style=\"margin-left:1.2rem; margin-bottom:1em\">\r\n                                                                                <p style=\"color:#676767; line-height:145%; margin:10px 0 0 0; font-size:16px\">\r\n                                                                                    {%emailsignature%}\r\n                                                                                </p>\r\n                                                                            </div>\r\n                                                                        </td>\r\n                                                                    </tr>\r\n                                                                </tbody>\r\n                                                            </table>\r\n                                                        </td>\r\n                                                    </tr>\r\n                                                    <tr>\r\n                                                        <td>\r\n                                                            <table border=\"0\" style=\"width:100%\">\r\n                                                                <tbody>\r\n                                                                    <tr>\r\n                                                                        <td>\r\n                                                                            <div style=\"text-align:center; border-top:1px solid rgb(230,230,230); padding-bottom:20px; padding-top:15px; line-height:125%; font-size:11px; margin:20px 20px 0 20px\">\r\n                                                                                <p style=\"color:rgb(115,115,115); font-size:10px\">© Copyright {%companyname%}, {%address%} </p>\r\n                                                                            </div>\r\n                                                                        </td>\r\n                                                                    </tr>\r\n                                                                    <tr>\r\n                                                                        <td align=\"right\">\r\n                                                                            <div style=\" margin:0 20px\">{%footerletterhera%}</div>\r\n                                                                        </td>\r\n                                                                    </tr>\r\n                                                                </tbody>\r\n                                                            </table>\r\n                                                        </td>\r\n                                                    </tr>\r\n                                                    <tr>\r\n                                                        <td>\r\n                                                            <table border=\"0\" style=\"width:100%\">\r\n                                                                <tbody>\r\n                                                                    <tr>\r\n                                                                        <td>\r\n                                                                            <div style=\"text-align:justify; border-top:1px solid rgb(230,230,230); padding-bottom:10px; padding-top:10px; line-height:125%; font-size:10px; margin:25px 20px 0 20px\">\r\n                                                                                <p style=\"color:rgb(115,115,115); margin:0; font-size:10px\">\r\n                                                                                    The information contained in this e-mail message and/or attachments to it may contain confidential\r\n                                                                                    or privileged information. If you are not the intended recipient, any dissemination,use, review, distribution,\r\n                                                                                    printing or copying of the information contained in this email message and/or attachments to it are strictly prohibited.\r\n                                                                                    If you have received this communication in error, please notify us by reply e-mail or telephone and immediately\r\n                                                                                    and permanently delete the message and any attachments. Thank you.\r\n                                                                                </p>\r\n                                                                            </div>\r\n                                                                        </td>\r\n                                                                    </tr>\r\n                                                                </tbody>\r\n                                                            </table>\r\n                                                        </td>\r\n                                                    </tr>\r\n                                                </tbody>\r\n                                            </table>\r\n                                        </td>\r\n                                    </tr>\r\n                                </tbody>\r\n                            </table>\r\n                        </div>\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n        </div> <div class=\"_rp_c5\" style=\"display: none;\"></div>\r\n    </div>  <span class=\"PersonaPaneLauncher\"><div ariatabindex=\"-1\" class=\"_pe_d _pe_62\" aria-expanded=\"false\" tabindex=\"-1\" aria-haspopup=\"false\">  <div style=\"display: none;\"></div> </div></span>\r\n</div>", "WelcomeEmail", "", null, null },
                    { 7, 1L, new DateTime(2024, 3, 19, 11, 33, 5, 608, DateTimeKind.Local).AddTicks(2242), null, false, "<div role=\"document\">\r\n    <div class=\"_rp_T4 _rp_U4 ms-font-weight-regular ms-font-color-neutralDark\" style=\"display: none;\"><br></div>  <div autoid=\"_rp_w\" class=\"_rp_T4\" style=\"display: none;\"><br></div>  <div autoid=\"_rp_x\" class=\"_rp_T4\" id=\"Item.MessagePartBody\" style=\"\">\r\n        <div class=\"_rp_U4 ms-font-weight-regular ms-font-color-neutralDark rpHighlightAllClass rpHighlightBodyClass\" id=\"Item.MessageUniqueBody\" style=\"font-family: wf_segoe-ui_normal, &quot;Segoe UI&quot;, &quot;Segoe WP&quot;, Tahoma, Arial, sans-serif, serif, EmojiFont;\">\r\n            <div class=\"rps_ad57\">\r\n                <div>\r\n                    <div>\r\n                        <div style=\"margin: 0px; padding: 0px; font-family: Verdana, Helvetica, Arial, sans-serif, serif, EmojiFont; color: rgb(103, 103, 103);\">\r\n                            <table cellpadding=\"0\" cellspacing=\"0\" style=\"padding-top:0px; background-color:#FFFFFF; width:100%; border-collapse:separate\" class=\"e-rte-table\">\r\n                                <tbody>\r\n                                    <tr>\r\n                                        <td align=\"center\" class=\"\">\r\n                                            <table cellpadding=\"0\" cellspacing=\"0\" width=\"600\" style=\"padding:0px 24px 10px; background-color:white; border-collapse:separate; border:1px solid #e7e7e7; border-bottom:none\" class=\"e-rte-table\">\r\n                                                <tbody>\r\n                                                    <tr>\r\n                                                        <td><br></td>\r\n                                                    </tr>\r\n                                                    <tr>\r\n                                                        <td align=\"center\" style=\"min-width:590px\">\r\n                                                            <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"padding:20px 0 0; border-collapse:separate\" class=\"e-rte-table\">\r\n                                                                <tbody>\r\n                                                                    <tr>\r\n                                                                        <td valign=\"middle\" class=\"\">\r\n                                                                            <h1 style=\"color:#676767; font-weight:400; margin:0px\">Password Reset Request</h1>\r\n                                                                        </td>\r\n                                                                        <td valign=\"middle\" align=\"right\" width=\"200px\">{%emailogo%}</td>\r\n                                                                    </tr>\r\n                                                                    <tr>\r\n                                                                        <td colspan=\"2\" style=\"text-align:center\">\r\n                                                                            <hr width=\"100%\" style=\"background-color:rgb(204,204,204); border:medium none; clear:both; display:block; font-size:0px; min-height:1px; line-height:0; margin:4px 0px 16px 0px\">\r\n                                                                        </td>\r\n                                                                    </tr>\r\n                                                                </tbody>\r\n                                                            </table>\r\n                                                        </td>\r\n                                                    </tr>\r\n                                                    <tr>\r\n                                                        <td style=\"min-width:590px\">\r\n                                                            <table class=\"e-rte-table\">\r\n                                                                <tbody>\r\n                                                                    <tr>\r\n                                                                        <td class=\"\">\r\n                                                                            <div style=\"margin-left:1.2rem; margin-bottom:1em\">\r\n                                                                                <h5 style=\"font-weight:400; margin-bottom:0; font-size:16px; color:#676767\">Hello {%helloname%}</h5><div><br></div>\r\n                                                                                <p>We have received a request to reset your account password. To proceed with the password reset, please click on the link below:</p>\r\n                                                                                <div style=\"margin:20px 0 0 0; text-align:center\">{%setpasswordlink%}</div>\r\n                                                                                <br>If you did not request a password reset, Please ignore this email. Your account will&nbsp;<span style=\"background-color: transparent; text-align: inherit;\">remain secure, and no action is required.</span></div><div style=\"margin-left:1.2rem; margin-bottom:1em\"><span style=\"background-color: transparent; text-align: inherit;\"><p>For security reasons, this link will expire in 2 hours. If you&nbsp;<span style=\"background-color: transparent; text-align: inherit;\">are unable to reset your password within this time frame,&nbsp;</span><span style=\"background-color: transparent; text-align: inherit;\">please request another password reset.</span></p></span></div>\r\n                                                                         \r\n                                                                            <div style=\"margin-left:1.2rem; margin-bottom:1em\">\r\n                                                                                <p style=\"color:#676767; line-height:145%; margin:10px 0 0 0; font-size:16px\">\r\n                                                                                    {%emailsignature%}\r\n                                                                                </p>\r\n                                                                            </div>\r\n                                                                        </td>\r\n                                                                    </tr>\r\n                                                                </tbody>\r\n                                                            </table>\r\n                                                        </td>\r\n                                                    </tr>\r\n                                                    <tr>\r\n                                                        <td>\r\n                                                            <table style=\"width:100%\" class=\"e-rte-table\">\r\n                                                                <tbody>\r\n                                                                    <tr>\r\n                                                                        <td>\r\n                                                                            <div style=\"text-align:center; border-top:1px solid rgb(230,230,230); padding-bottom:20px; padding-top:15px; line-height:125%; font-size:11px; margin:20px 20px 0 20px\">\r\n                                                                                <p style=\"color:rgb(115,115,115); font-size:10px\">© Copyright {%companyname%}, {%address%} </p>\r\n                                                                            </div>\r\n                                                                        </td>\r\n                                                                    </tr>\r\n                                                                    <tr>\r\n                                                                        <td align=\"right\">\r\n                                                                            <div style=\" margin:0 20px\">{%footerletterhera%}</div>\r\n                                                                        </td>\r\n                                                                    </tr>\r\n                                                                </tbody>\r\n                                                            </table>\r\n                                                        </td>\r\n                                                    </tr>\r\n                                                    <tr>\r\n                                                        <td>\r\n                                                            <table style=\"width:100%\" class=\"e-rte-table\">\r\n                                                                <tbody>\r\n                                                                    <tr>\r\n                                                                        <td>\r\n                                                                            <div style=\"text-align:justify; border-top:1px solid rgb(230,230,230); padding-bottom:10px; padding-top:10px; line-height:125%; font-size:10px; margin:25px 20px 0 20px\">\r\n                                                                                <p style=\"color:rgb(115,115,115); margin:0; font-size:10px\">\r\n                                                                                    The information contained in this e-mail message and/or attachments to it may contain confidential\r\n                                                                                    or privileged information. If you are not the intended recipient, any dissemination,use, review, distribution,\r\n                                                                                    printing or copying of the information contained in this email message and/or attachments to it are strictly prohibited.\r\n                                                                                    If you have received this communication in error, please notify us by reply e-mail or telephone and immediately\r\n                                                                                    and permanently delete the message and any attachments. Thank you.\r\n                                                                                </p>\r\n                                                                            </div>\r\n                                                                        </td>\r\n                                                                    </tr>\r\n                                                                </tbody>\r\n                                                            </table>\r\n                                                        </td>\r\n                                                    </tr>\r\n                                                </tbody>\r\n                                            </table>\r\n                                        </td>\r\n                                    </tr>\r\n                                </tbody>\r\n                            </table>\r\n                        </div>\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n        </div> <div class=\"_rp_c5\" style=\"display: none;\"><br></div>\r\n    </div>  <span class=\"PersonaPaneLauncher\"><div ariatabindex=\"-1\" class=\"_pe_d _pe_62\" aria-expanded=\"false\" tabindex=\"-1\" aria-haspopup=\"false\">  <div style=\"display: none;\"><br></div> </div></span>\r\n</div>", "PasswordReset", "Password Reset Request", null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "CreatedBy", "CreatedDate", "Deleted", "RoleName", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, 1L, new DateTime(2024, 3, 19, 11, 33, 5, 607, DateTimeKind.Local).AddTicks(6155), false, "Administrator", null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedBy", "CreatedDate", "DateOfBirth", "Deleted", "Email", "FailedLoginAttempts", "FirstName", "IsActive", "LastActivityDate", "LastIpAddress", "LastLoginDate", "LastName", "MiddleName", "Password", "PhoneNo", "ResetPasswordToken", "ResetPasswordTokenExpirey", "UpdatedBy", "UpdatedDate", "UserType", "UserTypeId" },
                values: new object[] { 1L, 1L, new DateTime(2024, 3, 19, 11, 33, 5, 607, DateTimeKind.Local).AddTicks(8814), null, false, "admin@appman.in", null, "Administrator", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "", null, "r9NmU79/NE0x0el2cuI8PeI4GlVCdpOeB875sWPUeJw=", "9583000000", null, null, null, null, 1, 1 });

            migrationBuilder.InsertData(
                table: "RoleAndApplicationWisePermissions",
                columns: new[] { "RoleAndApplicationWisePermissionId", "ApplicationId", "CreatedBy", "CreatedDate", "Deleted", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, 1, 1L, new DateTime(2024, 3, 19, 11, 33, 5, 608, DateTimeKind.Local).AddTicks(1004), false, 1, null, null },
                    { 2L, 2, 1L, new DateTime(2024, 3, 19, 11, 33, 5, 608, DateTimeKind.Local).AddTicks(1008), false, 1, null, null },
                    { 3L, 3, 1L, new DateTime(2024, 3, 19, 11, 33, 5, 608, DateTimeKind.Local).AddTicks(1011), false, 1, null, null },
                    { 4L, 4, 1L, new DateTime(2024, 3, 19, 11, 33, 5, 608, DateTimeKind.Local).AddTicks(1014), false, 1, null, null },
                    { 5L, 5, 1L, new DateTime(2024, 3, 19, 11, 33, 5, 608, DateTimeKind.Local).AddTicks(1016), false, 1, null, null },
                    { 6L, 6, 1L, new DateTime(2024, 3, 19, 11, 33, 5, 608, DateTimeKind.Local).AddTicks(1019), false, 1, null, null },
                    { 7L, 7, 1L, new DateTime(2024, 3, 19, 11, 33, 5, 608, DateTimeKind.Local).AddTicks(1022), false, 1, null, null },
                    { 8L, 8, 1L, new DateTime(2024, 3, 19, 11, 33, 5, 608, DateTimeKind.Local).AddTicks(1025), false, 1, null, null },
                    { 9L, 9, 1L, new DateTime(2024, 3, 19, 11, 33, 5, 608, DateTimeKind.Local).AddTicks(1133), false, 1, null, null },
                    { 10L, 10, 1L, new DateTime(2024, 3, 19, 11, 33, 5, 608, DateTimeKind.Local).AddTicks(1137), false, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "UserRoleMappings",
                columns: new[] { "UserRoleMappingId", "RoleId", "UserId" },
                values: new object[] { 1, 1, 1L });

            migrationBuilder.InsertData(
                table: "UserWiseViewMappers",
                columns: new[] { "UserWiseViewMapperId", "ApplicationId", "CreatedBy", "CreatedDate", "Deleted", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1L, 1, 1L, new DateTime(2024, 3, 19, 11, 33, 5, 608, DateTimeKind.Local).AddTicks(1878), false, null, null, 1L },
                    { 2L, 2, 1L, new DateTime(2024, 3, 19, 11, 33, 5, 608, DateTimeKind.Local).AddTicks(1882), false, null, null, 1L },
                    { 3L, 3, 1L, new DateTime(2024, 3, 19, 11, 33, 5, 608, DateTimeKind.Local).AddTicks(1885), false, null, null, 1L },
                    { 4L, 4, 1L, new DateTime(2024, 3, 19, 11, 33, 5, 608, DateTimeKind.Local).AddTicks(1888), false, null, null, 1L },
                    { 5L, 5, 1L, new DateTime(2024, 3, 19, 11, 33, 5, 608, DateTimeKind.Local).AddTicks(1891), false, null, null, 1L },
                    { 6L, 6, 1L, new DateTime(2024, 3, 19, 11, 33, 5, 608, DateTimeKind.Local).AddTicks(1894), false, null, null, 1L },
                    { 7L, 7, 1L, new DateTime(2024, 3, 19, 11, 33, 5, 608, DateTimeKind.Local).AddTicks(1898), false, null, null, 1L },
                    { 8L, 8, 1L, new DateTime(2024, 3, 19, 11, 33, 5, 608, DateTimeKind.Local).AddTicks(1901), false, null, null, 1L },
                    { 9L, 9, 1L, new DateTime(2024, 3, 19, 11, 33, 5, 608, DateTimeKind.Local).AddTicks(1904), false, null, null, 1L },
                    { 10L, 10, 1L, new DateTime(2024, 3, 19, 11, 33, 5, 608, DateTimeKind.Local).AddTicks(1907), false, null, null, 1L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplicationId1",
                table: "Applications",
                column: "ApplicationId1");

            migrationBuilder.CreateIndex(
                name: "IX_BrandWiseTargets_BrandId",
                table: "BrandWiseTargets",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_BrandWiseTargets_CategoryId",
                table: "BrandWiseTargets",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BrandWiseTargets_MonthId",
                table: "BrandWiseTargets",
                column: "MonthId");

            migrationBuilder.CreateIndex(
                name: "IX_BrandWiseTargets_SectorId",
                table: "BrandWiseTargets",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerOrderItems_BuyerOrderId",
                table: "BuyerOrderItems",
                column: "BuyerOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerOrderItems_ItemId",
                table: "BuyerOrderItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_ItemId",
                table: "Checkouts",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DistributorAssigns_BrandId",
                table: "DistributorAssigns",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_DistributorAssigns_DistributorRegistrationId",
                table: "DistributorAssigns",
                column: "DistributorRegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_DistributorAssigns_PinCodeId",
                table: "DistributorAssigns",
                column: "PinCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_DistributorRegistrations_WareHuoseId",
                table: "DistributorRegistrations",
                column: "WareHuoseId");

            migrationBuilder.CreateIndex(
                name: "IX_DPO_WareHuoseId",
                table: "DPO",
                column: "WareHuoseId");

            migrationBuilder.CreateIndex(
                name: "IX_DPOItems_DPOId",
                table: "DPOItems",
                column: "DPOId");

            migrationBuilder.CreateIndex(
                name: "IX_DPOItems_ItemId",
                table: "DPOItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DSOItems_DSOId",
                table: "DSOItems",
                column: "DSOId");

            migrationBuilder.CreateIndex(
                name: "IX_DSOItems_ItemId",
                table: "DSOItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAccounts_Domain",
                table: "EmailAccounts",
                column: "Domain");

            migrationBuilder.CreateIndex(
                name: "IX_Items_BrandId",
                table: "Items",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_PinCodeMappings_PinCodeId",
                table: "PinCodeMappings",
                column: "PinCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PinCodeMappings_WareHuoseId",
                table: "PinCodeMappings",
                column: "WareHuoseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderParents_SellerRegistrationId",
                table: "PurchaseOrderParents",
                column: "SellerRegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderParents_WareHuoseId",
                table: "PurchaseOrderParents",
                column: "WareHuoseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_ItemId",
                table: "PurchaseOrders",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_PurchaseOrderParentId",
                table: "PurchaseOrders",
                column: "PurchaseOrderParentId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_SellerRegistrationId",
                table: "PurchaseOrders",
                column: "SellerRegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAndApplicationWisePermissions_ApplicationId",
                table: "RoleAndApplicationWisePermissions",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAndApplicationWisePermissions_RoleId",
                table: "RoleAndApplicationWisePermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesAdminTargets_CategoryId",
                table: "SalesAdminTargets",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesAdminTargets_MonthId",
                table: "SalesAdminTargets",
                column: "MonthId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesAdminTargets_SalesManagerId",
                table: "SalesAdminTargets",
                column: "SalesManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesAdminTargets_SectorId",
                table: "SalesAdminTargets",
                column: "SectorId");

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

            migrationBuilder.CreateIndex(
                name: "IX_SalesManagerTargets_CategoryId",
                table: "SalesManagerTargets",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesManagerTargets_MonthId",
                table: "SalesManagerTargets",
                column: "MonthId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesManagerTargets_SectorId",
                table: "SalesManagerTargets",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesManagerTargets_UserId",
                table: "SalesManagerTargets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderItems_ItemId",
                table: "SalesOrderItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderItems_SalesOrderParentId",
                table: "SalesOrderItems",
                column: "SalesOrderParentId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderParents_WareHuoseId",
                table: "SalesOrderParents",
                column: "WareHuoseId");

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

            migrationBuilder.CreateIndex(
                name: "IX_SellerRegistrations_WareHuoseId",
                table: "SellerRegistrations",
                column: "WareHuoseId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_CategoryId",
                table: "Stocks",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ItemId",
                table: "Stocks",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_SectorId",
                table: "Stocks",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_UnitId",
                table: "Stocks",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_WareHuoseId",
                table: "Stocks",
                column: "WareHuoseId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitConversionFactors_FromUnitId",
                table: "UnitConversionFactors",
                column: "FromUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_UnitGroupId",
                table: "Units",
                column: "UnitGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMappings_RoleId",
                table: "UserRoleMappings",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMappings_UserId",
                table: "UserRoleMappings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWareHouseMappings_UserId",
                table: "UserWareHouseMappings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWareHouseMappings_WareHuoseId",
                table: "UserWareHouseMappings",
                column: "WareHuoseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWiseViewMappers_ApplicationId",
                table: "UserWiseViewMappers",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWiseViewMappers_UserId",
                table: "UserWiseViewMappers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityLogs");

            migrationBuilder.DropTable(
                name: "ActivityLogTypes");

            migrationBuilder.DropTable(
                name: "AddDistricts");

            migrationBuilder.DropTable(
                name: "Banners");

            migrationBuilder.DropTable(
                name: "BrandWiseTargets");

            migrationBuilder.DropTable(
                name: "BuyerOrderItems");

            migrationBuilder.DropTable(
                name: "BuyerRegistrations");

            migrationBuilder.DropTable(
                name: "ChangePasswords");

            migrationBuilder.DropTable(
                name: "Checkouts");

            migrationBuilder.DropTable(
                name: "CompanyDetails");

            migrationBuilder.DropTable(
                name: "DamageItemForFarmings");

            migrationBuilder.DropTable(
                name: "DamageItems");

            migrationBuilder.DropTable(
                name: "DeliveryPartners");

            migrationBuilder.DropTable(
                name: "DistributorAssigns");

            migrationBuilder.DropTable(
                name: "DistrictMappings");

            migrationBuilder.DropTable(
                name: "DPOItems");

            migrationBuilder.DropTable(
                name: "DSOItems");

            migrationBuilder.DropTable(
                name: "EmailAccounts");

            migrationBuilder.DropTable(
                name: "EmailTemplates");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ErrorLogs");

            migrationBuilder.DropTable(
                name: "InstalledApplications");

            migrationBuilder.DropTable(
                name: "ItemMasterForFarmings");

            migrationBuilder.DropTable(
                name: "LetterHeads");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "PinCodeMappings");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "RetailLogins");

            migrationBuilder.DropTable(
                name: "RetailModels");

            migrationBuilder.DropTable(
                name: "RoleAndApplicationWisePermissions");

            migrationBuilder.DropTable(
                name: "SalesAdminTargets");

            migrationBuilder.DropTable(
                name: "SalesExecutiveTargets");

            migrationBuilder.DropTable(
                name: "SalesManagerTargets");

            migrationBuilder.DropTable(
                name: "SalesOrderItems");

            migrationBuilder.DropTable(
                name: "SellerFarmingProducts");

            migrationBuilder.DropTable(
                name: "SellerProductEntrys");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "SubCategories3");

            migrationBuilder.DropTable(
                name: "SubCategories4");

            migrationBuilder.DropTable(
                name: "UnitConversionFactors");

            migrationBuilder.DropTable(
                name: "UserRoleMappings");

            migrationBuilder.DropTable(
                name: "UserWareHouseMappings");

            migrationBuilder.DropTable(
                name: "UserWiseViewMappers");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "VendorOnboardings");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "WareHouseSalesOrderItems");

            migrationBuilder.DropTable(
                name: "WarehouseSalesOrderParents");

            migrationBuilder.DropTable(
                name: "BuyerOrders");

            migrationBuilder.DropTable(
                name: "DistributorRegistrations");

            migrationBuilder.DropTable(
                name: "DPO");

            migrationBuilder.DropTable(
                name: "DSO");

            migrationBuilder.DropTable(
                name: "EmailDomains");

            migrationBuilder.DropTable(
                name: "PinCodes");

            migrationBuilder.DropTable(
                name: "PurchaseOrderParents");

            migrationBuilder.DropTable(
                name: "SalesManagers");

            migrationBuilder.DropTable(
                name: "SalesExecutiveRegistrations");

            migrationBuilder.DropTable(
                name: "Months");

            migrationBuilder.DropTable(
                name: "SalesOrderParents");

            migrationBuilder.DropTable(
                name: "GSTs");

            migrationBuilder.DropTable(
                name: "HandlingTypes");

            migrationBuilder.DropTable(
                name: "SubCategories1");

            migrationBuilder.DropTable(
                name: "SubCategories2");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Sectors");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SellerRegistrations");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "UnitGroups");

            migrationBuilder.DropTable(
                name: "WareHouses");
        }
    }
}
