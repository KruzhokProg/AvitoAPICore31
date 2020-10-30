using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvitoAPICore31.Models
{
    public class CardModel
    {
        public String cardNumber { get; set; }
        public int userId { get; set; }
        public String bankName { get; set; }
        public String bankLogo { get; set; }
        public float balance { get; set; }
    }
}
