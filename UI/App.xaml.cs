﻿using DataAccess.DataAccess;
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
using UI.State.Authenticators;
using UI.State.Navigators;
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

            services.AddSingleton<UserDataMapper>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IUserDataMapper, UserDataMapper>();

            services.AddSingleton<IUIViewModelAbstractFactory, UIViewModelAbstractFactory>();
            services.AddSingleton<IUIViewModelFactory<PackagesViewModel>, PackagesViewModelFactory>();
            services.AddSingleton<IUIViewModelFactory<HomeViewModel>, HomeViewModelFactory>();
            services.AddSingleton<IUIViewModelFactory<LoginViewModel>, LoginViewModelFactory>();

            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<IAuthenticator, Authenticator>();
            services.AddScoped<MainViewModel>();

            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }
    }
}
