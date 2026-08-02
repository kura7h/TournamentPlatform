using System.ComponentModel.DataAnnotations.Schema;
using TournamentPlatform.API.Model.Domain;
using TournamentPlatform.API.Model.Domain.Interfaces;

namespace TournamentPlatform.API.Model.Persistence.Entities
{
    public enum TournamentType
    {
        SingleElimination,
        DoubleElimination
    }

    public class TournamentEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TournamentType Type { get; set; }

        public List<Participant> Participants { get; set; }
        public List<Match> Matches { get; set; }

        public Guid? WinnerId { get; set; }
        public Participant Winner { get; set; }
    }
}
