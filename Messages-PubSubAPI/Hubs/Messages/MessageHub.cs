using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messages_DAL.DTO.Messages;
using Microsoft.AspNetCore.SignalR;

namespace Messages_PubSubAPI.Hubs.Messages
{
    public class MessageHub : Hub<IMessageClient>, IMessageHub
    {
        public Task Create(MessageDTO message)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(MessageDTO message)
        {
            throw new NotImplementedException();
        }
    }
}
