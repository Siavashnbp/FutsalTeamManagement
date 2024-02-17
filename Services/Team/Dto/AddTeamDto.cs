using FutsalTeamManagement.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FustalTeamManagement.Services.Team.Dto
{
    public class AddTeamDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public JerseyColor MainJerseyColor { get; set; }
        [Required]
        public JerseyColor SecondaryJerseyColor { get; set; }
    }
}
