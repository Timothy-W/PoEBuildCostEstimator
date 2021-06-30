using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using BuildCostEstimator.DataAccess.Data;
using BuildCostEstimator.DataAccess.Initializer;
using BuildCostEstimator.DataAccess.Repository;
using BuildCostEstimator.DataAccess.Repository.IRepository;
using BuildCostEstimator.PriceCheck;
using BuildCostEstimator.PriceCheck.IPriceCheck;


namespace BuildCostEstimator
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging();
            });
            services.AddDatabaseDeveloperPageExceptionFilter();
           
            // Does removing this disable users completely?
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            
            services.AddMemoryCache();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddSingleton<IPriceCheckService, PriceCheckService>();
            services.AddControllersWithViews();
            services.AddHttpClient(); // General HttpClient
            services.AddHttpClient("PoeNinjaItemOverview",
                c => { c.BaseAddress = new Uri(Configuration.GetValue<string>("PoeNinjaAPI")); });
        }


        public void ConfigureProductionServices(IServiceCollection services)
        {
            var client = new SecretClient(new Uri("https://poebceproductionvault.vault.azure.net/"),
                new DefaultAzureCredential());
            KeyVaultSecret secret = client.GetSecret("ConnectionStrings");
            services.AddDbContext<ApplicationDbContext>(options => { options.UseSqlServer(secret.Value); });
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddMemoryCache();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddSingleton<IPriceCheckService, PriceCheckService>();
            services.AddControllersWithViews();
            services.AddHttpClient(); // General HttpClient
            services.AddHttpClient("PoeNinjaItemOverview",
                c => { c.BaseAddress = new Uri(Configuration.GetValue<string>("PoeNinjaAPI")); });
        }




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDbInitializer dbInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // Call migrations. Can also add initial database entries for things like Users
            dbInitializer.Initialize();

            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllerRoute(
                    name : "default",
                    pattern : "{area=User}/{controller=Home}/{action=Index}/{id?}"
                );


                endpoints.MapRazorPages();
            });
        }
    }
}
