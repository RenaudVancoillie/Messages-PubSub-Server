using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages_DAL.Models;
using Messages_DAL.Repositories.Chats;

namespace Messages_DAL.Services.Chats
{
    public class ChatService : IChatsService
    {
        private readonly IChatsRepository chatsRepository;

        public ChatService(IChatsRepository chatsRepository)
        {
            this.chatsRepository = chatsRepository;
        }

        public IEnumerable<Chat> GetAll() => chatsRepository.GetAll();
    }
}
