using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages_DAL.DTO.Messages;
using Messages_DAL.Repositories.Messages;

namespace Messages_DAL.Services.Messages
{
    public class MessagesService : IMessagesService
    {
        private readonly IMessagesRepository messagesRepository;

        public MessagesService(IMessagesRepository messagesRepository)
        {
            this.messagesRepository = messagesRepository;
        }

        public MessageDTO Create(MessageDTO message) => messagesRepository.Create(message);

        public MessageDTO Update(MessageDTO message) => messagesRepository.Update(message);

        public MessageDTO Delete(int id) => messagesRepository.Delete(id);
    }
}
