using System.ComponentModel.DataAnnotations.Schema;
using TournamentPlatform.API.Model.Domain.Interfaces;

namespace TournamentPlatform.API.Model.Domain
{
    public class Tournament
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Participant> Participants { get; set; }
        public List<Match> Matches { get; set; }

        public ITournamentSystem TournamentSystem { get; set; }

        public Participant Winner { get; set; }

        public void GenerateBracket()
        {
            throw new NotImplementedException();
        }
    }
}
