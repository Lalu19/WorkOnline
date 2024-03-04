using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.Reflection;
using System.Text;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Services.Plugins;
using CloudVOffice.Web.Framework;
using Hangfire;
using Syncfusion.Licensing;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Logging;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Distributor_partner
{
	public class Startup
	{
		public IConfiguration configRoot
		{
			get;
		}
		public Startup(IConfiguration configuration)
		{

			string licenseKey = "Mgo+DSMBMAY9C3t2VFhhQlJBfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5Xd0JiW39XdHNXRmBb\r\n";
			SyncfusionLicenseProvider.RegisterLicense(licenseKey);
			configRoot = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{


			services.AddDbContext<ApplicationDBContext>(options =>
			{
				//The name of the connection string is taken from appsetting.json under ConnectionStrings
				options.UseSqlServer(configRoot.GetConnectionString("ConnStringMssql"));
			});


			var audienceConfig = configRoot.GetSection("JWT");
			var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(audienceConfig["Secret"]));

			var tokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = signingKey,
				ValidateIssuer = true,
				ValidIssuer = audienceConfig["ValidIssuer"],
				ValidateAudience = true,
				ValidAudience = audienceConfig["ValidAudience"],
				ValidateLifetime = true,
				ClockSkew = TimeSpan.Zero,
				RequireExpirationTime = true,
			};

			services.AddAuthentication(options =>
			{
				options.DefaultScheme = "Custom";
				options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
			}).AddPolicyScheme("Custom", "Custom", options =>
			{
				options.ForwardDefaultSelector = context =>
				{
					// since all my api will be starting with /api, modify this condition as per your need.
					if (context.Request.Path.StartsWithSegments("/api", StringComparison.InvariantCulture))
						return JwtBearerDefaults.AuthenticationScheme;
					else
						return CookieAuthenticationDefaults.AuthenticationScheme;
				};
			}).AddCookie(x =>
			{
				x.LoginPath = "/DistributorPartner/DistributorLogin";

				x.ExpireTimeSpan = TimeSpan.FromMinutes(60);
				x.SlidingExpiration = true;
				x.AccessDeniedPath = "/Forbidden/";

			}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
			{
				options.RequireHttpsMetadata = false;
				options.SaveToken = true;
				options.TokenValidationParameters = tokenValidationParameters;

			});
			IdentityModelEventSource.ShowPII = true;
			// Add Hangfire services.
			services.AddHangfire(configuration => configuration
				.SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
				.UseSimpleAssemblyNameTypeSerializer()
				.UseRecommendedSerializerSettings()
				.UseSqlServerStorage(configRoot.GetConnectionString("ConnStringMssql")));
			// Add the processing server as IHostedService
			services.AddHangfireServer();


			services.AddHttpContextAccessor();
			var mvcBuilder = services.AddControllersWithViews();
			mvcBuilder.AddRazorRuntimeCompilation();

			services.AddRazorPages();
			mvcBuilder.AddNewtonsoftJson(delegate (MvcNewtonsoftJsonOptions options)
			{
				options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
			});

			var mvcCoreBuilder = services.AddMvcCore();
			foreach (string folder in Directory.GetDirectories(CloudVOfficePluginDefaults.PathName))
			{

				string dllPath = CloudVOfficePluginDefaults.PathName + @"\" + folder.Split(@"\")[1].ToString() + @"\" + folder.Split(@"\")[1].ToString() + ".dll";
				if (File.Exists(dllPath))
				{
					Assembly assembly2 = Assembly.LoadFrom(dllPath);
					AssemblyPart part2 = new AssemblyPart(assembly2);

					services.AddControllersWithViews().AddRazorRuntimeCompilation().PartManager.ApplicationParts.Add(part2);
					string depsPathPath = CloudVOfficePluginDefaults.PathName + @"\" + folder.Split(@"\")[1].ToString() + @"\" + folder.Split(@"\")[1].ToString() + ".deps.json";
					if (File.Exists(depsPathPath))
					{
						File.Delete(depsPathPath);
					}

				}
			}
			mvcBuilder.AddControllersAsServices();
			services.AddInfrastructure(configRoot);


			////	services.AddInfrastructure(configRoot);

			// services.AddScoped(IAuthenticationService, AuthenticationService);
			// services.AddScoped(IAuthenticationService, AuthenticationService);
			//  services.AddDbContext<ApplicationDBContext>()


		}
		public void Configure(WebApplication app, IWebHostEnvironment env)
		{
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseStaticFiles(new StaticFileOptions
			{
				FileProvider = new PhysicalFileProvider(
				Path.Combine(env.ContentRootPath, "Plugins")),
				RequestPath = "/Plugin"
			});

			app.UseRouting();
			app.UseAuthorization();

			app.MapControllerRoute(
			name: "default",
			pattern: "{controller=DistributorPartner}/{action=DistributorLogin}/{id?}");

			app.MapControllerRoute(
			  name: "areas",
			  pattern: "{area:exists}/{controller=DistributorPartner}/{action=DistributorLogin}/{id?}"
			);


			app.MapRazorPages();
			app.Run();
		}


	}
}
