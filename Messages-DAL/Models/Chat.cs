using System;
using System.Collections.Generic;

#nullable disable

namespace Messages_DAL.Models
{
    public partial class Chat
    {
        public Chat()
        {
            Messages = new HashSet<Message>();
        }

        public int Id { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
