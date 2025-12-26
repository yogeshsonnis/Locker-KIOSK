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
            
        }
        
    }
}
