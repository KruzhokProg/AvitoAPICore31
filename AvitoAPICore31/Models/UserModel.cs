using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvitoAPICore31.Models
{
    public class UserModel
    {
        public String Email { get; set; }
        public String Password { get; set; }
        public int RoleId { get; set; }
        public String PhoneNumber { get; set; }
        public String CompanyName { get; set; }
    }
}
