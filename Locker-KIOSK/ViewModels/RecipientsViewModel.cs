using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Locker_KIOSK.ViewModels
{
    public class RecipientsViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainVM;

        public RecipientsViewModel(MainViewModel mainVM)
        {
            _mainVM = mainVM;
            
        }
        
    }
}
