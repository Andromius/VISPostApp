using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.State.Authenticators;
using UI.State.Navigators;

namespace UI.ViewModels.Factories
{
    public class LoginViewModelFactory : IUIViewModelFactory<LoginViewModel>
    {
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;

        public LoginViewModelFactory(IAuthenticator authenticator, IRenavigator renavigator)
        {
            _authenticator = authenticator;
            _renavigator = renavigator;
        }

        public LoginViewModel CreateViewModel()
        {
            return new LoginViewModel(_authenticator, _renavigator);
        }
    }
}
