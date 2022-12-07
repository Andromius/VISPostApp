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

namespace UI.Controls
{
    /// <summary>
    /// Interaction logic for PackageSummary.xaml
    /// </summary>
    public partial class PackageSummary : UserControl
    {
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
        }
    }
}
