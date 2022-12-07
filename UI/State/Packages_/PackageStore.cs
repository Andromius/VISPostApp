using DataAccess.DataAccess;
using DomainObjects.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.State.Accounts;

namespace UI.State.Packages
{
    public class PackageStore
    {
        private readonly IUserStore _userStore;
        public List<Package> Packages { get; private set; }

        public event Action StateChanged;

        public PackageStore(IUserStore userStore)
        {
            _userStore = userStore;

            _userStore.StateChanged += OnStateChanged;
        }

        private void OnStateChanged()
        {
            if(_userStore.CurrentUser is Courier c)
            {
                Packages = c.GetPackages(new PackageDataMapper());
            }
            else
            {
                Packages = null;
            }
            StateChanged?.Invoke();
        }
    }
}
