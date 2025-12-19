using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Locker_KIOSK.Views.OtpViews
{
    /// <summary>
    /// Interaction logic for RecipientsOOH.xaml
    /// </summary>
    public partial class RecipientsOOH : UserControl
    {
        public RecipientsOOH()
        {
            InitializeComponent();
        }
      
        private void Key_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string key = btn.Content.ToString();

            TextBox[] otpBoxes =
            {
                otp1, otp2, otp3, otp4,
                otp5, otp6, otp7, otp8
            };

            foreach (var box in otpBoxes)

            {
                if (string.IsNullOrEmpty(box.Text))
                {
                    box.Text = key;
                    break;
                }
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            TextBox[] otpBoxes =
            { 
                otp1, otp2, otp3, otp4,
                otp5, otp6, otp7, otp8
            };

            
            for (int i = otpBoxes.Length - 1; i >= 0; i--)
            {
                if (!string.IsNullOrEmpty(otpBoxes[i].Text))
                {
                    otpBoxes[i].Text = "";
                    otpBoxes[i].Focus();
                    break;
                }
            }
        }


    }
}
