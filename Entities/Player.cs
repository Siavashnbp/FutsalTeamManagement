using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutsalTeamManagement.Entities
{
    public class Player : Person
    {
        public int Id { get; set; }
        public int? TeamId { get; set; }
        public Team? Team { get; set; }
        public PlayerPosition? PlayerPosition { get; set; }
    }
    public enum PlayerPosition
    {
        GoalKeeper,
        Defence,
        Offence
    }
}
