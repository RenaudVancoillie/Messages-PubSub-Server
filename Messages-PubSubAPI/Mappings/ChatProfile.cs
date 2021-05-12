using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Messages_DAL.DTO.Chats;
using Messages_DAL.Models;

namespace Messages_PubSubAPI.Mappings
{
    public class ChatProfile : Profile
    {
        public ChatProfile()
        {
            CreateMap<Chat, ChatDTO>();
        }
    }
}
