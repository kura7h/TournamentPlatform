using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentPlatform.API.Migrations
{
    /// <inheritdoc />
    public partial class EntitiesDbMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Participant_Participant1Id",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Participant_Participant2Id",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Participant_WinnerId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Tournaments_TournamentId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Participant_WinnerId",
                table: "Tournaments");

            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.RenameColumn(
                name: "TournamentId",
                table: "Matches",
                newName: "TournamentEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_TournamentId",
                table: "Matches",
                newName: "IX_Matches_TournamentEntityId");

            migrationBuilder.AlterColumn<Guid>(
                name: "WinnerId",
                table: "Tournaments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false),
                    Losses = table.Column<int>(type: "int", nullable: false),
                    Ties = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TournamentEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participants_Tournaments_TournamentEntityId",
                        column: x => x.TournamentEntityId,
                        principalTable: "Tournaments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participants_TournamentEntityId",
                table: "Participants",
                column: "TournamentEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Participants_Participant1Id",
                table: "Matches",
                column: "Participant1Id",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Participants_Participant2Id",
                table: "Matches",
                column: "Participant2Id",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Participants_WinnerId",
                table: "Matches",
                column: "WinnerId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Tournaments_TournamentEntityId",
                table: "Matches",
                column: "TournamentEntityId",
                principalTable: "Tournaments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Participants_WinnerId",
                table: "Tournaments",
                column: "WinnerId",
                principalTable: "Participants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Participants_Participant1Id",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Participants_Participant2Id",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Participants_WinnerId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Tournaments_TournamentEntityId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Participants_WinnerId",
                table: "Tournaments");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.RenameColumn(
                name: "TournamentEntityId",
                table: "Matches",
                newName: "TournamentId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_TournamentEntityId",
                table: "Matches",
                newName: "IX_Matches_TournamentId");

            migrationBuilder.AlterColumn<Guid>(
                name: "WinnerId",
                table: "Tournaments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Losses = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Ties = table.Column<int>(type: "int", nullable: false),
                    TournamentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Wins = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participant_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participant_TournamentId",
                table: "Participant",
                column: "TournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Participant_Participant1Id",
                table: "Matches",
                column: "Participant1Id",
                principalTable: "Participant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Participant_Participant2Id",
                table: "Matches",
                column: "Participant2Id",
                principalTable: "Participant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Participant_WinnerId",
                table: "Matches",
                column: "WinnerId",
                principalTable: "Participant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Tournaments_TournamentId",
                table: "Matches",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Participant_WinnerId",
                table: "Tournaments",
                column: "WinnerId",
                principalTable: "Participant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
