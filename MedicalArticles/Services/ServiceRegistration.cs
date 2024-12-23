using Business.Abstract;
using Business.Concrete;
using Business.Validations;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.SqlServerDBContext;
using Entities.Concrete.TableModels.Membership;
using Entities.Dtos;
using Entities.TableModels;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using static MedicalArticles.Services.LanguageService;
using System.Globalization;
using System.Reflection;

namespace MedicalArticles.Services
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services) {

            services.AddAuthentication();
            services.AddAuthorization();

            services.AddDbContext<ApplicationDbContext>()
                .AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 8;

                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(365);
            });


            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutDal, AboutDal>();
            services.AddScoped<IValidator<About>, AboutValidation>();
            
            services.AddScoped<IAdressService, AdressManager>();
            services.AddScoped<IAdressDal, AdressDal>();
            services.AddScoped<IValidator<Adress>, AdressValidation>();
            services.AddScoped<IValidator<AdressCreateDto>, AdressCreateValidation>();
            
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, ContactDal>();
            services.AddScoped<IValidator<Contact>, ContactValidation>();
            
            services.AddScoped<IFaqService, FaqManager>();
            services.AddScoped<IFaqDal, FaqDal>();
            services.AddScoped<IValidator<Faq>, FaqValidation>();
            
            
            services.AddScoped<ISosialService, SosialManager>();
            services.AddScoped<ISosialDal, SosialDal>();
            services.AddScoped<IValidator<Sosial>, SosialValidation>();
            
            services.AddScoped<ISlideService, SlideManager>();
            services.AddScoped<ISlideDal, SlideDal>();
            services.AddScoped<IValidator<Slide>, SlideValidation>();
            services.AddScoped<IValidator<SlideCreateDto>, SlideCreateValidation>();
            
            services.AddScoped<IServiceService, ServiceManager>();
            services.AddScoped<IServiceDal, ServiceDal>();
            services.AddScoped<IValidator<Service>, ServiceValidation>();
            
            services.AddScoped<IServiceAboutService, ServiceAboutManager>();
            services.AddScoped<IServiceAboutDal, ServiceAboutDal>();
            services.AddScoped<IValidator<ServiceAbout>, ServiceAboutValidation>();
            services.AddScoped<IValidator<ServiceAboutCreateDto>, ServiceAboutCreateValidation>();
            
            services.AddScoped<IServiceAboutItemService, ServiceAboutItemManager>();
            services.AddScoped<IServiceAboutItemDal, ServiceAboutItemDal>();
            services.AddScoped<IValidator<ServiceAboutItem>, ServiceAboutItemValidation>();
            
            services.AddScoped<ITeamBoardService, TeamBoardManager>();
            services.AddScoped<ITeamBoardDal, TeamBoardDal>();
            services.AddScoped<IValidator<TeamBoard>, TeamBoardValidation>();
            
            services.AddScoped<IHealthTipService, HealthTipManager>();
            services.AddScoped<IHealthTipDal, HealthTipDal>();
            services.AddScoped<IValidator<HealthTip>, HealthTipValidation>();
            services.AddScoped<IValidator<HealthTipCreateDto>, HealthTipCreateValidation>();
            
            services.AddScoped<IHealthTipItemService, HealthTipItemManager>();
            services.AddScoped<IHealthTipItemDal, HealthTipItemDal>();
            services.AddScoped<IValidator<HealthTipItem>, HealthTipItemValidation>();
            
            services.AddScoped<IWhyChooseUsService, WhyChooseUsManager>();
            services.AddScoped<IWhyChooseUsDal, WhyChooseUsDal>();
            services.AddScoped<IValidator<WhyChooseUs>, WhyChooseUsValidation>();
            services.AddScoped<IValidator<WhyChooseUsCreateDto>, WhyChooseUsCreateValidation>();
            
            services.AddScoped<IWhyChooseUsItemService, WhyChooseUsItemManager>();
            services.AddScoped<IWhyChooseUsItemDal, WhyChooseUsItemDal>();
            services.AddScoped<IValidator<WhyChooseUsItem>, WhyChooseUsItemValidation>();
          
            services.AddScoped<IStatisticService, StatisticManager>();
            services.AddScoped<IStatisticDal, StatisticDal>();
            services.AddScoped<IValidator<Statistic>, StatisticValidation>();

            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<IBlogDal, BlogDal>();
            services.AddScoped<IValidator<Blog>, BlogValidation>();
           
            services.AddScoped<ILanguageService, Business.Concrete.LanguageManager>();
            services.AddScoped<ILanguageDal, LanguageDal>();


            services.AddSingleton<LanguageService>();
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddMvc().AddViewLocalization().AddDataAnnotationsLocalization(options =>
            {
                var assemblyName = new AssemblyName(typeof(SharedResource).Assembly.FullName);
                options.DataAnnotationLocalizerProvider = (type, factory) =>
                    factory.Create(nameof(SharedResource), assemblyName.Name);
            });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[] { "az-Latn", "en-US", "ru-RU" };
                options.DefaultRequestCulture = new RequestCulture("az-Latn", "az-Latn");
                options.SupportedCultures = supportedCultures.Select(culture => new CultureInfo(culture)).ToList();
                options.SupportedUICultures = supportedCultures.Select(culture => new CultureInfo(culture)).ToList();
                options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
            });

            return services;
        }
    }
}
