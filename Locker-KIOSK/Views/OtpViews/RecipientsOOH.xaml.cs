using Locker_KIOSK.ViewModels;
using System.Windows;
using System.Windows.Controls;

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
                    var vm = (RecipientsViewModel)DataContext;
                    if (vm != null)
                    {
                        vm.OOHId += box.Text;
                    }
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
                    var vm = (RecipientsViewModel)DataContext;
                    if (vm != null)
                    {
                        string id = vm.OOHId;
                        if (id.Length > 0)
                        {
                            id = id.Substring(0, id.Length - 1);
                            vm.OOHId = id;
                        }

                    }
                    break;
                }
            }
        }


    }
}
