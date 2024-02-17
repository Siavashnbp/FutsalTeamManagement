using FustalTeamManagement.Services.Team;
using FustalTeamManagement.Services.Team.Dto;
using FustalTeamManagement.Services.TeamPlayer;
using FustalTeamManagement.Services.TeamPlayer.Dto;
using FutsalTeamManagement.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FutsalTeamManagement.API.Controllers
{
    [ApiController]
    [Route("api/teams")]
    public class TeamController : ControllerBase
    {
        private readonly TeamServices _teamServices;
        private readonly TeamPlayerServices _teamPlayerServices;
        public TeamController(TeamServices teamServices, TeamPlayerServices teamPlayerServices)
        {
            _teamServices = teamServices;
            _teamPlayerServices = teamPlayerServices;
        }

        [HttpGet]
        public async Task<List<GetTeamResultDto>> GetAll()
        {
            return await _teamServices.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<GetTeamResultDto> Get([FromRoute] int id)
        {
            return await _teamServices.Get(id);
        }
        [HttpPost]
        public async Task Add([FromBody] AddTeamDto dto)
        {
            await _teamServices.Add(dto);
        }
        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            await _teamServices.Delete(id);
        }
        [HttpPatch]
        public async Task Update([FromBody] UpdateTeamDto dto)
        {
            await _teamServices.Update(dto);
        }
        [HttpPatch("{teamId}/addPlayer")]
        public async Task AddPlayer([FromRoute] int teamId, [FromBody] AddPlayerToTeamDto dto)
        {
            await _teamPlayerServices.AddPlayer(teamId, dto);
        }
        [HttpPatch("{teamId}/removePlayer/{playerId}")]
        public async Task RemovePlayer([FromRoute] int teamId, [FromRoute] int playerId)
        {
            await _teamPlayerServices.RemovePlayer(teamId, playerId);
        }
    }
}
