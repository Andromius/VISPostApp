using DomainObjects.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.State.Accounts
{
    public class UserStore : IUserStore
    {
        public User CurrentUser { get; set; }
    }
}
