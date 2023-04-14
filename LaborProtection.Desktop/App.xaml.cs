using FluentValidation;
using LaborProtection.Common;
using LaborProtection.Desktop.Pages;
using LaborProtection.EntityFramework;
using LaborProtection.EntityFramework.Repository;
using LaborProtection.Services.BulbServices;
using LaborProtection.Services.LampServices;
using LaborProtection.Services.LampServices.Models;
using Microsoft.EntityFrameworkCore;
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
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.DEFAULT_CONNECTION));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Services            
            services.AddTransient<ILampService, LampService>();
            services.AddTransient<IBulbService, BulbService>();

            // Validations
            services.AddTransient<IValidator<CreateLampPostModel>, CreateLampPostModelValidator>();

            // Pages
            services.AddTransient<CreateBasePage>();
            services.AddTransient<MainWindow>();
            services.AddTransient<CreateLampPage>();
            services.AddTransient<CreateBulbPage>();
            services.AddTransient<ViewComponentsPage>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var main = _serviceProvider.GetRequiredService<MainWindow>();
            main.Show();
        }
    }
}
