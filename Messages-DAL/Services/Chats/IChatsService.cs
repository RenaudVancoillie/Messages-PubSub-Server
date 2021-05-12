using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages_DAL.Models;

namespace Messages_DAL.Services.Chats
{
    public interface IChatsService
    {
        IEnumerable<Chat> GetAll();
    }
}
