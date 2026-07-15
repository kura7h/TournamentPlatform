namespace TournamentPlatform.API.Model.Domain.Interfaces
{
    public interface IRatingCalculator
    {
        public double CalculateExpectedScore(double rating1, double rating2);
        public void CalculateNewRatings(IParticipant participant1, IParticipant participant2, double outcome);
    }
}
