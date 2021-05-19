using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages_DAL.DTO.Messages;

namespace Messages_DAL.Services.Messages
{
    public interface IMessagesService
    {
        MessageDTO Create(MessageDTO message);
        MessageDTO Update(MessageDTO message);
        MessageDTO Delete(int id);
    }
}
