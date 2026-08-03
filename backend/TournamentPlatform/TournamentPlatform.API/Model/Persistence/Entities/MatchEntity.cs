using TournamentPlatform.API.Model.Domain;

namespace TournamentPlatform.API.Model.Persistence.Entities
{
    public class MatchEntity
    {
        public Guid Id { get; set; }

        public Guid Participant1Id { get; set; }

        public Guid Participant2Id { get; set; }

        public Guid? WinnerId { get; set; }

        public Guid TournamentId { get; set; }


        public ParticipantEntity Participant1 { get; set; }

        public ParticipantEntity Participant2 { get; set; }

        public ParticipantEntity? Winner { get; set; }

        public TournamentEntity Tournament { get; set; }
    }
}
