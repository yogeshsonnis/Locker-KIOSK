using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locker_KIOSK.Model
{
    public class CarrierValidateResponse
    {
        public string Status { get; set; } = "";
        public bool AllowParcel { get; set; }
        public string Carrier { get; set; } = "";
        public string TrackingNumber { get; set; } = "";
    }
}
