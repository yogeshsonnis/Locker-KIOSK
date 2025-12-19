using Locker_KIOSK.Model;
using Locker_KIOSK.Views.ScanBarcodeViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Locker_KIOSK.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            HomeVM = new HomeViewModel(this);
            SelectCustomerVM = new SelectCustomerViewModel(this);
            SelectCarrierVM = new SelectCarrierViewModel(this);
            RecipientsVM = new RecipientsViewModel(this);
            OOHPODScanVM = new OOHPODScanViewModel(this);
            EnterBarcodeVM = new EnterBarcodeViewModel(this);
            CurrentScreen = HomeVM;
            BackBtnCommand = new RelayCommand(_ => NavigateBack());
        }
        public ICommand BackBtnCommand { get; }
        public bool IsOnDropOffScreen => CurrentScreen == SelectCustomerVM || CurrentScreen == SelectCarrierVM || CurrentScreen == RecipientsVM || CurrentScreen == OOHPODScanVM || CurrentScreen == EnterBarcodeVM;

        public HomeViewModel HomeVM { get; }
        public SelectCustomerViewModel SelectCustomerVM { get; }
        public SelectCarrierViewModel SelectCarrierVM { get; }

        public RecipientsViewModel RecipientsVM { get; }

        public OOHPODScanViewModel OOHPODScanVM { get; }
        public EnterBarcodeViewModel EnterBarcodeVM { get; }

        private ViewModelBase _currentScreen;
        public ViewModelBase CurrentScreen
        {
            get => _currentScreen;
            set
            {
                _currentScreen = value; OnPropertyChanged();
                OnPropertyChanged(nameof(IsOnDropOffScreen));
            }
        }

        public void NavigateBack()
        {
            if (CurrentScreen == SelectCarrierVM)
            {
                CurrentScreen = SelectCustomerVM;

            }
            else if (CurrentScreen == RecipientsVM)
            {
                CurrentScreen = SelectCarrierVM;
            }
            else if (CurrentScreen == OOHPODScanVM)
            {
                CurrentScreen = RecipientsVM;
            }
            else if (CurrentScreen == EnterBarcodeVM)
            {
                CurrentScreen = OOHPODScanVM;
            }
            else
            {
                CurrentScreen = HomeVM;
            }

        }

        public void NavigateToDeliveryDriver()
        {
            CurrentScreen = SelectCustomerVM;
        }
        public void NavigateToCarrier()
        {
            CurrentScreen = SelectCarrierVM;
        }

        public void NavigateToRecipients(object? o)
        {
            if(o is Carrier carrier)
            {
                if(carrier.Name == "OOHPOD")
                {
                    CurrentScreen = RecipientsVM;
                    
                }
                
            }
        }
        public void NavigateToOOHPODScan()
        {
            CurrentScreen = OOHPODScanVM;
        }
        public void NavigateEnterBarcode()
        {
            CurrentScreen = EnterBarcodeVM;
        }
    }
}
