using TournamentPlatform.API.Model.Domain;
using TournamentPlatform.API.Model.Persistence.Entities;

namespace TournamentPlatform.API.Repositories
{
    public interface IParticipantRepository
    {
        Task<List<Participant>> GetAllAsync();

        Task<Participant?> GetByIdAsync(Guid id);

        Task<Participant> CreateAsync(Participant participant);

        Task<Participant?> UpdateAsync(Guid id, Participant participant);

        Task<Participant?> DeleteAsync(Guid id);
    }
}
