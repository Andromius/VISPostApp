using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public PackagesSummaryViewModel SummaryViewModel { get; }
        public HomeViewModel(PackagesSummaryViewModel packagesSummaryViewModel)
        {
            SummaryViewModel = packagesSummaryViewModel;
        }


}
}
