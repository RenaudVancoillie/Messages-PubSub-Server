using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages_DAL.DTO.Chats;

namespace Messages_DAL.Services.Chats
{
    public interface IChatsService
    {
        IEnumerable<ChatDTO> GetAll();
        ChatDetailDTO GetById(int id);
        ChatDTO Create(ChatDTO chat);
    }
}
