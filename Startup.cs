using BookStorePrueba.Claims;
using BookStorePrueba.Data.Context;
using BookStorePrueba.Models.Tables;
using BookStorePrueba.Services.Classes;
using BookStorePrueba.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStorePrueba
{
    public class Startup
    {
        private readonly IConfiguration Configuration = null;
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookStoreContext>(options => options.UseSqlServer(Configuration.GetValue<string>("ConnectionStrings:DefaultConnection")));

            services.AddIdentity<UserTable, IdentityRole>().AddEntityFrameworkStores<BookStoreContext>().AddDefaultTokenProviders();

      
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;


                options.SignIn.RequireConfirmedEmail = true;
                
                options.Lockout.MaxFailedAccessAttempts = 3;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            });

            //Aqui establecemos la ruta a retornar en caso de que no se haya loggeado.
            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/account/signin";
            });

            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromHours(1);
            });

            services.AddControllersWithViews();

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserClaimsPrincipalFactory<UserTable>, ApplicationUserClaimsPrincipalFactory>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmailService, EmailService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            

            app.UseAuthentication();
            
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
