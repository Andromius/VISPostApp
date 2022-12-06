using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModels.Factories
{
    public class HomeViewModelFactory : IUIViewModelFactory<HomeViewModel>
    {
        private readonly PackagesSummaryViewModel _summaryViewModel;

        public HomeViewModelFactory(PackagesSummaryViewModel summaryViewModel)
        {
            _summaryViewModel = summaryViewModel;
        }

        public HomeViewModel CreateViewModel()
        {
            return new HomeViewModel(_summaryViewModel);
        }
    }
}
