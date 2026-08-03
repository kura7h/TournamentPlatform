using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentPlatform.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateParticipantEntityMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ties",
                table: "ParticipantEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ties",
                table: "ParticipantEntity");
        }
    }
}
