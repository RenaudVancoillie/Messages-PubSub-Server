using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messages_DAL.DTO.Messages;

namespace Messages_PubSubAPI.Hubs.Messages
{
    public interface IMessageHub
    {
        Task Subscribe(string channel);
        Task Unsubscribe(string channel);
        Task Create(string channel, MessageDTO message);
        Task Update(string channel, MessageDTO message);
        Task Delete(string channel, int id);
    }
}
