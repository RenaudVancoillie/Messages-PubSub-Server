using System;
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

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ChatDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
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

        [HttpGet("{id:int:min(1)}")]
        [ProducesResponseType(typeof(ChatDetailDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public ActionResult<ChatDetailDTO> GetById(int id)
        {
            try
            {
                ChatDetailDTO chat = chatsService.GetById(id);
                if (chat == null)
                {
                    return NotFound($"Chat with id {id} not found.");
                }
                return Ok(chat);
            }
            catch (Exception exc)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Something went wrong: {exc.Message}");
            }
        }

        [HttpPost]
        public ActionResult<ChatDTO> Create([FromBody] ChatDTO chat)
        {
            try
            {
                chat = chatsService.Create(chat);
                return Ok(chat);
            } 
            catch (Exception exc)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Something went wrong: {exc.Message}");
            }
        }
    }
}
