using CloudVOffice.Core.Domain.Banners;
using CloudVOffice.Core.Domain.Buyers;
using CloudVOffice.Core.Domain.Company;
using CloudVOffice.Core.Domain.Comunication;
using CloudVOffice.Core.Domain.EmailTemplates;
using CloudVOffice.Core.Domain.Logging;
using CloudVOffice.Core.Domain.Orders;
using CloudVOffice.Core.Domain.Pemission;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Core.Domain.RetailerModel;
using CloudVOffice.Core.Domain.Sales;
using CloudVOffice.Core.Domain.Sellers;
using CloudVOffice.Core.Domain.Users;
using CloudVOffice.Core.Domain.WareHouses;
using CloudVOffice.Core.Domain.WareHouses.Brands;
using CloudVOffice.Core.Domain.WareHouses.Districts;
using CloudVOffice.Core.Domain.WareHouses.Employees;
using CloudVOffice.Core.Domain.WareHouses.GST;
using CloudVOffice.Core.Domain.WareHouses.HandlingTypes;
using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Core.Domain.WareHouses.Months;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Core.Domain.WareHouses.PurchaseOrders;
using CloudVOffice.Core.Domain.WareHouses.States;
using CloudVOffice.Core.Domain.WareHouses.Stocks;
using CloudVOffice.Core.Domain.WareHouses.UOMs;
using CloudVOffice.Core.Domain.WareHouses.Vehicles;
using CloudVOffice.Core.Domain.WareHouses.Vendors;
//using CloudVOffice.Data.Migrations;
using CloudVOffice.Data.Seeding;
using Microsoft.EntityFrameworkCore;


namespace CloudVOffice.Data.Persistence
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
         : base(options)
        {

        }
        #region

        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<ActivityLogType> ActivityLogTypes { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }
        public virtual DbSet<Log> Logs { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserRoleMapping> UserRoleMappings { get; set; }
        public virtual DbSet<UserWareHouseMapping> UserWareHouseMappings { get; set; }


        public virtual DbSet<Application> Applications { get; set; }

        public virtual DbSet<RoleAndApplicationWisePermission> RoleAndApplicationWisePermissions { get; set; }

        public virtual DbSet<UserWiseViewMapper> UserWiseViewMappers { get; set; }


        public virtual DbSet<InstalledApplication> InstalledApplications { get; set; }


        public virtual DbSet<EmailDomain> EmailDomains { get; set; }


        public virtual DbSet<EmailAccount> EmailAccounts { get; set; }
        public virtual DbSet<LetterHead> LetterHeads { get; set; }

        public virtual DbSet<CompanyDetails> CompanyDetails { get; set; }
        public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }

		#endregion

		#region WareHouse

		public virtual DbSet<PinCode> PinCodes { get; set; }
		public virtual DbSet<WareHuose> WareHouses { get; set; }
		public virtual DbSet<PinCodeMapping> PinCodeMappings { get; set; }
		public virtual DbSet<Vehicle> Vehicles { get; set; }
		public virtual DbSet<Employee> Employees { get; set; }
		public virtual DbSet<Item> Items { get; set; }
		public virtual DbSet<Vendor> Vendors { get; set; }
		public virtual DbSet<VendorOnboarding> VendorOnboardings { get; set; }
		public virtual DbSet<ItemMasterForFarming> ItemMasterForFarmings { get; set; }
		public virtual DbSet<Sector> Sectors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }        
        public virtual DbSet<SubCategory1> SubCategories1 { get; set; }
        public virtual DbSet<SubCategory2> SubCategories2 { get; set; }
        public virtual DbSet<SubCategory3> SubCategories3 { get; set; }
        public virtual DbSet<SubCategory4> SubCategories4 { get; set; }
        public virtual DbSet<GST> GSTs { get; set; }
		public virtual DbSet<HandlingType> HandlingTypes { get; set; }
		public virtual DbSet<UnitGroup> UnitGroups { get; set; }
		public virtual DbSet<Unit> Units { get; set; }
		public virtual DbSet<UnitConversionFactors> UnitConversionFactors { get; set; }
		public virtual DbSet<DistrictMapping> DistrictMappings { get; set; }
		public virtual DbSet<DamageItem> DamageItems { get; set; }
		public virtual DbSet<DamageItemForFarming> DamageItemForFarmings { get; set; }
		public virtual DbSet<AddDistrict> AddDistricts { get; set; }
        public virtual DbSet<Month> Months { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
		public virtual DbSet<State> States { get; set; }
		public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<PurchaseOrderParent> PurchaseOrderParents { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<SellerProductEntry> SellerProductEntrys { get; set; }
        public virtual DbSet<SellerFarmingProduct> SellerFarmingProducts { get; set; }
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }



        #endregion

        #region Sales

        public virtual DbSet<SalesAdminTarget> SalesAdminTargets { get; set; }
        public virtual DbSet<SalesManagerTarget> SalesManagerTargets { get; set; }
		#endregion

		#region Orders
		public virtual DbSet<Checkout> Checkouts { get; set; }

		#endregion

		public virtual DbSet<RetailLogin> RetailLogins { get; set; }
		public virtual DbSet<BuyerRegistration> BuyerRegistrations { get; set; }
		public virtual DbSet<SellerRegistration> SellerRegistrations { get; set; }

        public virtual DbSet<RetailModel> RetailModels { get; set; }
        public virtual DbSet<ChangePassword> ChangePasswords { get; set; }
        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<BrandWiseTarget> BrandWiseTargets { get; set; }
		public virtual DbSet<SalesManager> SalesManagers { get; set; }		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Base

            modelBuilder.Entity<RefreshToken>()
       .Property(s => s.CreatedDate)
       .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<RefreshToken>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();



            modelBuilder.Entity<Role>()
        .Property(s => s.CreatedDate)
        .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Role>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();


            modelBuilder.Entity<User>()
        .Property(s => s.CreatedDate)
        .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<User>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();

            modelBuilder.Entity<UserWareHouseMapping>()
       .Property(s => s.CreatedDate)
       .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<UserWareHouseMapping>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();


            modelBuilder.Entity<Application>()
        .Property(s => s.CreatedDate)
        .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Application>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();


            modelBuilder.Entity<RoleAndApplicationWisePermission>()
      .Property(s => s.CreatedDate)
      .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<RoleAndApplicationWisePermission>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();




            modelBuilder.Entity<UserWiseViewMapper>()
      .Property(s => s.CreatedDate)
      .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<UserWiseViewMapper>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();



            modelBuilder.Entity<InstalledApplication>()
      .Property(s => s.CreatedDate)
      .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<InstalledApplication>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();



            modelBuilder.Entity<EmailDomain>()
      .Property(s => s.CreatedDate)
      .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<EmailDomain>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();



            modelBuilder.Entity<EmailAccount>()
.Property(s => s.CreatedDate)
.HasDefaultValueSql("getdate()");

            modelBuilder.Entity<EmailAccount>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();





            modelBuilder.Entity<LetterHead>()
.Property(s => s.CreatedDate)
.HasDefaultValueSql("getdate()");

            modelBuilder.Entity<LetterHead>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();



            modelBuilder.Entity<CompanyDetails>()
.Property(s => s.CreatedDate)
.HasDefaultValueSql("getdate()");

            modelBuilder.Entity<CompanyDetails>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();



            modelBuilder.Entity<EmailTemplate>()
.Property(s => s.CreatedDate)
.HasDefaultValueSql("getdate()");

            modelBuilder.Entity<EmailTemplate>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();


            modelBuilder.Entity<UserWiseViewMapper>()
.Property(s => s.CreatedDate)
.HasDefaultValueSql("getdate()");

            modelBuilder.Entity<UserWiseViewMapper>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();



			#endregion

			#region Warehouse



			modelBuilder.Entity<PinCode>()
.Property(s => s.CreatedDate)
.HasDefaultValueSql("getdate()");

			modelBuilder.Entity<PinCode>()
			 .Property(s => s.Deleted)
			 .HasDefaultValue(false)
			 .ValueGeneratedNever();



			modelBuilder.Entity<WareHuose>()
			.Property(s => s.CreatedDate)
			.HasDefaultValueSql("getdate()");

			modelBuilder.Entity<WareHuose>()
			 .Property(s => s.Deleted)
			 .HasDefaultValue(false)
			 .ValueGeneratedNever();


			modelBuilder.Entity<PinCodeMapping>()
.Property(s => s.CreatedDate)
.HasDefaultValueSql("getdate()");

			modelBuilder.Entity<PinCodeMapping>()
			 .Property(s => s.Deleted)
			 .HasDefaultValue(false)
			 .ValueGeneratedNever();


			modelBuilder.Entity<Vehicle>()
.Property(s => s.CreatedDate)
.HasDefaultValueSql("getdate()");

			modelBuilder.Entity<Vehicle>()
			 .Property(s => s.Deleted)
			 .HasDefaultValue(false)
			 .ValueGeneratedNever();


			modelBuilder.Entity<ItemMasterForFarming>()
.Property(s => s.CreatedDate)
.HasDefaultValueSql("getdate()");

			modelBuilder.Entity<ItemMasterForFarming>()
			 .Property(s => s.Deleted)
			 .HasDefaultValue(false)
			 .ValueGeneratedNever();


            modelBuilder.Entity<Employee>()
			.Property(s => s.CreatedDate)
			.HasDefaultValueSql("getdate()");

			modelBuilder.Entity<Employee>()
			 .Property(s => s.Deleted)
			 .HasDefaultValue(false)
			 .ValueGeneratedNever();


            modelBuilder.Entity<Item>()
            .Property(s => s.CreatedDate)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Item>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();            


            modelBuilder.Entity<Vendor>()
.Property(s => s.CreatedDate)
.HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Vendor>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();


			modelBuilder.Entity<VendorOnboarding>()
.Property(s => s.CreatedDate)
.HasDefaultValueSql("getdate()");

			modelBuilder.Entity<VendorOnboarding>()
			 .Property(s => s.Deleted)
			 .HasDefaultValue(false)
			 .ValueGeneratedNever();

			modelBuilder.Entity<Sector>()
.Property(s => s.CreatedDate)
.HasDefaultValueSql("getdate()");

			modelBuilder.Entity<Sector>()
			 .Property(s => s.Deleted)
			 .HasDefaultValue(false)
			 .ValueGeneratedNever();

			modelBuilder.Entity<Category>()
.Property(s => s.CreatedDate)
.HasDefaultValueSql("getdate()");

			modelBuilder.Entity<Category>()
			 .Property(s => s.Deleted)
			 .HasDefaultValue(false)
			 .ValueGeneratedNever();

            modelBuilder.Entity<SubCategory1>()
.Property(s => s.CreatedDate)
.HasDefaultValueSql("getdate()");

            modelBuilder.Entity<SubCategory1>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();

            modelBuilder.Entity<SubCategory2>()
.Property(s => s.CreatedDate)
.HasDefaultValueSql("getdate()");

            modelBuilder.Entity<SubCategory2>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();

            modelBuilder.Entity<SubCategory3>()
.Property(s => s.CreatedDate)
.HasDefaultValueSql("getdate()");

            modelBuilder.Entity<SubCategory3>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();

            modelBuilder.Entity<SubCategory4>()
.Property(s => s.CreatedDate)
.HasDefaultValueSql("getdate()");

            modelBuilder.Entity<SubCategory4>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();

            modelBuilder.Entity<GST>()
           .Property(s => s.CreatedDate)
           .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<GST>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();

            modelBuilder.Entity<HandlingType>()
         .Property(s => s.CreatedDate)
         .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<HandlingType>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();


			modelBuilder.Entity<UnitGroup>()
 .Property(s => s.CreatedDate)
 .HasDefaultValueSql("getdate()");

			modelBuilder.Entity<UnitGroup>()
			 .Property(s => s.Deleted)
			 .HasDefaultValue(false)
			 .ValueGeneratedNever();

			modelBuilder.Entity<UnitConversionFactors>()
 .Property(s => s.CreatedDate)
 .HasDefaultValueSql("getdate()");

			modelBuilder.Entity<UnitConversionFactors>()
			 .Property(s => s.Deleted)
			 .HasDefaultValue(false)
			 .ValueGeneratedNever();

			modelBuilder.Entity<DistrictMapping>()
 .Property(s => s.CreatedDate)
 .HasDefaultValueSql("getdate()");

			modelBuilder.Entity<DistrictMapping>()
			 .Property(s => s.Deleted)
			 .HasDefaultValue(false)
			 .ValueGeneratedNever();

			modelBuilder.Entity<DamageItem>()
 .Property(s => s.CreatedDate)
 .HasDefaultValueSql("getdate()");

			modelBuilder.Entity<DamageItem>()
			 .Property(s => s.Deleted)
			 .HasDefaultValue(false)
			 .ValueGeneratedNever();

			modelBuilder.Entity<DamageItemForFarming>()
.Property(s => s.CreatedDate)
.HasDefaultValueSql("getdate()");

			modelBuilder.Entity<DamageItemForFarming>()
			 .Property(s => s.Deleted)
			 .HasDefaultValue(false)
			 .ValueGeneratedNever();


            modelBuilder.Entity<AddDistrict>()
.Property(s => s.CreatedDate)
.HasDefaultValueSql("getdate()");

            modelBuilder.Entity<AddDistrict>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();


            modelBuilder.Entity<Month>()
.Property(s => s.CreatedDate)
.HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Month>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();

            modelBuilder.Entity<Brand>()
.Property(s => s.CreatedDate)
.HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Brand>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();

            modelBuilder.Entity<State>()
              .Property(s => s.CreatedDate)
              .HasDefaultValueSql("getdate()");


            modelBuilder.Entity<State>()
              .Property(s => s.Deleted)
              .HasDefaultValue(false)
              .ValueGeneratedNever();

			modelBuilder.Entity<PurchaseOrder>()
			.Property(s => s.CreatedDate)
			.HasDefaultValueSql("getdate()");


			modelBuilder.Entity<PurchaseOrder>()
			  .Property(s => s.Deleted)
			  .HasDefaultValue(false)
			  .ValueGeneratedNever();

            modelBuilder.Entity<PurchaseOrderParent>()
            .Property(s => s.CreatedDate)
            .HasDefaultValueSql("getdate()");


            modelBuilder.Entity<PurchaseOrderParent>()
              .Property(s => s.Deleted)
              .HasDefaultValue(false)
              .ValueGeneratedNever();

			modelBuilder.Entity<Stock>()
			.Property(s => s.CreatedDate)
			.HasDefaultValueSql("getdate()");


			modelBuilder.Entity<Stock>()
			  .Property(s => s.Deleted)
			  .HasDefaultValue(false)
			  .ValueGeneratedNever();



			#endregion

			#region Sales

			modelBuilder.Entity<SalesAdminTarget>()
	.Property(s => s.CreatedDate)
	.HasDefaultValueSql("getdate()");

			modelBuilder.Entity<SalesAdminTarget>()
			 .Property(s => s.Deleted)
			 .HasDefaultValue(false)
			 .ValueGeneratedNever();

            modelBuilder.Entity<BrandWiseTarget>()
   .Property(s => s.CreatedDate)
   .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<BrandWiseTarget>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();


			#endregion

			#region Orders
			modelBuilder.Entity<Checkout>()
	   .Property(s => s.CreatedDate)
	   .HasDefaultValueSql("getdate()");

			modelBuilder.Entity<Checkout>()
			 .Property(s => s.Deleted)
			 .HasDefaultValue(false)
			.ValueGeneratedNever();
			#endregion



			modelBuilder.Entity<RetailModel>()
           .Property(s => s.CreatedDate)
           .HasDefaultValueSql("getdate()");
	
            modelBuilder.Entity<RetailModel>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
            .ValueGeneratedNever();

            modelBuilder.Entity<RetailLogin>()
                    .Property(s => s.CreatedDate)
                    .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<RetailLogin>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();

            modelBuilder.Entity<BuyerRegistration>()
                .Property(s => s.CreatedDate)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<BuyerRegistration>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();

            modelBuilder.Entity<SellerRegistration>()
                .Property(s => s.CreatedDate)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<SellerRegistration>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();

            modelBuilder.Entity<SalesManagerTarget>()
                .Property(s => s.CreatedDate)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<SalesManagerTarget>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();

            modelBuilder.Entity<ChangePassword>()
                .Property(s => s.CreatedDate)
                .HasDefaultValueSql("getdate()");


            modelBuilder.Entity<ChangePassword>()
              .Property(s => s.Deleted)
              .HasDefaultValue(false)
              .ValueGeneratedNever();

			modelBuilder.Entity<Banner>()
			.Property(s => s.CreatedDate)
			.HasDefaultValueSql("getdate()");


			modelBuilder.Entity<Banner>()
			  .Property(s => s.Deleted)
			  .HasDefaultValue(false)
			  .ValueGeneratedNever();

			modelBuilder.Entity<SalesManager>()
			.Property(s => s.CreatedDate)
			.HasDefaultValueSql("getdate()");


			modelBuilder.Entity<SalesManager>()
			  .Property(s => s.Deleted)
			  .HasDefaultValue(false)
			  .ValueGeneratedNever();

            modelBuilder.Entity<SellerProductEntry>()
            .Property(s => s.CreatedDate)
            .HasDefaultValueSql("getdate()");


            modelBuilder.Entity<SellerProductEntry>()
              .Property(s => s.Deleted)
              .HasDefaultValue(false)
              .ValueGeneratedNever();

            modelBuilder.Entity<SellerFarmingProduct>()
            .Property(s => s.CreatedDate)
            .HasDefaultValueSql("getdate()");


            modelBuilder.Entity<SellerFarmingProduct>()
              .Property(s => s.Deleted)
              .HasDefaultValue(false)
              .ValueGeneratedNever();

            modelBuilder.Seed();
        }
    }
}
