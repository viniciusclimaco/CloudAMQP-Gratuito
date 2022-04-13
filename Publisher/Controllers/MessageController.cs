using Microsoft.AspNetCore.Mvc;
using Publisher.Dtos;
using Publisher.Rabbit;

namespace Publisher.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessage _messagePublisher;

        public MessageController(IMessage messagePublisher)
        {
            _messagePublisher = messagePublisher;
        }

        [HttpPost]
        public IActionResult CreateMessage(MessageDto messageDto)
        {
            _messagePublisher.SendMessage(messageDto);

            return Ok(new { id = Guid.NewGuid() });
        }
    }
}
