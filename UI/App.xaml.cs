using DataAccess.DataAccess;
using DomainObjects.Services.AuthenticationServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UI.State.Navigators;
using UI.ViewModels;

namespace UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();
            //IAuthenticationService authenticationService = serviceProvider.GetService<IAuthenticationService>();
            //IAuthenticationService authentiCationService = new AuthenticationService(new UserDataMapper());
            //authentiCationService.Login("MaTl2011", "JsemTheBet");
            Window window = new MainWindow();
            window.DataContext = serviceProvider.GetRequiredService<MainViewModel>();
            window.Show();

            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<UserDataMapper>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();

            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<MainViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
