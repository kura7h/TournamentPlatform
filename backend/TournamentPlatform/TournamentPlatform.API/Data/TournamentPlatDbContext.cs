using Microsoft.EntityFrameworkCore;
using TournamentPlatform.API.Model.Domain;

namespace TournamentPlatform.API.Data
{
    public class TournamentPlatDbContext : DbContext
    {
        public TournamentPlatDbContext(DbContextOptions<TournamentPlatDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Player> Players { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<Tournament> Tournaments { get; set; }
    }
}
