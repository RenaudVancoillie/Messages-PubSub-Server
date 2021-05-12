using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages_DAL.Database;
using Messages_DAL.Models;

namespace Messages_DAL.Repositories.Chats
{
    public class ChatsRepository : IChatsRepository
    {
        private readonly MessagesContext db;

        public ChatsRepository(MessagesContext messagesContext)
        {
            db = messagesContext;
        }

        public IEnumerable<Chat> GetAll()
        {
            return db.Chats
                .OrderBy(c => c.Name)
                .ToList();
        }
    }
}
