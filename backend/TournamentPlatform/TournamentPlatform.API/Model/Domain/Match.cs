using TournamentPlatform.API.Model.Domain.Interfaces;

namespace TournamentPlatform.API.Model.Domain
{
    public class Match
    {
        public Guid Id { get; set; }

        public Participant Participant1 { get; set; }

        public Participant Participant2 { get; set; }

        public Participant? Winner { get; set; }

        public void MatchResult(Participant winner)
        {
            throw new NotImplementedException();
        }
    }
}
