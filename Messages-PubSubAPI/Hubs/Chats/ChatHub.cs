using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messages_DAL.DTO.Chats;
using Messages_DAL.Services.Chats;
using Microsoft.AspNetCore.SignalR;

namespace Messages_PubSubAPI.Hubs.Chats
{
    public class ChatHub : Hub<IChatClient>, IChatHub
    {
        private readonly IChatsService chatsService;

        public ChatHub(IChatsService chatsService)
        {
            this.chatsService = chatsService;
        }

        public async Task CreateChat(ChatDTO chat)
        {
            chat = chatsService.Create(chat);
            await Clients.All.ChatCreatedEvent(chat);
        }
    }
}
