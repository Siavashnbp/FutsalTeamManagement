using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutsalTeamManagement;
using FutsalTeamManagement.Entities;

namespace FustalTeamManagement.Services.Player
{
    public interface PlayerRepository
    {
        void Add(FutsalTeamManagement.Entities.Player player);
        void Delete(int id);
        void Update(FutsalTeamManagement.Entities.Player player);
        FutsalTeamManagement.Entities.Player GetPlayer(int id);
        Task<List<FutsalTeamManagement.Entities.Player>> GetAllPlayers();
        Task<List<FutsalTeamManagement.Entities.Player>> FindPlayers
            (string? name, int? minAge, int? maxAge);
    }
}
