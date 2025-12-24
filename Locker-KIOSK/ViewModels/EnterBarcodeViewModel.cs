using Locker_KIOSK.Model;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Nodes;
using System.Windows;
using System.Windows.Input;

namespace Locker_KIOSK.ViewModels
{
    public class EnterBarcodeViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainVM;

        private bool _isErrorPopupVisible;

        public bool IsErrorPopupVisible
        {
            get { return _isErrorPopupVisible; }
            set
            {
                _isErrorPopupVisible = value;
                OnPropertyChanged();
            }
        }

        private bool _isConfirmPopupVisible;

        public bool IsConfirmPopupVisible
        {
            get { return _isConfirmPopupVisible; }
            set
            {
                _isConfirmPopupVisible = value;
                OnPropertyChanged();
            }
        }
        public EnterBarcodeViewModel(MainViewModel mainVM)
        {
            _mainVM = mainVM;
            ConfirmCommand = new RelayCommand(async _ => await Confirm());

        }

        private string _barcode;

        public string Barcode
        {
            get { return _barcode; }
            set
            {
                _barcode = value;
                OnPropertyChanged();
            }
        }

        private async Task Confirm()
        {
            var parcel = new Parcel
            {
                CarrierCode = "OOH",
                TrackingNumber = "L2C002356101",
                Actor = "Customer",
                Action = "Pickup",
                LocationCode = "OP00001",
                AccountCode = "test23"

            };
            // IsExecute = false;

            var result = await _mainVM._apiService.IsParcelValidAsync(parcel);
            if (result.Success == true && result != null)
            {

                MessageBox.Show(result.Message);
                IsErrorPopupVisible = false;
            }
            else
            {
                MessageBox.Show(result.Message);
                IsErrorPopupVisible = true;
            }
            //  IsExecute = true;

        }

        public ICommand ConfirmCommand { get; }
    }
}
