using DomainObjects.DomainObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.State.Packages;

namespace UI.ViewModels
{
    public class PackagesViewModel : ViewModelBase
    {
        private readonly PackageStore _packageStore;
        public List<Package> Packages => _packageStore.Packages;
        public PackagesViewModel(PackageStore packageStore)
        {
            _packageStore = packageStore;

            _packageStore.StateChanged += PackageStore_StateChanged;
        }

        private void PackageStore_StateChanged()
        {
            OnPropertyChanged(nameof(Packages));
        }
    }
}
