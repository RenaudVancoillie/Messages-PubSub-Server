using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Messages_DAL.DTO.Messages;
using Messages_DAL.Models;

namespace Messages_PubSubAPI.Mappings
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageDTO>().ReverseMap();
        }
    }
}
