using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModels.Factories
{
    internal class PackagesViewModelFactory : IUIViewModelFactory<PackagesViewModel>
    {
        public PackagesViewModel CreateViewModel()
        {
            return new PackagesViewModel();
        }
    }
}
