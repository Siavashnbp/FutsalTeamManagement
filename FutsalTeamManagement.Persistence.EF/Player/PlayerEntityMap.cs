using FutsalTeamManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutsalTeamManagement.Persistence.EF.Player
{
    public class PlayerEntityMap : IEntityTypeConfiguration<Entities.Player>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder
            <Entities.Player> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
            builder.Property(_ => _.FirstName).IsRequired();
            builder.Property(_ => _.LastName).IsRequired();
            builder.Property(_ => _.BirthDate).IsRequired();
            builder.HasOne(_ => _.Team).WithMany(_ => _.Players)
                .HasForeignKey(_ => _.TeamId);
        }
    }
}
