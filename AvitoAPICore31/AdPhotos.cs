using System;
using System.Collections.Generic;

namespace AvitoAPICore31
{
    public partial class AdPhotos
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public int AdId { get; set; }

        public virtual Ad Ad { get; set; }
    }
}
