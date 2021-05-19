using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Messages_DAL.Database;
using Messages_DAL.DTO.Chats;
using Messages_DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Messages_DAL.Repositories.Chats
{
    public class ChatsRepository : IChatsRepository
    {
        private readonly MessagesContext db;
        private readonly IMapper mapper;

        public ChatsRepository(MessagesContext messagesContext,
                               IMapper mapper)
        {
            db = messagesContext;
            this.mapper = mapper;
        }

        public IEnumerable<Chat> GetAll()
        {
            return db.Chats
                .OrderBy(c => c.Name)
                .AsEnumerable();
        }

        public ChatDetailDTO GetById(int id)
        {
            return db.Chats
                .Include(c => c.Messages)
                .Where(c => c.Id == id)
                .ProjectTo<ChatDetailDTO>(mapper.ConfigurationProvider)
                .SingleOrDefault();
        }

        public ChatDTO Create(ChatDTO chat)
        {
            Chat record = mapper.Map<Chat>(chat);
            db.Chats.Add(record);
            db.SaveChanges();
            return mapper.Map<ChatDTO>(record);
        }
    }
}
