using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FustalTeamManagement.Services.Team
{
    public interface TeamRepository
    {
        void Add(FutsalTeamManagement.Entities.Team team);
        void Delete(int id);
        void Update(FutsalTeamManagement.Entities.Team team);
        FutsalTeamManagement.Entities.Team GetTeam(int id);
        Task<List<FutsalTeamManagement.Entities.Team>> GetAllTeams();
        Task<List<FutsalTeamManagement.Entities.Player>> GetPlayers(int id);
    }
}
