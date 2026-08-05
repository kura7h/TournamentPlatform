using TournamentPlatform.API.Model.Domain;
using TournamentPlatform.API.Model.Persistence.Entities;

namespace TournamentPlatform.API.Repositories
{
    public interface ITournamentRepository
    {
        Task<List<Tournament>> GetAllAsync();

        Task<Tournament?> GetByIdAsync(Guid id);

        Task<Tournament> CreateAsync(Tournament tournament);

        Task<Tournament?> UpdateAsync(Guid id, Tournament tournament);

        Task<Tournament?> DeleteAsync(Guid id);
    }
}
