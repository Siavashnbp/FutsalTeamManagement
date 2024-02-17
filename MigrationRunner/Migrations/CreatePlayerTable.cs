using FluentMigrator;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutsalTeamManagement.Persistence.EF.Migrations
{
    [FluentMigrator.Migration(20240217173600)]
    public partial class CreatePlayerTable : Microsoft.EntityFrameworkCore.Migrations.Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1,1"),
                    FirstName = table.Column<string>(type: "string", nullable: false),
                    LastName = table.Column<string>(type: "string", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", _ => _.Id);
                });
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Players");
        }

    }
}
