using DomainObjects.DomainObjects;
using DomainObjects.Services.AuthenticationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Models;

namespace UI.State.Authenticators
{
    public class Authenticator : ObservableObject, IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;
        private User _currentUser;
        public User CurrentUser 
        { 
            get 
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;
            } 
        }
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
