using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Messages_DAL.DTO.Chats;
using Messages_DAL.Models;
using Messages_DAL.Repositories.Chats;

namespace Messages_DAL.Services.Chats
{
    public class ChatsService : IChatsService
    {
        private readonly IChatsRepository chatsRepository;
        private readonly IMapper mapper;

        public ChatsService(IChatsRepository chatsRepository,
                            IMapper mapper)
        {
            this.chatsRepository = chatsRepository;
            this.mapper = mapper;
        }

        public IEnumerable<ChatDTO> GetAll()
        {
            return chatsRepository.GetAll().AsQueryable()
                .ProjectTo<ChatDTO>(mapper.ConfigurationProvider)
                .AsEnumerable();
        }

        public ChatDetailDTO GetById(int id) => chatsRepository.GetById(id);
    }
}
