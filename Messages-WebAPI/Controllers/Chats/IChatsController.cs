using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messages_DAL.DTO.Chats;
using Microsoft.AspNetCore.Mvc;

namespace Messages_PubSubAPI.Controllers.Chats
{
    public interface IChatsController
    {
        ActionResult<IEnumerable<ChatDTO>> GetAll();
        ActionResult<ChatDetailDTO> GetById(int id);
    }
}
