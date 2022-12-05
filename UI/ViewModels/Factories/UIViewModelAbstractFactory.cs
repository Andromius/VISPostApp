using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.State.Navigators;

namespace UI.ViewModels.Factories
{
    public class UIViewModelAbstractFactory : IUIViewModelAbstractFactory
    {
        private readonly IUIViewModelFactory<LoginViewModel> _loginViewModelFactory;
        private readonly IUIViewModelFactory<HomeViewModel> _homeViewModelFactory;
        private readonly IUIViewModelFactory<PackagesViewModel> _packagesViewModelFactory;

        public UIViewModelAbstractFactory(IUIViewModelFactory<LoginViewModel> loginViewModelFactory,
            IUIViewModelFactory<HomeViewModel> homeViewModelFactory, 
            IUIViewModelFactory<PackagesViewModel> packagesViewModelFactory)
        {
            _loginViewModelFactory = loginViewModelFactory;
            _homeViewModelFactory = homeViewModelFactory;
            _packagesViewModelFactory = packagesViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _homeViewModelFactory.CreateViewModel();
                case ViewType.Packages:
                    return _packagesViewModelFactory.CreateViewModel();
                case ViewType.Login:
                    return _loginViewModelFactory.CreateViewModel();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
