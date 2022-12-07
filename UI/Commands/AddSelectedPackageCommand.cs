using DataAccess.DataAccess;
using DomainObjects.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using UI.State.Accounts;
using UI.State.Authenticators;
using UI.State.Navigators;
using UI.ViewModels;

namespace UI.Commands
{
    public class AddSelectedPackageCommand : ICommand
    {
        private readonly PackagesNoCourierViewModel _packagesViewModel;
        private readonly IUserStore _userStore;

        public AddSelectedPackageCommand(PackagesNoCourierViewModel packagesViewModel, IUserStore userStore)
        {
            _packagesViewModel = packagesViewModel;
            _userStore = userStore;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (_userStore.CurrentUser is Courier c)
            {
                c.AddPackage((Package)parameter, new PackageDataMapper());
                _userStore.CurrentUser = c;
            }
        }
    }
}
