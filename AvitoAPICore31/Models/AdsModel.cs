using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvitoAPICore31.Models
{
    public class AdsModel
    {               
        public string name { get; set; }
        public int categoryId { get; set; }
        public double price { get; set; }
        public int userId { get; set; }
        public string description { get; set; }                
        public int conditionId { get; set; }
        public int typeId { get; set; }
        public string communication { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
