using System.Text.RegularExpressions;

namespace TournamentPlatform.API.Model.Domain.Interfaces
{
    public interface ITournamentSystem
    {
        public List<Match> GenerateMatches(List<IParticipant> participants);
    }
}
