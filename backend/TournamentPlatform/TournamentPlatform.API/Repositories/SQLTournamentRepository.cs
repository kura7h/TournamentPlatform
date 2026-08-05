using AutoMapper;
using TournamentPlatform.API.Data;
using TournamentPlatform.API.Model.Domain;
using TournamentPlatform.API.Model.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace TournamentPlatform.API.Repositories
{
    public class SQLTournamentRepository : ITournamentRepository
    {
        private readonly TournamentPlatDbContext _context;
        private readonly IMapper _mapper;

        public SQLTournamentRepository(TournamentPlatDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Tournament>> GetAllAsync()
        {
            var entities = await _context.Tournaments
                .Include(t => t.Participants)
                .Include(t => t.Winner)
                .Include(t => t.Matches)
                    .ThenInclude(m => m.Participant1)
                .Include(t => t.Matches)
                    .ThenInclude(m => m.Participant2)
                .Include(t => t.Matches)
                    .ThenInclude(m => m.Winner)
                .ToListAsync();

            return _mapper.Map<List<Tournament>>(entities);
        }

        public async Task<Tournament?> GetByIdAsync(Guid id)
        {
            var entity = await _context.Tournaments
                .Include(t => t.Participants)
                .Include(t => t.Winner)
                .Include(t => t.Matches)
                    .ThenInclude(m => m.Participant1)
                .Include(t => t.Matches)
                    .ThenInclude(m => m.Participant2)
                .Include(t => t.Matches)
                    .ThenInclude(m => m.Winner)
                .FirstOrDefaultAsync(t => t.Id == id);

            return _mapper.Map<Tournament?>(entity);
        }

        public async Task<Tournament> CreateAsync(Tournament tournament)
        {
            var entity = _mapper.Map<TournamentEntity>(tournament);

            _context.Tournaments.Add(entity);
            await _context.SaveChangesAsync();

            return tournament;
        }

        public async Task<Tournament?> UpdateAsync(Guid id, Tournament tournament)
        {
            var existingTournamentEntity = await _context.Tournaments.FindAsync(id);

            if (existingTournamentEntity == null)
            {
                return null;
            }

            existingTournamentEntity.Name = tournament.Name;
            existingTournamentEntity.Participants = _mapper.Map<List<ParticipantEntity>>(tournament.Participants);
            existingTournamentEntity.Matches = _mapper.Map<List<MatchEntity>>(tournament.Matches);

            await _context.SaveChangesAsync();

            return _mapper.Map<Tournament?>(existingTournamentEntity);
        }

        public async Task<Tournament?> DeleteAsync(Guid id)
        {
            var entity = await _context.Tournaments.FindAsync(id);

            if (entity == null)
            {
                return null;
            }

            _context.Tournaments.Remove(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<Tournament?>(entity);
        }
    }
}
