using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messages_DAL.DTO.Chats;

namespace Messages_PubSubAPI.Hubs.Chats
{
    public interface IChatClient
    {
        Task ChatCreatedEvent(ChatDTO chat);
    }
}
