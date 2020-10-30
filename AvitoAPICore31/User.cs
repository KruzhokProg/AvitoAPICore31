using System;
using System.Collections.Generic;

namespace AvitoAPICore31
{
    public partial class User
    {
        public User()
        {
            Ad = new HashSet<Ad>();
            CommentUserIdReceiverNavigation = new HashSet<Comment>();
            CommentUserIdSenderNavigation = new HashSet<Comment>();
            CreditCard = new HashSet<CreditCard>();
            WatchHistory = new HashSet<WatchHistory>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public double? Rating { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public string CompanyName { get; set; }
        public double? Balance { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Ad> Ad { get; set; }
        public virtual ICollection<Comment> CommentUserIdReceiverNavigation { get; set; }
        public virtual ICollection<Comment> CommentUserIdSenderNavigation { get; set; }
        public virtual ICollection<CreditCard> CreditCard { get; set; }
        public virtual ICollection<WatchHistory> WatchHistory { get; set; }
    }
}
