using System.Windows.Input;

namespace Locker_KIOSK.ViewModels
{
    public class SelectCustomerViewModel : ViewModelBase
    {
            private readonly MainViewModel _mainVM;

            public SelectCustomerViewModel(MainViewModel mainVM)
            {
                _mainVM = mainVM;
              DeliveryNextCommand = new RelayCommand(_ => _mainVM.NavigateToCarrier());
            }
        public ICommand DeliveryNextCommand { get; }
    }
}
