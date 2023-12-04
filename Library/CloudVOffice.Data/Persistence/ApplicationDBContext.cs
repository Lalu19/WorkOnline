using CloudVOffice.Core.Domain.Company;
using CloudVOffice.Core.Domain.Comunication;
using CloudVOffice.Core.Domain.EmailTemplates;
using CloudVOffice.Core.Domain.Logging;
using CloudVOffice.Core.Domain.Pemission;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Core.Domain.Users;
using CloudVOffice.Core.Domain.WareHouses;
using CloudVOffice.Core.Domain.WareHouses.Employees;
using CloudVOffice.Core.Domain.WareHouses.GST;
using CloudVOffice.Core.Domain.WareHouses.HandlingTypes;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Core.Domain.WareHouses.Vehicles;
using CloudVOffice.Core.Domain.WareHouses.Vendors;
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


        public virtual DbSet<Application> Applications { get; set; }

        public virtual DbSet<RoleAndApplicationWisePermission> RoleAndApplicationWisePermissions { get; set; }

        public virtual DbSet<UserWiseViewMapper> UserWiseViewMappers { get; set; }


        public virtual DbSet<InstalledApplication> InstalledApplications { get; set; }


        public virtual DbSet<EmailDomain> EmailDomains { get; set; }


        public virtual DbSet<EmailAccount> EmailAccounts { get; set; }
        public virtual DbSet<LetterHead> LetterHeads { get; set; }

        public virtual DbSet<CompanyDetails> CompanyDetails { get; set; }
        public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }
        public virtual DbSet<PinCode> PinCodes { get; set; }
        public virtual DbSet<WareHuose> WareHouses { get; set; }
		public virtual DbSet<PinCodeMapping> PinCodeMappings { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
		public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<GST> GSTs { get; set; }
        public virtual DbSet<HandlingType> HandlingTypes { get; set; }


        #endregion

        #region ProductCategories
        public virtual DbSet<Sector> Sectors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<SubCategory1> SubCategories1 { get; set; }
        public virtual DbSet<SubCategory2> SubCategories2 { get; set; }
        #endregion


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


            #endregion

            #region ProductCategories
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

			modelBuilder.Entity<Employee>()
			.Property(s => s.CreatedDate)
			.HasDefaultValueSql("getdate()");

			modelBuilder.Entity<Employee>()
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
            modelBuilder.Entity<Product>()
.Property(s => s.CreatedDate)
.HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Product>()
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

			#endregion


			modelBuilder.Seed();
        }
    }
}
