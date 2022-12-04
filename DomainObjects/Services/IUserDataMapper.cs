using DomainObjects.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainObjects.Services
{
    public interface IUserDataMapper
    {
        public User FindByLogin(string login);
        public bool Update(User user);
        public bool Create(User user);
    }
}
