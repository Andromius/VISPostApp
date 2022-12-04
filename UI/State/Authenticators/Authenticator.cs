using DomainObjects.DomainObjects;
using DomainObjects.Services.AuthenticationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.State.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;
        public User CurrentUser { get; private set; }
        public bool IsLoggedIn => CurrentUser != null;
        public Authenticator(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
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
