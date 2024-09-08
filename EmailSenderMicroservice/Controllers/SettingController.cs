using AutoMapper;
using EmailSenderMicroservice.Application.Models.Setting;
using EmailSenderMicroservice.Application.Services.Abstraction;
using EmailSenderMicroservice.Contracts.Setting;
using Microsoft.AspNetCore.Mvc;

namespace EmailSenderMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SettingController(ISettingService settingService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SettingResponse>), 200)]
        public async Task<ActionResult<List<SettingResponse>>> GetAllAsync()
        {
            var settings = await settingService.GetAllAsync();

            return Ok(settings.Select(mapper.Map<SettingResponse>));
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(SettingResponse), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult<SettingResponse>> GetByIdAsync(Guid id)
        {
            var setting = await settingService.GetByIdAsync(id);

            if (setting is null)
            {
                return NotFound($"Setting {id} not found!");
            }

            return Ok(mapper.Map<SettingResponse>(setting));
        }

        [HttpGet]
        [ProducesResponseType(typeof(SettingResponse), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult<SettingResponse>> GetCurrentAsync()
        {
            var setting = await settingService.GetCurrentAsync();

            if (setting is null)
            {
                return NotFound($"Default Setting not found!");
            }

            return Ok(mapper.Map<SettingResponse>(setting));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), 201)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult<Guid>> AddAsync([FromBody] SettingRequest request)
        {
            var settingId = await settingService.AddAsync(mapper.Map<AddSettingModel>(request));

            if (settingId == Guid.Empty)
            {
                return BadRequest("Setting can not be created");
            }

            return Created("", settingId);
        }

    }
}
