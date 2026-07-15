
using TournamentPlatform.API.Model.Domain.Interfaces;

namespace TournamentPlatform.API.Model.Domain
{
    public class EloCalculator : IRatingCalculator
    {
        public double CalculateExpectedScore(double rating1, double rating2)
        {
            return 1.0 / (1.0 + Math.Pow(10.0, (rating2 - rating1) / 400.0));
        }

        public void CalculateNewRatings(IParticipant participant1, IParticipant participant2, double outcome)
        {
            double expected1 = CalculateExpectedScore(participant1.Rating, participant2.Rating);
            double expected2 = CalculateExpectedScore(participant2.Rating, participant1.Rating);

            int k = 32; // K-factor

            int newRating1 = participant1.Rating + (int)(k * (outcome - expected1));
            int newRating2 = participant2.Rating + (int)(k * (1 - outcome - expected2));

            participant1.Rating = newRating1;
            participant2.Rating = newRating2;
        }
    }
}
