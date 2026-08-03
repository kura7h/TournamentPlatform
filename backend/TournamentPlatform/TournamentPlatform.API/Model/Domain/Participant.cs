using TournamentPlatform.API.Model.Domain.Interfaces;

namespace TournamentPlatform.API.Model.Domain
{
    public class Participant : IParticipant
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Rating { get; set; }
    }
}
