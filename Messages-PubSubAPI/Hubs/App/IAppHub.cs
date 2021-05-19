using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messages_DAL.DTO.Chats;

namespace Messages_PubSubAPI.Hubs.App
{
    public interface IAppHub
    {
        Task Subscribe(string topic);
        Task Unsubscribe(string topic);
        Task Publish(string topic, string data);
    }
}
