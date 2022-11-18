using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.DomainObjects
{
    public abstract class User
    {
        public int UserID { get; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateOnly DateHired { get; private set; }
        public string Login { get; private set; }
        private string Password { get; set; }
        public bool AtWork { get; private set; }
    }
}
