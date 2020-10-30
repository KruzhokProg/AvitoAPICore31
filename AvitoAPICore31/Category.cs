﻿using System;
using System.Collections.Generic;

namespace AvitoAPICore31
{
    public partial class Category
    {
        public Category()
        {
            Ad = new HashSet<Ad>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Ad> Ad { get; set; }
    }
}
