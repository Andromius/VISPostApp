using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UI.State.Authenticators;
using UI.State.Navigators;
using UI.ViewModels;
using UI.ViewModels.Factories;

namespace UI.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;

        public LoginCommand(LoginViewModel loginViewModel, IAuthenticator authenticator, IRenavigator renavigator)
        {
            _loginViewModel = loginViewModel;
            _authenticator = authenticator;
            _renavigator = renavigator;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            bool success = _authenticator.Login(_loginViewModel.Username, parameter.ToString());

            if(success)
            {
                _renavigator.Renavigate();
            }
            else
            {
                MessageBox.Show("Unable to log in, please try again", "Login error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
