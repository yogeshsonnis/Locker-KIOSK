using Locker_KIOSK.ViewModels;
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

namespace Locker_KIOSK.Views
{
    /// <summary>
    /// Interaction logic for EnterBarcode.xaml
    /// </summary>
    public partial class EnterBarcode : UserControl
    {
        public EnterBarcode()
        {
            InitializeComponent();
        }
        private void Key_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            var vm = DataContext as EnterBarcodeViewModel;
            if (vm != null) { 
            vm.Barcode += btn.Content.ToString();
            }
           // BarCodeTextBox.Text += btn.Content.ToString();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as EnterBarcodeViewModel;
            if (vm != null)
            {
                if (vm.Barcode.Length > 0)
                    vm.Barcode = vm.Barcode.Substring(0, vm.Barcode.Length - 1);
            }
        }
    }
}
