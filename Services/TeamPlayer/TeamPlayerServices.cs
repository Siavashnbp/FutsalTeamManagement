using FustalTeamManagement.Services.Player.Dto;
using FustalTeamManagement.Services.TeamPlayer.Dto;
using FutsalTeamManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FustalTeamManagement.Services.TeamPlayer
{
    public interface TeamPlayerServices
    {
        Task AddPlayer(int teamId, AddPlayerToTeamDto addPlayerDto);
        Task RemovePlayer(int teamId, int playerId);
    }
}
