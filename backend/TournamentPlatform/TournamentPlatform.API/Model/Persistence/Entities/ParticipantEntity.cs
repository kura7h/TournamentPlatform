namespace TournamentPlatform.API.Model.Persistence.Entities
{
    public class ParticipantEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Rating { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public int Ties { get; set; }

        public Guid TournamentId { get; set; }
    }
}
