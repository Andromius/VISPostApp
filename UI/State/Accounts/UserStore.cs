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
		private User _currentUser;

		public User CurrentUser
		{
			get { return _currentUser; }
			set 
			{ 
				_currentUser = value;
				StateChanged?.Invoke();
			}
		}


		public event Action StateChanged;
    }
}
