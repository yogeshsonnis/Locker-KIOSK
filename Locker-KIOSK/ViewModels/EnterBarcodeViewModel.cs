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
            ConfirmCommand = new RelayCommand(async _ => await _mainVM.NavigateToOOHPODCompartment());
            BackCommand = new RelayCommand(_ => Back());
           
        }

        private void Back()
        {
            IsErrorPopupVisible = false;
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
        private bool _isExecute = true;

        public bool IsExecute
        {
            get { return _isExecute; }
            set { _isExecute = value; OnPropertyChanged(); }
        }

        public async Task<bool> Confirm()
        {
            var parcel = new Parcel
            {
                CarrierCode = "OOH",
                TrackingNumber = Barcode,
                //TrackingNumber = "L2C002356101",
                Actor = "Customer",
                Action = "Pickup",
                LocationCode = "OP00001",
                AccountCode = "test23"
                
            };
            IsExecute = false;

            var result = await _mainVM._apiService.IsParcelValidAsync(parcel);
            if (result.Success == true && result != null)
            {
                //MessageBox.Show(result.Message);
                IsErrorPopupVisible = false;
            }
            else
            {
              
                IsErrorPopupVisible = true;
            }
             IsExecute = true;

            return result.Success;

        }
       
        public ICommand ConfirmCommand { get; }
        public ICommand BackCommand { get; }
    }
}
