using DataAccess.DataAccess;
using DomainObjects.Services;
using DomainObjects.Services.AuthenticationServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UI.Controls;
using UI.State.Accounts;
using UI.State.Authenticators;
using UI.State.Navigators;
using UI.State.Packages;
using UI.ViewModels;
using UI.ViewModels.Factories;

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
            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IUserDataMapper, UserDataMapper>();

            services.AddSingleton<IUIViewModelAbstractFactory, UIViewModelAbstractFactory>();
            services.AddSingleton<IUIViewModelFactory<HomeViewModel>, HomeViewModelFactory>();

            services.AddSingleton<IUIViewModelFactory<PackagesViewModel>, PackagesViewModelFactory>();

            services.AddSingleton<IUIViewModelFactory<LoginViewModel>>((services) => 
                new LoginViewModelFactory(services.GetRequiredService<IAuthenticator>(),
                new ViewModelFactoryRenavigator<HomeViewModel>(services.GetRequiredService<INavigator>(), 
                services.GetRequiredService<IUIViewModelFactory<HomeViewModel>>())));

            services.AddSingleton<PackagesSummaryViewModel>();
            services.AddSingleton<PackagesNoCourierViewModel>();

            services.AddSingleton<PackageWithoutCourier>();

            services.AddSingleton<NoCourierPackageStore>();
            services.AddSingleton<PackageStore>();
            services.AddSingleton<INavigator, Navigator>();
            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddSingleton<IUserStore, UserStore>();
            services.AddScoped<MainViewModel>();

            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }
    }
}
