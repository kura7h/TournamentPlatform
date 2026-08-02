namespace TournamentPlatform.API.Model.Domain.Interfaces
{
    public interface IRatingCalculator
    {
        public void CalculateNewRatings(Participant participant1, Participant participant2, double outcome);

        public double CalculateExpectedScore(double rating1, double rating2);
    }
}
