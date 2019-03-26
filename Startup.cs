using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using her_care.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace her_care
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
            // services.Configure<CookiePolicyOptions>(options =>
            // {
            //     // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //     options.CheckConsentNeeded = context => true;
            //     options.MinimumSameSitePolicy = SameSiteMode.None;
            // });

            var username = Environment.GetEnvironmentVariable("your_username");
            var password = Environment.GetEnvironmentVariable("your_password");
            var connectionString = $"Server=tcp:hercareproj.database.windows.net,1433;Initial Catalog=HerCareDB;Persist Security Info=False;User ID={username};Password={password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            Console.WriteLine($"connectionString => {connectionString}");

            services.AddDbContext<HerCareContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddSession(options =>
        {
            // Set a short timeout for easy testing.
            options.IdleTimeout = TimeSpan.FromSeconds(10);
            options.Cookie.HttpOnly = true;
            // Make the session cookie essential
            options.Cookie.IsEssential = true;
        });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }


            //  app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseSession();
            
            app.UseMvc();
        }
    }
}