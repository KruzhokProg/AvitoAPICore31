using System;
using System.Collections.Generic;

namespace AvitoAPICore31
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int UserIdReceiver { get; set; }
        public int UserIdSender { get; set; }
        public int AdId { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public virtual Ad Ad { get; set; }
        public virtual User UserIdReceiverNavigation { get; set; }
        public virtual User UserIdSenderNavigation { get; set; }
    }
}
