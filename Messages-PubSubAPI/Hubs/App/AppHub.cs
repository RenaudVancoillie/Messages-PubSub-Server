using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messages_PubSubAPI.Hubs.Helpers;
using Microsoft.AspNetCore.SignalR;

namespace Messages_PubSubAPI.Hubs.App
{
    public class AppHub : Hub<IAppClient>, IAppHub
    {
        public async Task Subscribe(string topic)
        {
            try
            {
                if (topic != null)
                {
                    if (Enum.IsDefined(typeof(Topic), topic))
                    {
                        await Groups.AddToGroupAsync(topic, Context.ConnectionId);
                        await Clients.Caller.Subscribed(topic);
                    }
                    else
                    {
                        await Clients.Caller.SubscriptionFailed(topic, $"Topic '{topic}' does not exist.");
                    }
                }
                else
                {
                    await Clients.Caller.SubscriptionFailed(topic, $"Topic cannot be {topic}.");
                }
            }
            catch (Exception exc)
            {
                await Clients.Caller.SubscriptionFailed(topic, exc.Message);
            }
        }

        public async Task Unsubscribe(string topic)
        {
            try
            {
                if (topic != null)
                {
                    if (Enum.IsDefined(typeof(Topic), topic))
                    {
                        await Groups.RemoveFromGroupAsync(topic, Context.ConnectionId);
                        await Clients.Caller.Unsubscribed(topic);
                    }
                    else
                    {
                        await Clients.Caller.UnsubscriptionFailed(topic, $"Topic '{topic}' does not exist.");
                    }
                }
                else
                {
                    await Clients.Caller.UnsubscriptionFailed(topic, $"Topic cannot be {topic}.");
                }
            }
            catch (Exception exc)
            {
                await Clients.Caller.SubscriptionFailed(topic, exc.Message);
            }
        }

        public async Task Publish(string topic, string data)
        {
            try
            {
                await Clients.Group(topic).Published(topic, data);
            }
            catch (Exception exc)
            {
                await Clients.Caller.PublishFailed(topic, exc.Message);
            }
        }
    }
}
