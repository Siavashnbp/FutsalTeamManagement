using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutsalTeamManagement.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class addplayerposition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerPosition",
                table: "Players",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayerPosition",
                table: "Players");
        }
    }
}
