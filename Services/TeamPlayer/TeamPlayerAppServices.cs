using FustalTeamManagement.Services.Player;
using FustalTeamManagement.Services.Player.Dto;
using FustalTeamManagement.Services.Team;
using FustalTeamManagement.Services.TeamPlayer.Dto;
using FutsalTeamManagement.Contracts;
using FutsalTeamManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FustalTeamManagement.Services.TeamPlayer
{
    public class TeamPlayerAppServices : TeamPlayerServices
    {
        private readonly TeamRepository _teamRepository;
        private readonly PlayerRepository _playerRepository;
        private readonly UnitOfWork _unitOfWork;
        public TeamPlayerAppServices(TeamRepository teamRepository, PlayerRepository playerRepository,
            UnitOfWork unitOfWork)
        {
            _teamRepository = teamRepository;
            _playerRepository = playerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddPlayer(int teamId, AddPlayerToTeamDto dto)
        {
            var team = _teamRepository.GetTeam(teamId);
            if (team is null)
            {
                throw new InvalidOperationException("Team does not exist");
            }
            var player = _playerRepository.GetPlayer(dto.PlayerId);
            if (player is null)
            {
                throw new InvalidOperationException("Player does not exist");
            }
            if (player.TeamId is not null)
            {
                throw new InvalidOperationException("This player is already in a team");
            }
            var teamPlayers = await _teamRepository.GetPlayers(teamId);
            if (teamPlayers.Count >= 5)
            {
                throw new InvalidOperationException("This team already has 5 players");
            }
            if (dto.PlayerPosition == PlayerPosition.GoalKeeper)
            {
                if (teamPlayers.Any(_ => _.PlayerPosition == PlayerPosition.GoalKeeper))
                {
                    throw new InvalidOperationException("This team already has a goalkeeper");
                }
            }
            else
            {
                if (teamPlayers.Count == 4 &&
                    !teamPlayers.Any(_ => _.PlayerPosition == PlayerPosition.GoalKeeper))
                {
                    throw new InvalidOperationException
                        ("This team does not have a goalkeeper. Last player must be a goalkeeper.");
                }
            }
            player.TeamId = teamId;
            _playerRepository.Update(player);
            await _unitOfWork.Complete();
        }

        public async Task RemovePlayer(int teamId, int playerId)
        {
            var team = _teamRepository.GetTeam(teamId);
            if (team is null)
            {
                throw new InvalidOperationException("Team does not exist");
            }
            var player = _playerRepository.GetPlayer(playerId);
            if (player is null)
            {
                throw new InvalidOperationException("Player does not exist");
            }
            if (player.TeamId is null)
            {
                throw new InvalidOperationException("This player is not in a team");
            }
            var teamPlayers = await _teamRepository.GetPlayers(teamId);
            if (!teamPlayers.Contains(player))
            {
                throw new InvalidOperationException("This player is not in this team");
            }
            player.TeamId = null;
            _playerRepository.Update(player);
            await _unitOfWork.Complete();
        }
    }
}
