using TournamentPlatform.API.Data;
using TournamentPlatform.API.Model.Domain;
using TournamentPlatform.API.Model.Persistence.Entities;

namespace TournamentPlatform.API.Repositories
{
    public class SQLParticipantRepository
    {
        private readonly TournamentPlatDbContext _context;
        public SQLParticipantRepository(TournamentPlatDbContext context)
        {
            _context = context;
        }
        /*public async Task<List<Participant>> GetAllAsync()
        {
            return await _context.Participants.ToListAsync();
        }
        public async Task<Participant?> GetByIdAsync(Guid id)
        {
            return await _context.Participants.FindAsync(id);
        }
        public async Task<Participant> CreateAsync(Participant participant)
        {
            _context.Participants.Add(participant);
            await _context.SaveChangesAsync();
            return participant;
        }
        public async Task<Participant?> UpdateAsync(Guid id, Participant participant)
        {
            var existingParticipant = await _context.Participants.FindAsync(id);
            if (existingParticipant == null)
            {
                return null;
            }
            existingParticipant.Name = participant.Name;
            existingParticipant.Email = participant.Email;
            await _context.SaveChangesAsync();
            return existingParticipant;
        }
        public async Task<Participant?> DeleteAsync(Guid id)
        {
            var participant = await _context.Participants.FindAsync(id);
            if (participant == null)
            {
                return null;
            }
            _context.Participants.Remove(participant);
            await _context.SaveChangesAsync();
            return participant;
        }*/
    }
}
