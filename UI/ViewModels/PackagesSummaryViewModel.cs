using DomainObjects.DomainObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.Commands;
using UI.State.Accounts;
using UI.State.Packages;

namespace UI.ViewModels
{
    public class PackagesSummaryViewModel : ViewModelBase
    {
        private readonly PackageStore _packageStore;
        private ObservableCollection<Package> _packages;
        public List<Package> Packages => _packageStore.Packages;

        public ICommand CountTimeSinceHired { get; }

        public PackagesSummaryViewModel(PackageStore packageStore, IUserStore userStore)
        {
            _packageStore = packageStore;
            _packages = new ObservableCollection<Package>();
            CountTimeSinceHired = new CountTimeSinceHired(this, userStore);

            _packageStore.StateChanged += PackageStore_StateChanged;
        }
        private void PackageStore_StateChanged()
        {
            OnPropertyChanged(nameof(Packages));
            ResetPackages();
        }

        private void ResetPackages()
        {
            _packages.Clear();
            foreach (Package item in Packages)
            {
                _packages.Add(item);
            }
        }
    }
}
