using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentPlatform.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbContextandentites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_Participants_Tournaments_TournamentEntityId",
                table: "Participants");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Participants_WinnerId",
                table: "Tournaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participants",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Participants");

            migrationBuilder.RenameTable(
                name: "Participants",
                newName: "ParticipantEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Participants_TournamentEntityId",
                table: "ParticipantEntity",
                newName: "IX_ParticipantEntity_TournamentEntityId");

            migrationBuilder.AddColumn<Guid>(
                name: "TournamentId",
                table: "Matches",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TournamentId",
                table: "ParticipantEntity",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParticipantEntity",
                table: "ParticipantEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_ParticipantEntity_Participant1Id",
                table: "Matches",
                column: "Participant1Id",
                principalTable: "ParticipantEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_ParticipantEntity_Participant2Id",
                table: "Matches",
                column: "Participant2Id",
                principalTable: "ParticipantEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_ParticipantEntity_WinnerId",
                table: "Matches",
                column: "WinnerId",
                principalTable: "ParticipantEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantEntity_Tournaments_TournamentEntityId",
                table: "ParticipantEntity",
                column: "TournamentEntityId",
                principalTable: "Tournaments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_ParticipantEntity_WinnerId",
                table: "Tournaments",
                column: "WinnerId",
                principalTable: "ParticipantEntity",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_ParticipantEntity_Participant1Id",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_ParticipantEntity_Participant2Id",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_ParticipantEntity_WinnerId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantEntity_Tournaments_TournamentEntityId",
                table: "ParticipantEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_ParticipantEntity_WinnerId",
                table: "Tournaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParticipantEntity",
                table: "ParticipantEntity");

            migrationBuilder.DropColumn(
                name: "TournamentId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "TournamentId",
                table: "ParticipantEntity");

            migrationBuilder.RenameTable(
                name: "ParticipantEntity",
                newName: "Participants");

            migrationBuilder.RenameIndex(
                name: "IX_ParticipantEntity_TournamentEntityId",
                table: "Participants",
                newName: "IX_Participants_TournamentEntityId");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Participants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participants",
                table: "Participants",
                column: "Id");

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
                name: "FK_Participants_Tournaments_TournamentEntityId",
                table: "Participants",
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
    }
}
