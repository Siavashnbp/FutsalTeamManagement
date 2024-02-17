using FustalTeamManagement.Services.Player.Dto;
using FutsalTeamManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FustalTeamManagement.Services.Player
{
    public class PlayerAppServices : PlayerServices
    {
        private readonly PlayerRepository _playerRepository;
        private readonly UnitOfWork _unitOfWork;
        public PlayerAppServices(PlayerRepository playerRepository,
            UnitOfWork unitOfWork)
        {
            _playerRepository = playerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(AddPlayerDto dto)
        {
            var player = new FutsalTeamManagement.Entities.Player
            {
                BirthDate = dto.BirthDate,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
            };
            _playerRepository.Add(player);
            await _unitOfWork.Complete();
        }

        public async Task Delete(int id)
        {
            _playerRepository.Delete(id);
            await _unitOfWork.Complete();
        }

        public async Task<List<GetPlayerResultDto>> FindPlayers(string? name, int? minAge, int? maxAge)
        {
            var players = await _playerRepository.FindPlayers(name, minAge, maxAge);
            return players.Select(_ => new GetPlayerResultDto
            {
                BirthDate = _.BirthDate,
                FirstName = _.FirstName,
                LastName = _.LastName,
                Id = _.Id,
            }).ToList();
        }

        public async Task<GetPlayerResultDto> Get(int id)
        {
            var player = _playerRepository.GetPlayer(id);
            return new GetPlayerResultDto
            {
                FirstName = player.FirstName,
                LastName = player.LastName,
                BirthDate = player.BirthDate,
                Id = player.Id
            };
        }

        public async Task<List<GetPlayerResultDto>> GetAll()
        {
            var players = await _playerRepository.GetAllPlayers();
            return players.Select(_ => new GetPlayerResultDto
            {
                BirthDate = _.BirthDate,
                FirstName = _.FirstName,
                LastName = _.LastName,
                Id = _.Id
            }).ToList();
        }

        public async Task Update(UpdatePlayerDto dto)
        {
            var player = new FutsalTeamManagement.Entities.Player
            {
                Id = dto.Id,
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                BirthDate = dto.BirthDate,
            };
            _playerRepository.Update(player);
            await _unitOfWork.Complete();
        }
    }
}
