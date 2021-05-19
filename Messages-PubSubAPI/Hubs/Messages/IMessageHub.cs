using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messages_DAL.DTO.Messages;

namespace Messages_PubSubAPI.Hubs.Messages
{
    public interface IMessageHub
    {
        Task Create(MessageDTO message);
        Task Update(MessageDTO message);
        Task Delete(int id);
    }
}
