using TournamentPlatform.API.Model.Domain;
using TournamentPlatform.API.Model.Persistence.Entities;

namespace TournamentPlatform.API.Repositories
{
    public interface IMatchRepository
    {
        Task<List<Match>> GetAllAsync();

        Task<Match?> GetByIdAsync(Guid id);

        Task<Match> CreateAsync(Match match);

        Task<Match?> UpdateAsync(Guid id, Match match);

        Task<Match?> DeleteAsync(Guid id);
    }
}
