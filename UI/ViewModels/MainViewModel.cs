using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.State.Authenticators;
using UI.State.Navigators;

namespace UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; }
        public IAuthenticator Authenticator { get; }

        public MainViewModel(INavigator navigator, IAuthenticator authenticator)
        {
            Navigator = navigator;
            Authenticator = authenticator;

            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Login);
        }
    }
}
