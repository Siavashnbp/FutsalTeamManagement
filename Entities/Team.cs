using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutsalTeamManagement.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public JerseyColor MainJerseyColor { get; set; }
        public JerseyColor SecondaryJerseyColor { get; set; }
        public List<Player>? Players { get; set; }
    }
    public enum JerseyColor
    {
        Red,
        White,
        Blue,
        Green
    }
    
}
