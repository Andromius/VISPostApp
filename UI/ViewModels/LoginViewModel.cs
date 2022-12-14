using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.Commands;
using UI.State.Authenticators;
using UI.State.Navigators;

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
        public LoginViewModel(IAuthenticator authenticator, IRenavigator renavigator) 
        {
            LoginCommand = new LoginCommand(this, authenticator, renavigator);
        }

    }
}
