using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainObjects.DomainObjects
{
    public abstract class User
    {
        public int UserID { get; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateOnly DateHired { get; private set; }
        public string Login { get; private set; }
        public string Password { get; set; }
        public bool AtWork { get; private set; }
        protected User(int userID, string firstName, string lastName, DateOnly dateHired, string login, string password, bool atWork)
        {
            UserID = userID;
            FirstName = firstName;
            LastName = lastName;
            DateHired = dateHired;
            Login = login;
            Password = password;
            AtWork = atWork;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"UserID: {UserID}");
            stringBuilder.AppendLine($"Name {FirstName} {LastName}");
            stringBuilder.AppendLine($"Date hired: {DateHired}");
            return stringBuilder.ToString();
        }
    }
}
