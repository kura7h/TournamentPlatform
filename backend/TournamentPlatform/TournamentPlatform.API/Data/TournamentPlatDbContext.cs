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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure the relationships and constraints here if needed
            modelBuilder.Entity<Match>()
                .HasOne(m => m.Participant1)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Match>()
                .HasOne(m => m.Participant2)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Match>()
                .HasOne(m => m.Winner)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
