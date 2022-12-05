using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.Commands;
using UI.State.Authenticators;
using UI.State.Navigators;
using UI.ViewModels.Factories;

namespace UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IUIViewModelAbstractFactory _viewModelFactory;
        public INavigator Navigator { get; set; }
        public IAuthenticator Authenticator { get; }
        public ICommand UpdateCurrenViewModelCommand { get; }

        public MainViewModel(INavigator navigator, IUIViewModelAbstractFactory viewModelFactory, IAuthenticator authenticator)
        {
            Navigator = navigator;
            Authenticator = authenticator;
            _viewModelFactory = viewModelFactory;

            UpdateCurrenViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory);
            UpdateCurrenViewModelCommand.Execute(ViewType.Login);
        }
    }
}
