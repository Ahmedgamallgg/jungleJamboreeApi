using Admin_Dashboard.Helpers;
using Admin_Dashboard.Repo.CampRepo;
using Admin_Dashboard.Settings;
using Core.Context;
using Core.Entites;
using dmin_Dashboard.Helpers;
using Infrastracture.Interfaces;

using Infrastructure.Reposatories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Service.BirthdayService.Service.Dtos;
using Service.CampService.Service.Dtos;
using Stripe;

namespace Admin_Dashboard
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<JungleJumboreeDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });


            builder.Services.AddIdentity<Users, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;

            }).AddEntityFrameworkStores<JungleJumboreeDbContext>();
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Admin/Login";
                options.AccessDeniedPath = "/Admin/AccessDenied";
            });
            builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
            builder.Services.AddTransient<IEmailService, EmailService>();
            builder.Services.AddScoped<ICampRepo, CampRepo>();

            builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            builder.Services.AddAutoMapper(typeof(CampProfile));

            builder.Services.AddAutoMapper(typeof(BirthdayProfile));
            builder.Services.AddAutoMapper(typeof(MapperProfile));



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Admin}/{action=Login}/{id?}");

            app.Run();
        }
    }
}