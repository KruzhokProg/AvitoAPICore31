using System;
using System.Collections.Generic;

namespace AvitoAPICore31
{
    public partial class WatchHistory
    {
        public int UserId { get; set; }
        public int AdId { get; set; }
        public bool Seen { get; set; }
        public bool Liked { get; set; }

        public virtual Ad Ad { get; set; }
        public virtual User User { get; set; }
    }
}
