using Business.Abstract;
using Business.Concrete;
using Business.Mapper;
using Business.Validations;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.SqlServerDBContext;
using Entities.Concrete.TableModels.Membership;
using Entities.TableModels;
using FluentValidation;
using FluentValidation.Resources;
using MedicalArticles.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Reflection;
using static MedicalArticles.Services.LanguageService;

namespace MedicalArticles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

      
            builder.Services.AddDbContext<ApplicationDbContext>()
                .AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddScoped<ICategoryService, CategoryManager>();
            builder.Services.AddScoped<ICategoryDal, CategoryDal>();
            builder.Services.AddScoped<IValidator<Category>, CategoryValidation>();

            builder.Services.AddScoped<IAboutService, AboutManager>();
            builder.Services.AddScoped<IAboutDal, AboutDal>();
            builder.Services.AddScoped<IValidator<About>, AboutValidation>();
            
            builder.Services.AddScoped<IAdressService, AdressManager>();
            builder.Services.AddScoped<IAdressDal, AdressDal>();
            builder.Services.AddScoped<IValidator<Adress>, AdressValidation>();

            builder.Services.AddScoped<IContactService, ContactManager>();
            builder.Services.AddScoped<IContactDal, ContactDal>();
            builder.Services.AddScoped<IValidator<Contact>, ContactValidation>();

            builder.Services.AddScoped<IFaqService, FaqManager>();
            builder.Services.AddScoped<IFaqDal, FaqDal>();
            builder.Services.AddScoped<IValidator<Faq>, FaqValidation>();


            builder.Services.AddScoped<ISosialService, SosialManager>();
            builder.Services.AddScoped<ISosialDal, SosialDal>();
            builder.Services.AddScoped<IValidator<Sosial>, SosialValidation>();

            builder.Services.AddScoped<ISlideService, SlideManager>();
            builder.Services.AddScoped<ISlideDal, SlideDal>();
            builder.Services.AddScoped<IValidator<Slide>, SlideValidation>();

            builder.Services.AddScoped<IServiceService, ServiceManager>();
            builder.Services.AddScoped<IServiceDal, ServiceDal>();
            builder.Services.AddScoped<IValidator<Service>, ServiceValidation>();

            builder.Services.AddScoped<IServiceAboutService, ServiceAboutManager>();
            builder.Services.AddScoped<IServiceAboutDal, ServiceAboutDal>();
            builder.Services.AddScoped<IValidator<ServiceAbout>, ServiceAboutValidation>();

            builder.Services.AddScoped<IServiceAboutItemService, ServiceAboutItemManager>();
            builder.Services.AddScoped<IServiceAboutItemDal, ServiceAboutItemDal>();
            builder.Services.AddScoped<IValidator<ServiceAboutItem>, ServiceAboutItemValidation>();

            builder.Services.AddScoped<ITeamBoardService, TeamBoardManager>();
            builder.Services.AddScoped<ITeamBoardDal, TeamBoardDal>();
            builder.Services.AddScoped<IValidator<TeamBoard>, TeamBoardValidation>();

            builder.Services.AddScoped<IHealthTipService, HealthTipManager>();
            builder.Services.AddScoped<IHealthTipDal, HealthTipDal>();
            builder.Services.AddScoped<IValidator<HealthTip>, HealthTipValidation>();

            builder.Services.AddScoped<IHealthTipItemService, HealthTipItemManager>();
            builder.Services.AddScoped<IHealthTipItemDal, HealthTipItemDal>();
            builder.Services.AddScoped<IValidator<HealthTipItem>, HealthTipItemValidation>();

            builder.Services.AddScoped<IWhyChooseUsService, WhyChooseUsManager>();
            builder.Services.AddScoped<IWhyChooseUsDal, WhyChooseUsDal>();
            builder.Services.AddScoped<IValidator<WhyChooseUs>, WhyChooseUsValidation>();

            builder.Services.AddScoped<IWhyChooseUsItemService, WhyChooseUsItemManager>();
            builder.Services.AddScoped<IWhyChooseUsItemDal, WhyChooseUsItemDal>();
            builder.Services.AddScoped<IValidator<WhyChooseUsItem>, WhyChooseUsItemValidation>();


            builder.Services.AddScoped<IStatisticService, StatisticManager>();
            builder.Services.AddScoped<IStatisticDal, StatisticDal>();
            builder.Services.AddScoped<IValidator<Statistic>, StatisticValidation>();


            builder.Services.AddScoped<ILanguageService, Business.Concrete.LanguageManager>();
            builder.Services.AddScoped<ILanguageDal, LanguageDal>();


            builder.Services.AddSingleton<LanguageService>();
            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            builder.Services.AddMvc().AddViewLocalization().AddDataAnnotationsLocalization(options =>
            {
                var assemblyName = new AssemblyName(typeof(SharedResource).Assembly.FullName);
                options.DataAnnotationLocalizerProvider = (type, factory) =>
                    factory.Create(nameof(SharedResource), assemblyName.Name);
            });

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[] { "az-Latn", "en-US", "ru-RU" };
                options.DefaultRequestCulture = new RequestCulture("az-Latn", "az-Latn");
                options.SupportedCultures = supportedCultures.Select(culture => new CultureInfo(culture)).ToList();
                options.SupportedUICultures = supportedCultures.Select(culture => new CultureInfo(culture)).ToList();
                options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
            });


            //Localization

            //builder.Services.AddSingleton<LanguageService>();
            //builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
            //builder.Services.AddMvc().AddViewLocalization().AddDataAnnotationsLocalization(options=>
            //options.DataAnnotationLocalizerProvider = (type, factory) =>
            //{
            //    var assemblyName =new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
            //    return factory.Create(nameof(SharedResource), assemblyName.Name);
            //});

            //builder.Services.Configure<RequestLocalizationOptions>(options =>
            //{
            //    var supportCultures = new List<CultureInfo>
            //    {
            //        new CultureInfo("az"),
            //        new CultureInfo("en-US"),
            //        new CultureInfo("ru")
            //    };
            //    options.DefaultRequestCulture = new RequestCulture(culture: "az", uiCulture: "az");
            //    options.SupportedCultures = supportCultures;
            //    options.SupportedUICultures = supportCultures;
            //    options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());

            //});




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
            app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
            //app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

            app.UseRouting();

            app.UseAuthorization();

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run();
        }
    }
}
