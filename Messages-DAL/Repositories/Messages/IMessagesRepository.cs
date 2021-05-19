using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages_DAL.DTO.Messages;

namespace Messages_DAL.Repositories.Messages
{
    public interface IMessagesRepository
    {
        MessageDTO Create(MessageDTO message);
        MessageDTO Update(MessageDTO message);
        MessageDTO Delete(int id);
    }
}
