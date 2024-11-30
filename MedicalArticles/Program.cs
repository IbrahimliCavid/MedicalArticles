using Business.Abstract;
using Business.Concrete;
using Business.Validations;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.SqlServerDBContext;
using Entities.Concrete.TableModels.Membership;
using Entities.TableModels;
using FluentValidation;

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
