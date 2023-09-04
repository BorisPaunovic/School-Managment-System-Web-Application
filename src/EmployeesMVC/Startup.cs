
using EmployeeMVC.IServices;
using EmployeeMVC.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using School.Services;
using School.Services.Interfaces;
using SMS.BusinessLogic;
using SMS.IBusinessLogic;
using SMS.IServices;
using SMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace EmployeesMVC
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
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ICountriesService, CountriesService>();
            services.AddScoped<ICountriesBusinessLogic, CountriesBusinessLogic>();
            services.AddScoped<ICourseBusinesLogic, CourseBusinessLogic>();
            services.AddScoped<ICoursesService, CoursesService>();
            services.AddScoped<ISubjectsBusinessLogic, SubjectsBusinessLogic>();
            services.AddScoped<ISubjectsService, SubjectsService>();
            services.AddScoped<ITeachersBusinessLogic, TeachersBusinessLogic>();
            services.AddScoped<ITeachersServices, TeachersServices>();
            
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
           
          
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
