using FustalTeamManagement.Services.Player.Dto;
using FustalTeamManagement.Services.Team.Dto;
using FutsalTeamManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FustalTeamManagement.Services.Team
{
    public class TeamAppServices : TeamServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly TeamRepository _teamRepository;
        public TeamAppServices(UnitOfWork unitOfWork, TeamRepository teamRepository)
        {
            _unitOfWork = unitOfWork;
            _teamRepository = teamRepository;
        }

        public async Task Delete(int id)
        {
            _teamRepository.Delete(id);
            await _unitOfWork.Complete();
        }

        public async Task<GetTeamResultDto> Get(int id)
        {
            var team = _teamRepository.GetTeam(id);
            var teamDto = new GetTeamResultDto
            {
                Id = team.Id,
                MainJerseyColor = team.MainJerseyColor,
                SecondaryJerseyColor = team.SecondaryJerseyColor,
                Name = team.Name,
            };
            var players = await GetPlayers(team.Id);
            teamDto.Players = players;
            return teamDto;
        }

        public async Task<List<GetTeamResultDto>> GetAll()
        {
            var teams = await _teamRepository.GetAllTeams();
            return teams.Select(_ => new GetTeamResultDto
            {
                Id = _.Id,
                MainJerseyColor = _.MainJerseyColor,
                Name = _.Name,
                SecondaryJerseyColor = _.SecondaryJerseyColor
            }).ToList();
        }

        public async Task<List<GetPlayerResultDto>> GetPlayers(int id)
        {
            var players = await _teamRepository.GetPlayers(id);
            return players.Select(_ => new GetPlayerResultDto
            {
                BirthDate = _.BirthDate,
                FirstName = _.FirstName,
                LastName = _.LastName,
                Id = _.Id,
            }).ToList();
        }

        public async Task Update(UpdateTeamDto dto)
        {
            var team = new FutsalTeamManagement.Entities.Team
            {
                Id = dto.Id,
                Name = dto.Name,
                MainJerseyColor = dto.MainJerseyColor,
                SecondaryJerseyColor = dto.SecondaryJerseyColor
            };
            _teamRepository.Update(team);
            await _unitOfWork.Complete();
        }

        async Task TeamServices.Add(AddTeamDto dto)
        {
            var team = new FutsalTeamManagement.Entities.Team
            {
                Name = dto.Name,
                MainJerseyColor = dto.MainJerseyColor,
                SecondaryJerseyColor = dto.SecondaryJerseyColor
            };
            _teamRepository.Add(team);
            await _unitOfWork.Complete();
        }
    }
}
