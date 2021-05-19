using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messages_DAL.DTO.Chats;

namespace Messages_PubSubAPI.Hubs.App
{
    public interface IAppClient
    {
        Task Subscribed(string topic);
        Task Unsubscribed(string topic);
        Task Published(string topic, string data);
        Task SubscriptionFailed(string topic, string failure);
        Task UnsubscriptionFailed(string topic, string failure);
        Task PublishFailed(string topic, string failure);
    }
}
