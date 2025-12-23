using Locker_KIOSK.Model;
using Locker_KIOSK.Services;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Locker_KIOSK.ViewModels
{
    public class RecipientsViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainVM;

        private string _oohId;

        public string OOHId
        {
            get => _oohId;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _oohId = "OOH";
                }
                else if (!value.StartsWith("OOH"))
                {
                    _oohId = "OOH" + value.Replace("OOH", "");
                }
                else
                {
                    _oohId = value;
                }

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

            ConfirmCommand = new RelayCommand(async _ => await Confirm());
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
            IsErrorPopupVisible = false;
        }

        private async Task Confirm()
        {
            //"OOH45678976"
            var user = await _mainVM._apiService.UserExistsAsync<UserResponse>(OOHId);
            if (user != null)
            {
                IsConfirmPopupVisible = true;
                IsErrorPopupVisible = false;
            }
            else
            {
                IsConfirmPopupVisible = false;
                IsErrorPopupVisible = true;
            }

        }
        public void Reset()
        {
            OOHId = string.Empty;
            IsConfirmPopupVisible = false;
            IsErrorPopupVisible = false;
        }

        public ICommand ReEnterBackCommand { get; }
        public ICommand ConfirmCommand { get; }
        public ICommand BackCommand { get; }
        public ICommand ConfirmNextCommand { get; }
    }
}
