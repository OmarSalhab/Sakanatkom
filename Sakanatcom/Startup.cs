using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sakanatcom.Data;
using Sakanatcom.Models;
using Sakanatcom.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Sakanatcom
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(services => services.EnableEndpointRouting = false);
            services.AddScoped<IRepository<MasterCategoryMenu>, DbMasterCategoryMenuRepository>();
            services.AddScoped<IRepository<MasterContactUsInformation>, DbMasterContactUsInformationRepository>();
            services.AddScoped<IRepository<MasterItemMenu>, DbMasterItemMenuRepository>();
            services.AddScoped<IRepository<MasterMenu>, DbMasterMenuRepository>();
            services.AddScoped<IRepository<MasterOffer>, DbMasterOfferRepository>();
            services.AddScoped<IRepository<MasterPartner>, DbMasterPartnerRepository>();
            services.AddScoped<IRepository<MasterService>, DbMasterServiceRepository>();
            services.AddScoped<IRepository<MasterSlider>, DbMasterSliderRepository>();
            services.AddScoped<IRepository<MasterSocialMedia>, DbMasterSocialMediaRepository>();
            services.AddScoped<IRepository<MasterWorkingHour>, DbMasterWorkingHourRepository>();
            services.AddScoped<IRepository<SystemSetting>, DbSystemSettingRepository>();
            services.AddScoped<IRepository<TransactionBookTable>, DbTransactionBookTableRepository>();
            services.AddScoped<IRepository<TransactionContactUs>, DbTransactionContactUsRepository>();
            services.AddScoped<IRepository<TransactionNewsletter>, DbTransactionNewsletterRepository>();
            services.AddScoped<IRepository<MasterAbout>, DbMasterAboutRepository>();
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Admin/Account/Login";
            });
            services.AddDbContext<AppDbContext>(DbContext =>
            {
                DbContext.UseSqlServer(Configuration.GetConnectionString("SqlConn"));
            });
            services.Configure<IdentityOptions>(passwordConfig =>
            {
                passwordConfig.Password.RequireDigit = false;
                passwordConfig.Password.RequireLowercase = false;
                passwordConfig.Password.RequireUppercase = false;
                passwordConfig.Password.RequireNonAlphanumeric = false;
                passwordConfig.Password.RequiredUniqueChars = 0;
                passwordConfig.Password.RequiredLength = 3;
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "kareemmaher2002@icloud.com");
                });

            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireStudentEmail", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireAssertion(context =>
                    {
                        var userEmailClaim = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
                        return userEmailClaim != null && userEmailClaim.Value.Contains("@std");
                    });
                });
            });
            services.AddScoped<IAuthorizationFilter>(provider =>
            {
                return new BlockEmailAuthorizationFilter("@std");
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStatusCodePagesWithRedirects("/Account/AccessDenied"); // Add this line to handle 403 (Forbidden) status codes

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}",
                    defaults: new { area = "Admin" }
                );

                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

         
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}",
                    defaults: new { area = "Admin", controller = "Home", action = "Index" }
                );
            });
        }

    }
}
