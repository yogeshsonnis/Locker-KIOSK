using Locker_KIOSK.Model;
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
            CurrentScreen = HomeVM;
            BackBtnCommand = new RelayCommand(_ => NavigateBack());
        }
        public ICommand BackBtnCommand { get; }
        public bool IsOnDropOffScreen => CurrentScreen == SelectCustomerVM || CurrentScreen == SelectCarrierVM || CurrentScreen == RecipientsVM;

        public HomeViewModel HomeVM { get; }
        public SelectCustomerViewModel SelectCustomerVM { get; }
        public SelectCarrierViewModel SelectCarrierVM { get; }

        public RecipientsViewModel RecipientsVM { get; }

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
    }
}
