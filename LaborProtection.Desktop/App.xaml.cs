using FluentValidation;
using LaborProtection.Desktop.Pages;
using LaborProtection.Desktop.Pages.Calculations;
using LaborProtection.EntityFramework;
using LaborProtection.EntityFramework.Repository;
using LaborProtection.Services.BulbServices;
using LaborProtection.Services.BulbServices.Models;
using LaborProtection.Services.LampServices;
using LaborProtection.Services.LampServices.Models;
using LaborProtection.Services.WorkSpaceServices;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace LaborProtection.Desktop
{
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Configurations
            services.AddDbContext<ApplicationContext>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Services            
            services.AddTransient<ILampService, LampService>();
            services.AddTransient<IBulbService, BulbService>();
            services.AddTransient<IWorkSpaceService, WorkSpaceService>();

            // Validations
            services.AddTransient<IValidator<CreateLampPostModel>, CreateLampPostModelValidator>();
            services.AddTransient<IValidator<CreateBulbPostModel>, CreateBulbPostModelValidator>();

            // Pages
            services.AddTransient<MainWindow>();
            services.AddTransient<CreateBasePage>();
            services.AddTransient<CreateLampPage>();
            services.AddTransient<CreateBulbPage>();
            services.AddTransient<ViewBasePage>();
            services.AddTransient<ViewLampPage>();
            services.AddTransient<ViewBulbPage>();
            services.AddTransient<CalculationBasePage>();
            services.AddTransient<CalculationAreaPage>();
            services.AddTransient<DrawingPage>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var main = _serviceProvider.GetService<MainWindow>();
            main.Show();
        }
    }
}
