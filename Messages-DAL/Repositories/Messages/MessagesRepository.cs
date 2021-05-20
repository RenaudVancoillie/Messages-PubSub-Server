using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Messages_DAL.Database;
using Messages_DAL.DTO.Messages;
using Messages_DAL.Models;

namespace Messages_DAL.Repositories.Messages
{
    public class MessagesRepository : IMessagesRepository
    {
        private readonly MessagesContext db;
        private readonly IMapper mapper;

        public MessagesRepository(MessagesContext context, IMapper mapper)
        {
            db = context;
            this.mapper = mapper;
        }

        public MessageDTO Create(MessageDTO message)
        {
            Message record = mapper.Map<Message>(message);
            db.Messages.Add(record);
            db.SaveChanges();
            return mapper.Map<MessageDTO>(record);
        }

        public MessageDTO Update(MessageDTO message)
        {
            Message record = db.Messages.Where(m => m.Id == message.Id).SingleOrDefault();
            if (record != null)
            {
                mapper.Map(message, record);
                record.UpdatedAt = DateTime.Now;
                db.SaveChanges();
            }
            return mapper.Map<MessageDTO>(record);
        }

        public MessageDTO Delete(int id)
        {
            Message record = db.Messages.Where(m => m.Id == id).SingleOrDefault();
            if (record != null)
            {
                db.Messages.Remove(record);
                db.SaveChanges();
            }
            return mapper.Map<MessageDTO>(record);
        }
    }
}
