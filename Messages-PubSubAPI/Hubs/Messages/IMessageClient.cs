using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messages_DAL.DTO.Messages;

namespace Messages_PubSubAPI.Hubs.Messages
{
    public interface IMessageClient
    {
        Task MessageCreatedEvent(MessageDTO message);
        Task MessageUpdatedEvent(MessageDTO message);
        Task MessageDeletedEvent(MessageDTO message);
    }
}
