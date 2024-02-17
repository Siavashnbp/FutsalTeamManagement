using FustalTeamManagement.Services.Player;
using FutsalTeamManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FutsalTeamManagement.Persistence.EF.Player
{
    public class EFPlayerRepository : PlayerRepository
    {
        private readonly EFDataContext _context;
        public EFPlayerRepository(EFDataContext context)
        {
            _context = context;
        }

        public void Add(Entities.Player player)
        {
            var playerExists = _context.Set<Entities.Player>().Any(_ =>
            _.FirstName == player.FirstName && _.LastName == player.LastName);
            if (playerExists)
            {
                throw new InvalidOperationException("This player already exists");
            }
            _context.Set<Entities.Player>().Add(player);
        }

        public void Delete(int id)
        {
            var player = _context.Set<Entities.Player>().Find(id);
            if (player is null)
            {
                throw new InvalidOperationException("This player does not exists");
            }
            _context.Set<Entities.Player>().Remove(player);
        }

        public async Task<List<Entities.Player>> FindPlayers(string? name, int? minAge, int? maxAge)
        {
            var players = await GetAllPlayers();
            if (name is not null)
            {
                players = players.Where
                    (_ => _.FirstName.ToLower().Contains(name.ToLower())
                    || _.LastName.ToLower().Contains(name.ToLower())).ToList();
            }
            if (minAge is not null)
            {
                players = players.Where
                    (_ => (DateTime.Now - _.BirthDate).TotalDays > minAge.Value * 365).ToList();
            }
            if (maxAge is not null)
            {
                players = players.Where
                    (_ => (DateTime.Now - _.BirthDate).TotalDays < maxAge.Value * 365).ToList();
            }
            return players;
        }

        public async Task<List<Entities.Player>> GetAllPlayers()
        {
            return await _context.Set<Entities.Player>().ToListAsync();
        }

        public Entities.Player GetPlayer(int id)
        {
            var player = _context.Set<Entities.Player>().Find(id);
            if (player is null)
            {
                throw new InvalidOperationException("This player does not exists");
            }
            return player;
        }

        public void Update(Entities.Player player)
        {
            var playerExists = _context.Set<Entities.Player>().Any(_ => _.Id == player.Id);
            if (!playerExists)
            {
                throw new InvalidOperationException("This player does not exists");
            }
            _context.Update(player);
        }
    }
}
