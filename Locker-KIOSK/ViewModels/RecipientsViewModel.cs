using Locker_KIOSK.Model;
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

        private bool _isExecute = true;

        public bool IsExecute
        {
            get { return _isExecute; }
            set { _isExecute = value; OnPropertyChanged(); }
        }

        #region Key Property Region

        private string _otp1;
        public string Otp1
        {
            get => _otp1;
            set { _otp1 = value; OnPropertyChanged(); UpdateOOHId(); }
        }

        private string _otp2;
        public string Otp2
        {
            get => _otp2;
            set { _otp2 = value; OnPropertyChanged(); UpdateOOHId(); }
        }

        private string _otp3;
        public string Otp3
        {
            get => _otp3;
            set { _otp3 = value; OnPropertyChanged(); UpdateOOHId(); }
        }

        private string _otp4;
        public string Otp4
        {
            get => _otp4;
            set { _otp4 = value; OnPropertyChanged(); UpdateOOHId(); }
        }

        private string _otp5;
        public string Otp5
        {
            get => _otp5;
            set { _otp5 = value; OnPropertyChanged(); UpdateOOHId(); }
        }

        private string _otp6;
        public string Otp6
        {
            get => _otp6;
            set { _otp6 = value; OnPropertyChanged(); UpdateOOHId(); }
        }

        private string _otp7;
        public string Otp7
        {
            get => _otp7;
            set { _otp7 = value; OnPropertyChanged(); UpdateOOHId(); }
        }

        private string _otp8;
        public string Otp8
        {
            get => _otp8;
            set { _otp8 = value; OnPropertyChanged(); UpdateOOHId(); }
        }

        #endregion

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


            KeyCommand = new RelayCommand(param => KeyPressed(param));
            DeleteIdCommand = new RelayCommand(_ => OnBackPressed());
        }

        private void KeyPressed(object param)
        {
            if (param == null)
                return;

            string key = param.ToString();

            if (string.IsNullOrEmpty(Otp1)) Otp1 = key;
            else if (string.IsNullOrEmpty(Otp2)) Otp2 = key;
            else if (string.IsNullOrEmpty(Otp3)) Otp3 = key;
            else if (string.IsNullOrEmpty(Otp4)) Otp4 = key;
            else if (string.IsNullOrEmpty(Otp5)) Otp5 = key;
            else if (string.IsNullOrEmpty(Otp6)) Otp6 = key;
            else if (string.IsNullOrEmpty(Otp7)) Otp7 = key;
            else if (string.IsNullOrEmpty(Otp8)) Otp8 = key;
        }

        private void OnBackPressed()
        {
            if (!string.IsNullOrEmpty(Otp8)) Otp8 = "";
            else if (!string.IsNullOrEmpty(Otp7)) Otp7 = "";
            else if (!string.IsNullOrEmpty(Otp6)) Otp6 = "";
            else if (!string.IsNullOrEmpty(Otp5)) Otp5 = "";
            else if (!string.IsNullOrEmpty(Otp4)) Otp4 = "";
            else if (!string.IsNullOrEmpty(Otp3)) Otp3 = "";
            else if (!string.IsNullOrEmpty(Otp2)) Otp2 = "";
            else if (!string.IsNullOrEmpty(Otp1)) Otp1 = "";
        }

        private void UpdateOOHId()
        {
            OOHId = $"{Otp1}{Otp2}{Otp3}{Otp4}{Otp5}{Otp6}{Otp7}{Otp8}";
        }

        private void ReEnterBack()
        {
            IsConfirmPopupVisible = false;
            Reset();
        }

        private void Back()
        {
            IsErrorPopupVisible = false;
        }

        private async Task Confirm()
        {
            IsExecute = false;
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
            IsExecute = true;

        }
        public void Reset()
        {
            OOHId = string.Empty;
            IsConfirmPopupVisible = false;
            IsErrorPopupVisible = false;
            Otp1 = Otp2 = Otp3 = Otp4 =
            Otp5 = Otp6 = Otp7 = Otp8 = string.Empty;

        }

        public ICommand ReEnterBackCommand { get; }
        public ICommand ConfirmCommand { get; }
        public ICommand BackCommand { get; }
        public ICommand ConfirmNextCommand { get; }

        public ICommand DeleteIdCommand { get; }

        public ICommand KeyCommand { get; }
    }
}
