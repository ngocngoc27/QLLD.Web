using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QL_LaoDong.Data;
using QL_LaoDong.Interfaces;
using QL_LaoDong.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong
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
            services.AddControllersWithViews();
            services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Server=HONGNGOC\SQLEXPRESS;Database=QLLD;Trusted_Connection=True;"));

            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IWorkTickerService,WorkTickerService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICalendarService, CalendarService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<IFacultyService, FacultyService>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IMenusService, MenusService>();
            services.AddScoped<IMusterService, MusterService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IToolService, ToolService>();
            services.AddScoped<ITooltickerService, TooltickerService>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
