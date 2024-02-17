using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutsalTeamManagement.Persistence.EF.Team
{
    public class TeamEntityMap : IEntityTypeConfiguration<Entities.Team>
    {
        public void Configure(EntityTypeBuilder<Entities.Team> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Name).IsRequired();
            builder.Property(_=>_.MainJerseyColor).IsRequired();
            builder.Property(_ => _.SecondaryJerseyColor).IsRequired();
        }
    }
}
