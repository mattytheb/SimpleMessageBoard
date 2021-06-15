using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SimpleMessageBoard.Dtos;
using SimpleMessageBoard.Services.Interfaces;

namespace SimpleMessageBoard.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost(Name = "Message"), Consumes("application/json")]
        public async Task<IActionResult> AddMessage([FromBody] MessageDto request)
        {
            try
            {
                var result = await _messageService.AddMessageAsync(request);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Unable to add message: {ex}");
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{userId}", Name = "GetMessages")]
        public ActionResult<IEnumerable<MessageDto>> GetMessages(int userId)
        {
            try
            {
                return Ok(_messageService.GetMessagesByUserId(userId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Unable to get messages: {ex}");
            }
        }
    }
}
