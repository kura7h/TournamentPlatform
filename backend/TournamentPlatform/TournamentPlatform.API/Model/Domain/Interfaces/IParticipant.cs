namespace TournamentPlatform.API.Model.Domain.Interfaces
{
    public interface IParticipant
    {
        public string Name { get; set; }

        public int Rating { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public int Ties { get; set; }
    }
}
