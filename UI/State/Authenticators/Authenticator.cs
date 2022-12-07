using DomainObjects.DomainObjects;
using DomainObjects.Services.AuthenticationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.State.Accounts;

namespace UI.State.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserStore _userStore;
        public User CurrentUser 
        { 
            get 
            {
                return _userStore.CurrentUser;
            }
            private set
            {
                _userStore.CurrentUser = value;
                StateChanged?.Invoke();
            } 
        }
        public bool IsLoggedIn => CurrentUser != null;

        public event Action StateChanged;
        public Authenticator(IAuthenticationService authenticationService, IUserStore userStore)
        {
            _authenticationService = authenticationService;
            _userStore = userStore;
        }
        public bool Login(string username, string password)
        {
            bool success = true;
            try
            {
                CurrentUser = _authenticationService.Login(username, password);
            }
            catch(Exception) 
            {
                success = false;
            }
            return success;
        }

        public void Logout()
        {
            CurrentUser = null;
        }
    }
}
