using AdminDashboardBLL.Feature.Interface;
using AdminDashboardBLL.Feature.Repository;
using AdminDashboardDAL.Context;

using DashboardBLL.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DashboardPL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            //AutoMapper
            builder.Services.AddAutoMapper(AutoMapperConfig => AutoMapperConfig.AddProfile(new DomainProfile()));

            //builder.Services.AddAutoMapper(typeof(DomainProfile));



            //Add Scoped
            builder.Services.AddScoped<IDepartment, DepartmentRepository>();

            // Enhancement ConnectionString
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
