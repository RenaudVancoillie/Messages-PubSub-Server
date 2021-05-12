using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages_DAL.DTO.Chats;
using Messages_DAL.Models;
using Messages_DAL.Repositories.Chats;

namespace Messages_DAL.Services.Chats
{
    public class ChatsService : IChatsService
    {
        private readonly IChatsRepository chatsRepository;

        public ChatsService(IChatsRepository chatsRepository)
        {
            this.chatsRepository = chatsRepository;
        }

        public IEnumerable<ChatDTO> GetAll()
        {
            return chatsRepository.GetAll()
                .Select(c => new ChatDTO
                {
                    Id = c.Id,
                    Guid = c.Guid,
                    Name = c.Name
                });
        }
    }
}
