using FustalTeamManagement.Services.Player;
using FustalTeamManagement.Services.Player.Dto;
using Microsoft.AspNetCore.Mvc;

namespace FutsalTeamManagement.API.Controllers
{
    [ApiController]
    [Route("api/players")]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerServices _playerServices;
        public PlayerController(PlayerServices playerServices)
        {
            _playerServices = playerServices;
        }
        [HttpGet()]
        public async Task<List<GetPlayerResultDto>> GetAll()
        {
            return await _playerServices.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<GetPlayerResultDto> Get([FromRoute] int id)
        {
            return await _playerServices.Get(id);
        }
        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            await _playerServices.Delete(id);
        }
        [HttpPost]
        public async Task Add(AddPlayerDto dto)
        {
            await _playerServices.Add(dto);
        }
        [HttpPatch]
        public async Task Update(UpdatePlayerDto dto)
        {
            await _playerServices.Update(dto);
        }
        [HttpGet("Find")]
        public async Task<List<GetPlayerResultDto>> FindPlayers([FromQuery]string? name,
            [FromQuery]int? minAge, [FromQuery]int? maxAge)
        {
            return await _playerServices.FindPlayers(name, minAge, maxAge);
        }

    }
}
