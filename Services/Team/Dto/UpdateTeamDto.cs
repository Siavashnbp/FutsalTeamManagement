using FutsalTeamManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FustalTeamManagement.Services.Team.Dto
{
    public class UpdateTeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public JerseyColor MainJerseyColor { get; set; }
        public JerseyColor SecondaryJerseyColor { get; set; }
    }
}
