using System;
using System.Collections.Generic;

namespace AvitoAPICore31
{
    public partial class CreditCard
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public int UserId { get; set; }
        public string BankName { get; set; }
        public string BankLogo { get; set; }
        public double Balance { get; set; }

        public virtual User User { get; set; }
    }
}
