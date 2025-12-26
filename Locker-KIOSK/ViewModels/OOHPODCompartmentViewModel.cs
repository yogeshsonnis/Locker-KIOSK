using Locker_KIOSK.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Locker_KIOSK.ViewModels
{
    public class OOHPODCompartmentViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainVM;
       
        public OOHPODCompartmentViewModel(MainViewModel mainVM)
        {
            _mainVM = mainVM;

            ReOpenCommand = new RelayCommand(_ => ReOpen());
            ReportIssueCommand = new RelayCommand(_ => ReportIssue());
            OpenBiggerCommand = new RelayCommand(_ => OpenBigger());
            DoneCommand = new RelayCommand(_ => Done());
        }

        private void Done()
        {
           
        }

        private void OpenBigger()
        {
           
        }

        private void ReportIssue()
        {
            
        }

        private void ReOpen()
        {
            
        }

        public ICommand ReOpenCommand { get; }
        public ICommand ReportIssueCommand { get; }
        public ICommand OpenBiggerCommand { get; }
        public ICommand DoneCommand { get; }

        
    }
}
