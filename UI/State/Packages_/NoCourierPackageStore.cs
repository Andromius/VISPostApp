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
    public class NoCourierPackageStore
    {
        private readonly IUserStore _userStore;
        public List<Package> Packages { get; set; }

        public event Action StateChanged;
        public NoCourierPackageStore(IUserStore userStore)
        {
            _userStore = userStore;
            Packages = new List<Package>();
            _userStore.StateChanged += OnStateChanged;
        }

        private void OnStateChanged()
        {
            FilterArea();
            StateChanged?.Invoke();
        }

        private void FilterArea()
        {
            PackageDataMapper packageDataMapper = new PackageDataMapper();
            List<Package> packages = packageDataMapper.FindNoCourier();
            if (_userStore.CurrentUser is Courier c)
            {
                foreach (Package item in packages)
                {
                    if(item.GetAddress(new AddressDataMapper()).City.AreaID == c.AreaID && item.CourierID != c.CourierID)
                    {
                        if(item.DispatchStatus != EDispatchStatus.Delivered && item.DispatchStatus != EDispatchStatus.Dispatched)
                            Packages.Add(item);
                    }
                }
            }
        }
    }
}
