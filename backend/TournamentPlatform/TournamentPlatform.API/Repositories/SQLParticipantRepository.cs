using AutoMapper;
using TournamentPlatform.API.Data;
using TournamentPlatform.API.Model.Domain;
using TournamentPlatform.API.Model.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace TournamentPlatform.API.Repositories
{
    public class SQLParticipantRepository : IParticipantRepository
    {
        private readonly TournamentPlatDbContext _context;
        private readonly IMapper _mapper;
        public SQLParticipantRepository(TournamentPlatDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Participant>> GetAllAsync()
        {
            var entities = await _context.Participants.ToListAsync();

            return _mapper.Map<List<Participant>>(entities);
        }

        public async Task<Participant?> GetByIdAsync(Guid id)
        {
            var entity = await _context.Participants.FindAsync(id);

            return _mapper.Map<Participant?>(entity);
        }

        public async Task<Participant> CreateAsync(Participant participant)
        {
            var entity = _mapper.Map<ParticipantEntity>(participant);

            _context.Participants.Add(entity);
            await _context.SaveChangesAsync();

            return participant;
        }

        public async Task<Participant?> UpdateAsync(Guid id, Participant participant)
        {
            var existingParticipantEntity = await _context.Participants.FindAsync(id);

            if (existingParticipantEntity == null)
            {
                return null;
            }

            existingParticipantEntity.Name = participant.Name;
            existingParticipantEntity.Rating = participant.Rating;

            await _context.SaveChangesAsync();

            return _mapper.Map<Participant?>(existingParticipantEntity);
        }
        public async Task<Participant?> DeleteAsync(Guid id)
        {
            var participantEntity = await _context.Participants.FindAsync(id);

            if (participantEntity == null)
            {
                return null;
            }

            _context.Participants.Remove(participantEntity);
            await _context.SaveChangesAsync();

            return _mapper.Map<Participant?>(participantEntity);
        }
    }
}
