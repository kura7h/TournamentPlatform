using TournamentPlatform.API.Model.Domain;

namespace TournamentPlatform.API.Model.Persistence.Entities
{
    public class MatchEntity
    {
        public Guid Id { get; set; }

        public Guid Participant1Id { get; set; }

        public Guid Participant2Id { get; set; }

        public Guid? WinnerId { get; set; }


        public Participant Participant1 { get; set; }

        public Participant Participant2 { get; set; }

        public Participant? Winner { get; set; }
    }
}
