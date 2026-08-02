using Microsoft.EntityFrameworkCore;
using TournamentPlatform.API.Model.Persistence.Entities;

namespace TournamentPlatform.API.Data
{
    public class TournamentPlatDbContext : DbContext
    {
        public TournamentPlatDbContext(DbContextOptions<TournamentPlatDbContext> options)
            : base(options)
        {

        }

        public DbSet<ParticipantEntity> Participants { get; set; }

        public DbSet<MatchEntity> Matches { get; set; }

        public DbSet<TournamentEntity> Tournaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MatchEntity>()
                .HasOne(m => m.Participant1)
                .WithMany()
                .HasForeignKey(m => m.Participant1Id)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<MatchEntity>()
                .HasOne(m => m.Participant2)
                .WithMany()
                .HasForeignKey(m => m.Participant2Id)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<MatchEntity>()
                .HasOne(m => m.Winner)
                .WithMany()
                .HasForeignKey(m => m.WinnerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
