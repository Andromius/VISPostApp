using DataAccess.DataAccess;
using DomainObjects.Services.AuthenticationServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
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
            IAuthenticationService authentiCationService = new AuthenticationService(new UserDataMapper());
            authentiCationService.Login("MaTl2011", "JsemTheBet");
            Window window = new MainWindow();
            window.DataContext = new MainViewModel();
            window.Show();
            base.OnStartup(e);
        }
    }
}
