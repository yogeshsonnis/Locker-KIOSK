using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locker_KIOSK.ViewModels
{
    public class OOHPODScanViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainVM;

        public OOHPODScanViewModel(MainViewModel mainVM)
        {
            _mainVM = mainVM;

        }
    }
}
