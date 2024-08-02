using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Container;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using System.Xml.Linq;
using Traversal_Reservation.CQRS.Handlers.DestinationHandlers;
using Traversal_Reservation.Validators;

namespace Traversal_Reservation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddScoped<GetAllDestinationQueryHandler>();
            builder.Services.AddScoped<GetDestinationByIDQueryHandler>();
            builder.Services.AddScoped<CreateDestinationCommandHandler>();
            builder.Services.AddScoped<RemoveDestinationCommandHandler>();
            builder.Services.AddScoped<UpdateDestinationCommandHandler>();

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Program)));

            builder.Services.AddLogging(x =>
            {
                x.ClearProviders();
                x.SetMinimumLevel(LogLevel.Debug);
                x.AddDebug();

                
            });

            builder.Services.AddDbContext<Context>();
            builder.Services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<Context>()
                .AddErrorDescriber<CustomIdentityValidator>()
                .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider)
                .AddEntityFrameworkStores<Context>();

            builder.Services.AddHttpClient();

            builder.Services.ContainerDependencies();
            
            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.CustomValidator();

            builder.Services.AddControllersWithViews();
            builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

            builder.Services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            builder.Services.AddLocalization(opt =>
            {
                opt.ResourcesPath = "Resources";
            });

            builder.Services.AddMvc()
                .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            builder.Services.ConfigureApplicationCookie(opts =>
            {
                opts.LoginPath = "/SignIn/Index";
            });

            var app = builder.Build();

            var path = Directory.GetCurrentDirectory();
            var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
            loggerFactory.AddFile($"{path}\\logs\\log1.txt");

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            var supportedCultures = new[] { "en", "fr", "es", "gr", "tr", "de" };
            var localizationOptions = new RequestLocalizationOptions()
                .SetDefaultCulture(supportedCultures[4])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization(localizationOptions);

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Default}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

			app.Run();
        }
    }
}
