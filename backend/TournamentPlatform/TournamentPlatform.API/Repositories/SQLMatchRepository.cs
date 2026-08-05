using AutoMapper;
using TournamentPlatform.API.Data;
using TournamentPlatform.API.Model.Domain;
using TournamentPlatform.API.Model.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace TournamentPlatform.API.Repositories
{
    public class SQLMatchRepository : IMatchRepository
    {
        private readonly TournamentPlatDbContext _context;
        private readonly IMapper _mapper;

        public SQLMatchRepository(TournamentPlatDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Match>> GetAllAsync()
        {
            var entities = await _context.Matches
                .Include(m => m.Participant1)
                .Include(m => m.Participant2)
                .Include(m => m.Winner)
                .ToListAsync();

            return _mapper.Map<List<Match>>(entities);
        }

        public async Task<Match?> GetByIdAsync(Guid id)
        {
            var entity = await _context.Matches
                .Include(m => m.Participant1)
                .Include(m => m.Participant2)
                .Include(m => m.Winner)
                .FirstOrDefaultAsync(m => m.Id == id);

            return entity == null ? null : _mapper.Map<Match>(entity);
        }

        public async Task<Match> CreateAsync(Match match)
        {
            var entity = _mapper.Map<MatchEntity>(match);

            _context.Matches.Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<Match>(entity);
        }

        public async Task<Match?> UpdateAsync(Guid id, Match match)
        {
            var existingMatchEntity = await _context.Matches
                .Include(m => m.Participant1)
                .Include(m => m.Participant2)
                .Include(m => m.Winner)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (existingMatchEntity == null)
            {
                return null;
            }

            _mapper.Map(match, existingMatchEntity);
            await _context.SaveChangesAsync();

            return _mapper.Map<Match>(existingMatchEntity);
        }

        public async Task<Match?> DeleteAsync(Guid id)
        {
            var entity = await _context.Matches.FindAsync(id);

            if (entity == null)
            {
                return null;
            }

            _context.Matches.Remove(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<Match>(entity);
        }
    }
}
