using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainObjects.DomainObjects
{
    public class Management : User
    {
        public Management(int userID, string firstName, string lastName, DateOnly dateHired, string login, string password, bool atWork) : base(userID, firstName, lastName, dateHired, login, password, atWork)
        {
        }
    }
}
