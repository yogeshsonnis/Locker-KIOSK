using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locker_KIOSK.Model
{
   public class User
    {
        public int OohpodUserId { get; set; }
        public string OohpodId { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Email { get; set; } = "";
        public bool IsActive { get; set; }
        public string Status { get; set; } = "";

    }

    public class UserResponse
    {
        public User Data { get; set; } = new User();
    }
}
