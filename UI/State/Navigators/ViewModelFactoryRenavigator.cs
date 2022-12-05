using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.ViewModels;
using UI.ViewModels.Factories;

namespace UI.State.Navigators
{
    public class ViewModelFactoryRenavigator<TViewModel> : IRenavigator where TViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly IUIViewModelFactory<TViewModel> _viewModelFactory;

        public ViewModelFactoryRenavigator(INavigator navigator, IUIViewModelFactory<TViewModel> viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        public void Renavigate()
        {
            _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel();
        }
    }
}
