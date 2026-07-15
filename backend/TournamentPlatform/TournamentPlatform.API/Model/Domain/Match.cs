using TournamentPlatform.API.Model.Domain.Interfaces;

namespace TournamentPlatform.API.Model.Domain
{
    public class Match
    {
        public Guid Id { get; set; }

        public IParticipant Participant1 { get; set; }

        public IParticipant Participant2 { get; set; }

        public IParticipant Winner { get; set; }

        public void MatchResult(IParticipant winner)
        {
            throw new NotImplementedException();
        }
    }
}
