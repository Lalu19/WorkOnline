﻿using CloudVOffice.Core.Infrastructure.Http;
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
           
            services.AddScoped<IPinCodeService, PinCodeService>();
            services.AddScoped<IPinCodeMappingService, PinCodeMappingService>();
            //services.AddScoped<IWareHouseService, WareHouseService>();
            //services.AddScoped<IWareHouseService, WareHouseService>(); 
            services.AddScoped<IVehicleService, VehicleService>(); 
            services.AddScoped<IWareHouseService, WareHouseService>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<ISectorService, SectorService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISubCategory1Service, SubCategory1Service>();
            services.AddScoped<ISubCategory2Service, SubCategory2Service>();
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

            services.AddScoped<IDistrictService, DistrictService>();

            services.AddScoped<IDamageItemService, DamageItemService>();











            return services;

        }
    }
}