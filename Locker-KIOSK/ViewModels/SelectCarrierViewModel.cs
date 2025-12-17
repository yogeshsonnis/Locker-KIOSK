using Locker_KIOSK.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Locker_KIOSK.ViewModels
{  
    public class SelectCarrierViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainVM;
        public ObservableCollection<Carrier> Carriers { get; }

        public SelectCarrierViewModel(MainViewModel mainVM)
        {
            _mainVM = mainVM;
            Carriers = new ObservableCollection<Carrier>
            { 
                new Carrier { Name="OOHPOD", LogoPath = "/Images/OODPOD.png" }, 
                new Carrier { Name = "UnitedParcelService" , LogoPath = "/Images/United_Parcel_Service.png" },
                new Carrier {  Name="DPDEmblem", LogoPath = "/Images/DPD_Emblem.png" },
                new Carrier {  Name="DHLEmblem", LogoPath = "/Images/DHL_Emblem.png" },
                new Carrier {  Name="GLS", LogoPath = "/Images/GLS_Logo.png" },
                new Carrier {  Name="AnPost", LogoPath = "/Images/An_Post_Logo.png" },
            };
            OOHNextCommand = new RelayCommand(o => _mainVM.NavigateToRecipients(o));
        }
        public ICommand OOHNextCommand { get; }
    }
}