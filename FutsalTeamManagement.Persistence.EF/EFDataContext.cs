using FutsalTeamManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutsalTeamManagement.Persistence.EF
{
    public class EFDataContext : DbContext
    {
        public DbSet<Entities.Player> Players { get; set; }
        public DbSet<Entities.Team> Teams { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=FutsalManagementDB" +
                ";Integrated Security=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFDataContext).Assembly);
        }
    }
}
