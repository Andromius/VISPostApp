using DataAccess.DataAccess;
using DataAccess.Files;
using DomainObjects.DomainObjects;
using DomainObjects.Services.CountServices;
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

namespace UI.Controls
{
    /// <summary>
    /// Interaction logic for PackageSummary.xaml
    /// </summary>
    public partial class PackageSummary : UserControl
    {
        public ICommand CountTimeSinceHired
        {
            get { return (ICommand)GetValue(CountTimeSinceHiredProperty); }
            set { SetValue(CountTimeSinceHiredProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LoginCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CountTimeSinceHiredProperty =
            DependencyProperty.Register("CountTimeSinceHired", typeof(ICommand), typeof(PackageSummary), new PropertyMetadata(null));
        public PackageSummary()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CountService countService = new CountService();
            List<Package> packages = new List<Package>();
            foreach (var item in listbox.Items)
            {
                Package p = (Package)item;
                if(p.DispatchStatus == EDispatchStatus.Dispatched)
                    packages.Add((Package)item);
            }
            double result = countService.CountWeight(packages);
            string toPrint = $"The weight of currently dispatched packages is {result} kg";
            TextFile.Write(toPrint);
            MessageBox.Show("Succesfuly wrote to file");
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            CountService countService = new CountService();
            List<Package> packages = new List<Package>();
            foreach (var item in listbox.Items)
            {
                Package p = (Package)item;
                if (p.DispatchStatus == EDispatchStatus.Dispatched)
                    packages.Add((Package)item);
            }
            int result = countService.CountSpFt(packages, new SpecialFeaturesDataMapper());
            string toPrint = $"The amount of currently dispatched packages with special features is {result}";
            TextFile.Write(toPrint);
            MessageBox.Show("Succesfuly wrote to file");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (CountTimeSinceHired != null)
            {
                CountTimeSinceHired.Execute(this);
            }
        }
    }
}
