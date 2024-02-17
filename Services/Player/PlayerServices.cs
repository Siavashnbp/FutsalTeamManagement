using FustalTeamManagement.Services.Player.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FustalTeamManagement.Services.Player
{
    public interface PlayerServices
    {
        Task Add(AddPlayerDto dto);
        Task Delete(int id);
        Task<List<GetPlayerResultDto>> GetAll();
        Task Update(UpdatePlayerDto dto);
        Task<GetPlayerResultDto> Get(int id);
        Task<List<GetPlayerResultDto>> FindPlayers(string? name, int? minAge, int? maxAge);
    }
}
