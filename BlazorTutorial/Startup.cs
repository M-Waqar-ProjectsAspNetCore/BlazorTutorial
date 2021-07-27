using Blazored.SessionStorage;
using BlazorTutorial.Data;
using BlazorTutorial.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;

namespace BlazorTutorial
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            #region Connection String
            services.AddDbContext<AppContext>(item => 
                item.UseSqlServer(Configuration.GetConnectionString("BlazorTutorial")));
            #endregion

            //// For Authentication
            //services.AddControllers();
            //services.AddAuthentication("Blazor.CookieAuth")
            //    .AddCookie("Blazor.CookieAuth", config =>
            //    {
            //        config.Cookie.Name = "Blazor.CookieAuth";
            //        config.LoginPath = "/";
            //        config.SlidingExpiration = true;
            //        config.ExpireTimeSpan = System.TimeSpan.FromMinutes(2000);
            //    });

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<HttpClient>();
            services.AddSingleton<WeatherForecastService>();
            services.AddBlazoredSessionStorage();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
