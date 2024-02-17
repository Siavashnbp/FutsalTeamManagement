using FustalTeamManagement.Services.Player.Dto;
using FustalTeamManagement.Services.Team.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FustalTeamManagement.Services.Team
{
    public interface TeamServices
    {
        Task Add(AddTeamDto dto);
        Task Delete(int id);
        Task<List<GetTeamResultDto>> GetAll();
        Task Update(UpdateTeamDto dto);
        Task<GetTeamResultDto> Get(int id);
        Task<List<GetPlayerResultDto>> GetPlayers(int id);
     
    }
}
