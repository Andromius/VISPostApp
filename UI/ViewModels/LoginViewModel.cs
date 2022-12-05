using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.Commands;
using UI.State.Authenticators;

namespace UI.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username; 
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public ICommand LoginCommand { get; }
        public LoginViewModel(IAuthenticator authenticator) 
        {
            LoginCommand = new LoginCommand(this, authenticator);
        }

    }
}
