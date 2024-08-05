using AutoMapper;
using EmailSenderMicroservice.Application.Interface;
using EmailSenderMicroservice.Application.Model;
using EmailSenderMicroservice.Contracts.Setting;
using Microsoft.AspNetCore.Mvc;

namespace EmailSenderMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SettingController : ControllerBase
    {
        private readonly ISettingService _settingService;
        private readonly IMapper _mapper;

        public SettingController(ISettingService settingService, IMapper mapper) 
        {
            _settingService = settingService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SettingResponse>), 200)]
        public async Task<ActionResult<List<SettingResponse>>> GetAllAcync() 
        {
            var settings = await _settingService.GetAllAsync();

            return Ok(settings.Select(_mapper.Map<SettingResponse>));
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(SettingResponse), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult<SettingResponse>> GetByIdAcync(Guid id)
        {
            var setting = await _settingService.GetByIdAsync(id);

            if (setting is null)
            {
                return NotFound($"Setting {id} not found!");
            }

            return Ok(_mapper.Map<SettingResponse>(setting));
        }

        [HttpGet]
        [ProducesResponseType(typeof(SettingResponse), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult<SettingResponse>> GetAcync()
        {
            var setting = await _settingService.GetAsync();

            if (setting is null)
            {
                return NotFound($"Default Setting not found!");
            }

            return Ok(_mapper.Map<SettingResponse>(setting));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), 201)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult<Guid>> AddAsync([FromBody] SettingRequest request)
        {

            var settingId = await _settingService.AddAsync(_mapper.Map<SettingAddModel>(request));

            if (settingId == Guid.Empty)
            {
                return BadRequest("Setting can not be created");
            }

            return Created("",settingId);
        }

    }
}
