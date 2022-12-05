using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.State.Authenticators;

namespace UI.ViewModels.Factories
{
    public class LoginViewModelFactory : IUIViewModelFactory<LoginViewModel>
    {
        private readonly IAuthenticator _authenticator;

        public LoginViewModelFactory(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }

        public LoginViewModel CreateViewModel()
        {
            return new LoginViewModel(_authenticator);
        }
    }
}
