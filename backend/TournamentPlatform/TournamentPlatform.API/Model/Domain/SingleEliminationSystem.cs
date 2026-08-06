using TournamentPlatform.API.Model.Domain.Interfaces;

namespace TournamentPlatform.API.Model.Domain
{
    public class SingleEliminationSystem : ITournamentSystem
    {
        public List<Match> GenerateMatches(List<Participant> participants)
        {
            List<Match> matches = new List<Match>();

            double roundsCount = Math.Log2(participants.Count);

            bool isPowerOfTwo = (roundsCount % 1) == 0 ? true : false;

            if (!isPowerOfTwo)
            {
                throw new ArgumentException("Number of participants must be a power of two. This will be implemented in a future version.");
            }

            for(int i = 0; i < participants.Count; i += 2)
            {
                Match match = new Match(participants[i], participants[i + 1], 1, i / 2 + 1);
                matches.Add(match);
            }

            for(int i = 1; i < roundsCount; i++)
            {
                for (int j = 0; j < participants.Count; j += 2)
                {
                    Match match = new Match(null, null, i + 1, j / 2 + 1);
                    matches.Add(match);
                }
            }

            return matches;
        }
    }
}
