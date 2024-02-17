using FustalTeamManagement.Services.Player.Dto;
using FutsalTeamManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FustalTeamManagement.Services.Team.Dto
{
    public class GetTeamResultDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GetPlayerResultDto> Players { get; set; }
        public JerseyColor MainJerseyColor { get; set; }
        public JerseyColor SecondaryJerseyColor { get; set; }
    }
}
