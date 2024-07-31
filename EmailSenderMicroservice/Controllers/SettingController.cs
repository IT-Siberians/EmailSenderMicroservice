using EmailSenderMicroservice.Contracts.Setting;
using EmailSenderMicroservice.Domain.Interface.Service;
using EmailSenderMicroservice.Domain.Models;
using EmailSenderMicroservice.Domain.ValueObject;
using Microsoft.AspNetCore.Mvc;

namespace EmailSenderMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SettingController : ControllerBase
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService) 
        {
            _settingService = settingService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SettingResponse>), 200)]
        public async Task<ActionResult<List<SettingResponse>>> GetAllAcync() 
        {
            var settings = await _settingService.GetAllAsync();
            
            var response = settings
                .Select(z=> new SettingResponse(
                    z.Id,
                    z.Connection.Address,
                    z.Connection.Port,
                    z.UseSSL,
                    z.Login.Value,
                    z.Password,
                    z.CreateDate
                    ))
                .ToList();

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(SettingResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<SettingResponse>> GetByIdAcync(Guid id)
        {
            var setting = await _settingService.GetByIdAsync(id);

            if (setting == null)
            {
                return NotFound($"Setting id:{id} not found!");
            }

            var response = new SettingResponse(
                setting.Id,
                setting.Connection.Address,
                setting.Connection.Port,
                setting.UseSSL,
                setting.Login.Value,
                setting.Password,
                setting.CreateDate);

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(SettingResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<SettingResponse>> GetAcync()
        {
            var setting = await _settingService.GetAsync();

            if (setting == null)
            {
                return NotFound($"Default Setting not found!");
            }

            var response = new SettingResponse(
                setting.Id,
                setting.Connection.Address,
                setting.Connection.Port,
                setting.UseSSL,
                setting.Login.Value,
                setting.Password,
                setting.CreateDate);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Guid>> AddAsync([FromBody] SettingRequest request)
        {
            var conn = new Connection(request.ServerAddress, request.ServerPort);
            var log = new Email(request.Login);
            var setting = new Setting(
                Guid.NewGuid(),
                conn,
                request.UseSSL,
                log,
                request.Password,
                DateTime.UtcNow);

            var settingId = await _settingService.AddAsync(setting);

            return Ok(settingId);
        }

    }
}
