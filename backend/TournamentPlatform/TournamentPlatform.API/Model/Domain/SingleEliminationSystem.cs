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
                int qualificationParticipants = (participants.Count - NextPowerOfTwo(participants.Count) / 2) * 2;

                for(int i = 0; i < qualificationParticipants; i += 2)
                {
                    Match match = new Match(participants[i], participants[i + 1], 0, i / 2 + 1);
                    matches.Add(match);
                }

                participants.RemoveRange(0, qualificationParticipants);
                participants.InsertRange(0, matches.Select(m => m.Winner).ToList());
            }

            for(int i = 0; i < participants.Count; i += 2)
            {
                Match match = new Match(participants[i], participants[i + 1], 1, i / 2 + 1);
                matches.Add(match);
            }

            int currentRoundMatchesCount = participants.Count / 2;

            for (int i = 1; i < roundsCount; i++)
            {
                for (int j = 0; j < currentRoundMatchesCount; j += 2)
                {
                    Match match = new Match(null, null, i + 1, j / 2 + 1);
                    matches.Add(match);
                }

                currentRoundMatchesCount /= 2;
            }

            return matches;
        }

        public int NextPowerOfTwo(int number)
        {
            if (number < 1)
            {
                throw new ArgumentException("Number must be greater than 0.");
            }

            int power = 1;

            while (power <= number)
            {
                power *= 2;
            }

            return power;
        }
    }
}
