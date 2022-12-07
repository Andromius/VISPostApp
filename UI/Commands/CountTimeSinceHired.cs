using DataAccess.DataAccess;
using DomainObjects.DomainObjects;
using DomainObjects.Services.CountServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UI.State.Accounts;
using UI.ViewModels;

namespace UI.Commands
{
    public class CountTimeSinceHired : ICommand
    {
        private readonly PackagesSummaryViewModel _packagesViewModel;
        private readonly IUserStore _userStore;

        public CountTimeSinceHired(PackagesSummaryViewModel packagesViewModel, IUserStore userStore)
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
            CountService countService = new CountService();
            MessageBox.Show("Days since hired: "+countService.CountDaysSinceHired(_userStore.CurrentUser).ToString());
        }
    }
}
