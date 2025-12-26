using Locker_KIOSK.Model;
using Locker_KIOSK.Services;
using Locker_KIOSK.Views;
using System.Windows.Input;

namespace Locker_KIOSK.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public readonly ApiService _apiService;
        public MainViewModel(ApiService apiService)
        {
            _apiService = apiService;
            HomeVM = new HomeViewModel(this);
            SelectCustomerVM = new SelectCustomerViewModel(this);
            SelectCarrierVM = new SelectCarrierViewModel(this);
            RecipientsVM = new RecipientsViewModel(this);
            OOHPODScanVM = new OOHPODScanViewModel(this);
            EnterBarcodeVM = new EnterBarcodeViewModel(this);
            OOHPODCompartmentVM = new OOHPODCompartmentViewModel(this);
            CurrentScreen = HomeVM;
            BackBtnCommand = new RelayCommand(_ => NavigateBack());
        }
        public ICommand BackBtnCommand { get; }
        public bool IsOnDropOffScreen => CurrentScreen == SelectCustomerVM || CurrentScreen == SelectCarrierVM || CurrentScreen == RecipientsVM || CurrentScreen == OOHPODScanVM || CurrentScreen == EnterBarcodeVM || CurrentScreen == OOHPODCompartmentVM;

        public HomeViewModel HomeVM { get; }
        public SelectCustomerViewModel SelectCustomerVM { get; }
        public SelectCarrierViewModel SelectCarrierVM { get; }

        public RecipientsViewModel RecipientsVM { get; }

        public OOHPODScanViewModel OOHPODScanVM { get; }
        public EnterBarcodeViewModel EnterBarcodeVM { get; }
        public OOHPODCompartmentViewModel OOHPODCompartmentVM { get; }

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
                RecipientsVM.Reset();
                CurrentScreen = SelectCarrierVM;
            }
            else if (CurrentScreen == OOHPODScanVM)
            {
                RecipientsVM.Reset();
                CurrentScreen = RecipientsVM;

            }
            else if (CurrentScreen == EnterBarcodeVM)
            {
                EnterBarcodeVM.Barcode = string.Empty;
                CurrentScreen = OOHPODScanVM;
            }
            else if (CurrentScreen == OOHPODCompartmentVM)
            {
                EnterBarcodeVM.Barcode = string.Empty;
                CurrentScreen = EnterBarcodeVM;
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
            if (o is Carrier carrier)
            {
                if (carrier.Name == "OOHPOD")
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

        public async Task NavigateToOOHPODCompartment()
        {
          bool isContinue = await EnterBarcodeVM.Confirm();
            if (isContinue) 
            { 
                CurrentScreen = OOHPODCompartmentVM;
            }          
        }

    }
}
