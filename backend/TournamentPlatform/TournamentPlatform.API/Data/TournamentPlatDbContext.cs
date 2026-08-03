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

        public DbSet<MatchEntity> Matches { get; set; }

        public DbSet<TournamentEntity> Tournaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Match has one participant1
            modelBuilder.Entity<MatchEntity>()
                .HasOne(m => m.Participant1)
                .WithMany()
                .HasForeignKey(m => m.Participant1Id)
                .OnDelete(DeleteBehavior.Restrict);

            // Match has one participant2
            modelBuilder.Entity<MatchEntity>()
                .HasOne(m => m.Participant2)
                .WithMany()
                .HasForeignKey(m => m.Participant2Id)
                .OnDelete(DeleteBehavior.Restrict);

            // Match has one winner
            modelBuilder.Entity<MatchEntity>()
                .HasOne(m => m.Winner)
                .WithMany()
                .HasForeignKey(m => m.WinnerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Tournament has many participant and each participant belongs to one tournament
            modelBuilder.Entity<TournamentEntity>()
                .HasMany(t => t.Participants)
                .WithOne(p => p.Tournament)
                .HasForeignKey(p => p.TournamentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Tournament has one winner
            modelBuilder.Entity<TournamentEntity>()
                .HasOne(t => t.Winner)
                .WithMany()
                .HasForeignKey(t => t.WinnerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Tournament has many matches and each match belongs to one tournament
            modelBuilder.Entity<TournamentEntity>()
                .HasMany(t => t.Matches)
                .WithOne(m => m.Tournament)
                .HasForeignKey(m => m.TournamentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
