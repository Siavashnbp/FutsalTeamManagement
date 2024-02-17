using FustalTeamManagement.Services.Team;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutsalTeamManagement.Persistence.EF.Team
{
    public class EFTeamRepository : TeamRepository
    {
        private readonly EFDataContext _context;
        public EFTeamRepository(EFDataContext context)
        {
            _context = context;
        }
        public void Add(Entities.Team team)
        {
            var nameExists = _context.Set<Entities.Team>()
                .Any(_ => _.Name.ToLower() == team.Name.ToLower());
            if (nameExists)
            {
                throw new InvalidOperationException("A team with the same name already exists");
            }
            _context.Teams.Add(team);
        }

        public void Delete(int id)
        {
            var team = _context.Set<Entities.Team>().Find(id);
            if (team is null)
            {
                throw new InvalidOperationException("team does not exist");
            }
            _context.Teams.Remove(team);
        }

        public async Task<List<Entities.Team>> GetAllTeams()
        {
            return await _context.Teams.ToListAsync();
        }

        public Task<List<Entities.Player>> GetPlayers(int id)
        {
            return _context.Players.Where(_ => _.TeamId == id).ToListAsync();
        }

        public Entities.Team GetTeam(int id)
        {
            var team = _context.Set<Entities.Team>().Find(id);
            if (team is null)
            {
                throw new InvalidOperationException("Team does not exist");
            }
            return team;
        }

        public void Update(Entities.Team team)
        {
            var teamExists = _context.Set<Entities.Team>().Any(_ => _.Id == team.Id);
            if (!teamExists)
            {
                throw new InvalidOperationException("Team does not exist");
            }
            _context.Teams.Update(team);
        }
    }
}
