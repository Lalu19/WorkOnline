using CloudVOffice.Core.Infrastructure.Http;
using CloudVOffice.Data.Repository;
using CloudVOffice.Services.Applications;

using CloudVOffice.Services.Authentication;
using CloudVOffice.Services.Company;
using CloudVOffice.Services.Comunication;

using CloudVOffice.Services.Email;
using CloudVOffice.Services.EmailTemplates;

using CloudVOffice.Services.Permissions;

using CloudVOffice.Services.Roles;
using CloudVOffice.Services.Users;
using CloudVOffice.Services.WareHouse.PinCodes;
using CloudVOffice.Services.WareHouses;
using CloudVOffice.Services.WareHouses.PinCodes;
using CloudVOffice.Services.ProductCategories;
using CloudVOffice.Services.WareHouses.Vehicles;
using CloudVOffice.Services.WareHouses.Employees;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CloudVOffice.Services.WareHouses.Itemss;
using CloudVOffice.Services.WareHouses.Vendors;
using CloudVOffice.Services.WareHouses.GSTs;
using CloudVOffice.Services.WareHouses.HandlingTypes;
using CloudVOffice.Services.WareHouses.UOMs;
using CloudVOffice.Services.WareHouses.Districts;
using CloudVOffice.Services.Sales;
using CloudVOffice.Services.WareHouses.Months;
using CloudVOffice.Services.RetailerModel;
using CloudVOffice.Services.Buyers;
using CloudVOffice.Services.Sellers;
using CloudVOffice.Services.WareHouses.Brands;
using CloudVOffice.Services.Banners;
using CloudVOffice.Services.WareHouses.States;
using CloudVOffice.Services.WareHouses.PurchaseOrders;
using CloudVOffice.Services.Orders;
using CloudVOffice.Services.WareHouses.Stocks;
using CloudVOffice.Services.Logging;
using CloudVOffice.Core.Domain.Sellers;
using CloudVOffice.Services.WareHouses.SalesOrders;

namespace CloudVOffice.Web.Framework
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped(typeof(ISqlRepository<>), typeof(SqlRepository<>));
            services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserViewPermissions, UserViewPermissionService>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddScoped<IApplicationInstallationService, ApplicationInstallationService>();
            services.AddScoped<IHttpWebClients, HttpWebClients>();
            services.AddScoped<IEmailAccountService, EmailAccountService>();
            services.AddScoped<IEmailDomainService, EmailDomainService>();


            services.AddScoped<IEmailTemplateService, EmailTemplateService>();
            services.AddScoped<ICompanyDetailsService, CompanyDetailsService>();
            services.AddScoped<IEmailService, EmailService>();

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ILetterHeadService, LetterHeadService>();
            services.AddScoped<IErrorLogService, ErrorLogService>();
           
            services.AddScoped<IPinCodeService, PinCodeService>();
            services.AddScoped<IPinCodeMappingService, PinCodeMappingService>();
            //services.AddScoped<IWareHouseService, WareHouseService>();
            //services.AddScoped<IWareHouseService, WareHouseService>(); 
            services.AddScoped<IVehicleService, VehicleService>(); 
            services.AddScoped<IWareHouseService, WareHouseService>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<ISectorService, SectorService>();
            services.AddScoped<ICategoryService, CategoryService>();            
            services.AddScoped<ISubCategory1Service, SubCategory1Service>();
            services.AddScoped<ISubCategory2Service, SubCategory2Service>();
            services.AddScoped<ISubCategory3Service, SubCategory3Service>();
            services.AddScoped<ISubCategory4Service, SubCategory4Service>();




            services.AddScoped<IBrandService, BrandService>();

            services.AddScoped<IVendorService, VendorService>();
            services.AddScoped<IVendorOnboarding, VendorOnboardingService>();

            services.AddScoped<IGSTService, GSTService>();
            services.AddScoped<IHandlingTypeService, HandlingTypeService>();

			services.AddScoped<IItemService, ItemService>();
			services.AddScoped<IItemMasterForFarmingService, ItemMasterForFarmingService>();
            //Unit
            services.AddScoped<IUnitGroup, UnitGroupService>();

            services.AddScoped<IUnit, UnitService>();

            services.AddScoped<IUnitConversionFactors, UnitConversionFactorsService>();

            services.AddScoped<IDistrictMappingService, DistrictMappingService>();
            services.AddScoped<ISalesAdminService, SalesAdminService>();

            services.AddScoped<IDamageItemService, DamageItemService>();

            services.AddScoped<IDamageItemForFarmingService, DamageItemForFarmingService>();
			services.AddScoped<IAddDistrictService, AddDistrictService>();

            services.AddScoped<IMonthService, MonthService>();
            services.AddScoped<IBuyerRegistrationService, BuyerRegistrationService>();
            services.AddScoped<ISellerRegistrationService, SellerRegistrationService>();
            services.AddScoped<ISellerFarmingProductService, SellerFarmingProductService>();

            services.AddScoped<IRetailModelService, RetailModelService>();
            services.AddScoped<ISalesAdminService, SalesAdminService>();
            services.AddScoped<ISalesManagerTargetService, SalesManagerTargetService>();
            services.AddScoped<IBannerService, BannerService>();
            services.AddScoped<IStateService, StateService>();

            services.AddScoped<ISalesManagerService, SalesManagerService>();


            services.AddScoped<IBrandWiseTargetService, BrandWiseTargetService>();
            services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
            services.AddScoped<IPurchaseOrderParentService, PurchaseOrderParentService>();
            services.AddScoped<ICheckoutService, CheckoutService>();
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<ISellerProductEntryService, SellerProductEntryService>();
            services.AddScoped<ISalesOrderParentService, SalesOrderParentService>();
            services.AddScoped<ISalesOrderItemService, SalesOrderItemService>();
            


            return services;

        }
    }
}