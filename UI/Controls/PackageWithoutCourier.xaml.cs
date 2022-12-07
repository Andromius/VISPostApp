using DataAccess.DataAccess;
using DomainObjects.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UI.Commands;
using UI.State.Accounts;
using UI.Views;

namespace UI.Controls
{
    /// <summary>
    /// Interaction logic for PackageWithoutCourier.xaml
    /// </summary>
    public partial class PackageWithoutCourier : UserControl
    {
        private Package _selectedObject;
        public ICommand AddSelectedPackageCommand
        {
            get { return (ICommand)GetValue(AddSelectedPackageCommandProperty); }
            set { SetValue(AddSelectedPackageCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LoginCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddSelectedPackageCommandProperty =
            DependencyProperty.Register("AddSelectedPackageCommand", typeof(ICommand), typeof(PackageWithoutCourier), new PropertyMetadata(null));
        public PackageWithoutCourier()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (AddSelectedPackageCommand != null)
            {
                if(_selectedObject is not null)
                {
                    AddSelectedPackageCommand.Execute(_selectedObject);
                }
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedObject = listbox.SelectedItem as Package;
        }
    }
}
