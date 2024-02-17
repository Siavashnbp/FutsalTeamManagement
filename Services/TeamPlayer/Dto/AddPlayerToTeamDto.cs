using FutsalTeamManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FustalTeamManagement.Services.TeamPlayer.Dto
{
    public class AddPlayerToTeamDto
    {
        public int PlayerId { get; set; }
        public PlayerPosition PlayerPosition { get; set; }
    }
}
