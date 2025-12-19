using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Locker_KIOSK.ViewModels
{
   public class EnterBarcodeViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainVM;

        public EnterBarcodeViewModel(MainViewModel mainVM)
        {
            _mainVM = mainVM;
           
        }
        
    }
}
