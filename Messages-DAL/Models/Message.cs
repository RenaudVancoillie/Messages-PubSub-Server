using System;
using System.Collections.Generic;

#nullable disable

namespace Messages_DAL.Models
{
    public partial class Message
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public string Sender { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Chat Chat { get; set; }
    }
}
