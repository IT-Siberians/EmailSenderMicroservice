using EmailSenderMicroservice.Contracts.Message;
using EmailSenderMicroservice.Domain.Interface.Service;
using Microsoft.AspNetCore.Mvc;

namespace EmailSenderMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MessageResponse>), 200)]
        public async Task<ActionResult<List<MessageResponse>>> GetAllAsync()
        {
            var messages = await _messageService.GetAllAsync();

            var response = messages.Select(z => new MessageResponse(z.Id, z.Email.Value, z.MessageType, z.MessageText, z.Status, z.CreateDate));

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(MessageResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<MessageResponse>> GetByIdAcync(Guid id)
        {
            var message = await _messageService.GetByIdAsync(id);
            
            if (message == null)
            {
                return NotFound($"Message id:{id} not found!");
            }

            var response = new MessageResponse(
                message.Id,
                message.Email.Value,
                message.MessageType,
                message.MessageText,
                message.Status,
                message.CreateDate);

            return Ok(response);
        }
    }
}
