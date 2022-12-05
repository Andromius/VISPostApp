using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.State.Navigators;

namespace UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; }

        MainViewModel(INavigator navigator)
        {
            Navigator = navigator;
            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Home);
        }
    }
}
