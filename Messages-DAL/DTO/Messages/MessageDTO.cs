using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages_DAL.DTO.Messages
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public string Sender { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
