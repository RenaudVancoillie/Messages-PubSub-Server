using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Messages_PubSubAPI.Hubs.Chats
{
    public class ChatHub : Hub<IChatClient>, IChatHub
    {
    }
}
