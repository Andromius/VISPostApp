using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.State.Accounts;
using UI.State.Packages;

namespace UI.ViewModels.Factories
{
    internal class PackagesViewModelFactory : IUIViewModelFactory<PackagesViewModel>
    {
        private readonly PackagesNoCourierViewModel _noCourierViewModel;

        public PackagesViewModelFactory(PackagesNoCourierViewModel noCourierViewModel)
        {
            _noCourierViewModel = noCourierViewModel;
        }

        public PackagesViewModel CreateViewModel()
        {
            return new PackagesViewModel(_noCourierViewModel);
        }
    }
}
