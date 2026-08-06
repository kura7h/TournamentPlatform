using TournamentPlatform.API.Model.Domain.Interfaces;

namespace TournamentPlatform.API.Model.Domain
{
    public class Match
    {
        public Guid Id { get; set; }

        public Participant Participant1 { get; set; }

        public Participant Participant2 { get; set; }

        public Participant? Winner { get; set; }

        public int Round { get; set; }

        public int PositionInRound { get; set; }

        public Match(Participant participant1, Participant participant2, int round, int positionInRound)
        {
            Id = Guid.NewGuid();
            Participant1 = participant1;
            Participant2 = participant2;
            Round = round;
            PositionInRound = positionInRound;
        }

        public void MatchResult(Participant winner)
        {
            throw new NotImplementedException();
        }
    }
}
