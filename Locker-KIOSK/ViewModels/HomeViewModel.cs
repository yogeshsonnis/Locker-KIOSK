using System.Windows.Input;

namespace Locker_KIOSK.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainVM;

        public HomeViewModel(MainViewModel mainVM)
        {
            _mainVM = mainVM;
            DropOffNextCommand = new RelayCommand(_ => _mainVM.NavigateToDeliveryDriver());
           
        }
        public ICommand DropOffNextCommand { get; }       

    }
}
