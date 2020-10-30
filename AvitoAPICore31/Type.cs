using System;
using System.Collections.Generic;

namespace AvitoAPICore31
{
    public partial class Type
    {
        public Type()
        {
            Ad = new HashSet<Ad>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Ad> Ad { get; set; }
    }
}
