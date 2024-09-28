using AutoMapper;
using EmailSenderMicroservice.Application.Services.Abstraction;
using EmailSenderMicroservice.Contracts.Message;
using Microsoft.AspNetCore.Mvc;

namespace EmailSenderMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController(IMessageService messageService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MessageResponse>), 200)]
        public async Task<ActionResult<List<MessageResponse>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var messages = await messageService.GetAllAsync(cancellationToken);

            return Ok(messages.Select(mapper.Map<MessageResponse>));
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(MessageResponse), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult<MessageResponse>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var message = await messageService.GetByIdAsync(id, cancellationToken);

            if (message is null)
            {
                return NotFound($"Message {id} not found!");
            }

            return Ok(mapper.Map<MessageResponse>(message));
        }
    }
}
