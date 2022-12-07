using DomainObjects.DomainObjects;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainObjects.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserDataMapper _userDataMapper;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IUserDataMapper userDataMapper)
        {
            _userDataMapper = userDataMapper;
            _passwordHasher = new PasswordHasher();
        }

        public User Login(string username, string password)
        {
            if(string.IsNullOrEmpty(password) || string.IsNullOrEmpty(username)) 
                throw new Exception();

            User u = _userDataMapper.FindByLogin(username);
            if(u == null)
                throw new Exception();

            PasswordVerificationResult passResult = _passwordHasher.VerifyHashedPassword(u.Password, password);
            if (passResult != PasswordVerificationResult.Success)
            {
                throw new Exception();
            }
            return u;
        }
    }
}
