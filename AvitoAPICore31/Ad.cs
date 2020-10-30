using System;
using System.Collections.Generic;

namespace AvitoAPICore31
{
    public partial class Ad
    {
        public Ad()
        {
            AdPhotos = new HashSet<AdPhotos>();
            Comment = new HashSet<Comment>();
            WatchHistory = new HashSet<WatchHistory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime DateOfPublication { get; set; }
        public bool Active { get; set; }
        public int ConditionId { get; set; }
        public int TypeId { get; set; }
        public string Communication { get; set; }

        public virtual Category Category { get; set; }
        public virtual Condition Condition { get; set; }
        public virtual Type Type { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<AdPhotos> AdPhotos { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<WatchHistory> WatchHistory { get; set; }
    }
}
