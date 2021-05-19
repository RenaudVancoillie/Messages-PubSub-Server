using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages_DAL.DTO.Chats;
using Messages_DAL.Models;

namespace Messages_DAL.Repositories.Chats
{
    public interface IChatsRepository
    {
        IEnumerable<Chat> GetAll();
        ChatDetailDTO GetById(int id);
        ChatDTO Create(ChatDTO chat);
    }
}
