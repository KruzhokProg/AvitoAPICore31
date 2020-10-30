using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvitoAPICore31.Models
{
    public class HistoryModel
    {
        public int userId { get; set; }
        public int adId { get; set; }
        public bool seen { get; set; }
        public bool liked { get; set; }
    }
}
