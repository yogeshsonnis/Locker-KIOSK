using System.Windows.Input;

namespace Locker_KIOSK.ViewModels
{
    public class RecipientsViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainVM;

        public string TempId = "12345678";

        private string _oohId;

        public string OOHId
        {
            get { return _oohId; }
            set
            {
                _oohId = value;
                OnPropertyChanged();
            }
        }

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

        public RecipientsViewModel(MainViewModel mainVM)
        {
            _mainVM = mainVM;

            ConfirmCommand = new RelayCommand(_ => Confirm());
            ConfirmNextCommand = new RelayCommand(_ => mainVM.NavigateToOOHPODScan());
            BackCommand = new RelayCommand(_ => Back());
            ReEnterBackCommand = new RelayCommand(_ => ReEnterBack());
        }

        private void ReEnterBack()
        {
            IsConfirmPopupVisible = false;
        }

        private void Back()
        {
            IsErrorPopupVisible   = false;
        }

        private void Confirm()
        {
            if (TempId == OOHId)
            {
                IsConfirmPopupVisible = true;
                IsErrorPopupVisible   = false;
            }
            else
            {
                IsConfirmPopupVisible = false;
                IsErrorPopupVisible   = true;
            }

        }
        public void Reset()
        {
            OOHId = string.Empty;
            IsConfirmPopupVisible = false;
            IsErrorPopupVisible   = false;
        }

        public ICommand ReEnterBackCommand { get; }
        public ICommand ConfirmCommand { get; }
        public ICommand BackCommand { get; }
        public ICommand ConfirmNextCommand { get; }
    }
}
