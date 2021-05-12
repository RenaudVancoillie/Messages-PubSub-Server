﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messages_DAL.DTO.Chats;
using Messages_DAL.Services.Chats;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Messages_PubSubAPI.Controllers.Chats
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase, IChatsController
    {
        private readonly IChatsService chatsService;

        public ChatsController(IChatsService chatsService)
        {
            this.chatsService = chatsService;
        }

        public ActionResult<IEnumerable<ChatDTO>> GetAll()
        {
            try
            {
                IEnumerable<ChatDTO> chats = chatsService.GetAll();
                return Ok(chats);
            }
            catch (Exception exc)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Something went wrong: {exc.Message}");
            }
        }
    }
}