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
    public class PackagesViewModel : ViewModelBase
    {
        public PackagesViewModel(PackagesNoCourierViewModel noCourierViewModel)
        {
            NoCourierViewModel = noCourierViewModel;
        }

        public PackagesNoCourierViewModel NoCourierViewModel { get; }

    }
}
