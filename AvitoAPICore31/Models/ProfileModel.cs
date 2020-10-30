using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvitoAPICore31.Models
{
    public class ProfileModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Metro { get; set; }
        public IFormFile Image { get; set; }
    }
}
