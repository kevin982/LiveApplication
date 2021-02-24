using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BookStore.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using BookStore.Repository;
using Microsoft.AspNetCore.Identity;

namespace BookStore
{
    public class Startup
    {

        private readonly IConfiguration _fileConfiguration = null;

        public Startup(IConfiguration fileConfiguration)
        {
            _fileConfiguration = fileConfiguration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<BookStoreContext>(options => options.UseSqlServer(_fileConfiguration.GetValue<string>("ConnectionStrings:DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<BookStoreContext>();


            services.AddControllersWithViews();

#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation();
#endif

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ILanguageService, LanguageService>();
        
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


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseAuthentication();

        }
    }
}
