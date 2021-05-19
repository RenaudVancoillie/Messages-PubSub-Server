using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messages_DAL.DTO.Messages;
using Messages_DAL.Services.Messages;
using Microsoft.AspNetCore.SignalR;

namespace Messages_PubSubAPI.Hubs.Messages
{
    public class MessageHub : Hub<IMessageClient>, IMessageHub
    {
        private readonly IMessagesService messagesService;

        public MessageHub(IMessagesService messagesService)
        {
            this.messagesService = messagesService;
        }

        public async Task Create(string channel, MessageDTO message)
        {
            message = messagesService.Create(message);
            await Clients.Group(channel).MessageCreatedEvent(message);
        }

        public async Task Update(string channel, MessageDTO message)
        {
            message = messagesService.Update(message);
            await Clients.Group(channel).MessageUpdatedEvent(message);
        }

        public async Task Delete(string channel, int id)
        {
            MessageDTO message = messagesService.Delete(id);
            await Clients.Group(channel).MessageDeletedEvent(message);
        }
    }
}
