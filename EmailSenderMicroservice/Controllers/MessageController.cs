using AutoMapper;
using EmailSenderMicroservice.Application.Services.Abstraction;
using EmailSenderMicroservice.Contracts.Message;
using Microsoft.AspNetCore.Mvc;

namespace EmailSenderMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MessageResponse>), 200)]
        public async Task<ActionResult<List<MessageResponse>>> GetAllAsync()
        {
            var messages = await _messageService.GetAllAsync();

            return Ok(messages.Select(_mapper.Map<MessageResponse>));
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(MessageResponse), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult<MessageResponse>> GetByIdAsync(Guid id)
        {
            var message = await _messageService.GetByIdAsync(id);
            
            if (message is null)
            {
                return NotFound($"Message {id} not found!");
            }

            return Ok(_mapper.Map<MessageResponse>(message));
        }
    }
}
