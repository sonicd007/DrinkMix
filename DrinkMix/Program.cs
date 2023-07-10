using DrinkMix.BusinessLogic.Services.Interfaces;
using DrinkMix.Data;
using DrinkMix.Models;
using DrinkMix.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using System.Reflection;
using DrinkMix.BusinessLogic.AutoMapperMappings;

namespace DrinkMix
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var drinkMixConnectionString = builder.Configuration["DrinkMixDatabase:ConnectionString"] ?? throw new InvalidOperationException("Connection string 'DrinkMixDatabase' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(drinkMixConnectionString,
                ServerVersion.AutoDetect(drinkMixConnectionString)));

            builder.Services.AddDbContext<DrinkMixDbContext>(options =>
                options.UseMySql(drinkMixConnectionString,
                ServerVersion.AutoDetect(drinkMixConnectionString)));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            builder.Services.AddAuthentication()
                .AddIdentityServerJwt();

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            // Configure Automapper
            List<Assembly> assemblies = new List<Assembly>
            {
                Assembly.GetExecutingAssembly(),
                typeof(DTOMappingProfile).Assembly
            };
            builder.Services.AddAutoMapper(assemblies);

            // Configure DI
            builder.Services.AddScoped<IRecipeService, RecipeService>();

            // Configure Swagger
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", 
                new OpenApiInfo
                {
                    Version = "v1",//this v was in caps earlier
                    Title = "DrinkMix API",
                    Description = "A modern cocktail recipe app."
                });
            });

            var app = builder.Build();
            // Validate automapper profiles
            var mapper = app.Services.GetRequiredService<IMapper>();
            mapper.ConfigurationProvider.AssertConfigurationIsValid();

            // Configure the HTTP request pipeline. 
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}