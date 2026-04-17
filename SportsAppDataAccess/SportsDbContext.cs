using Microsoft.EntityFrameworkCore;

using MFS.SportsApp.Models;

namespace MFS.SportsApp.DataAccess;

public class SportsDbContext : DbContext
{
    // The constructor accepts options (like the connection string) from Program.cs
    public SportsDbContext(DbContextOptions<SportsDbContext> options)
        : base(options)
    {
    }

    // Table definitions
    public DbSet<Athlete> Athletes => Set<Athlete>();
    public DbSet<Team> Teams => Set<Team>();
    public DbSet<Roster> Rosters => Set<Roster>();
    // Register sport-related entities so they are part of the EF Core model
    public DbSet<Sport> Sports => Set<Sport>();
    public DbSet<SportCategory> SportCategories => Set<SportCategory>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 1. Set the default schema for all tables in this context
        modelBuilder.HasDefaultSchema("sports");

        // 2. Configure Athlete Entity
        modelBuilder.Entity<Athlete>(entity =>
        {
            entity.ToTable("athletes");
            // Map tstzrange to NpgsqlRange<DateTime>
            // entity.Property(a => a.SysPeriod).HasColumnType("tstzrange");
        });

        // 3. Configure Team Entity
        modelBuilder.Entity<Team>(entity =>
        {
            //entity.ToTable("teams");
            //entity.Property(t => t.SysPeriod).HasColumnType("tstzrange");

            // Map the unique constraint: league_id + abbreviation
            entity.HasIndex(t => new { t.LeagueId, t.Abbreviation })
                  .IsUnique()
                  .HasDatabaseName("teams_league_id_abbreviation_key");
        });

        // 4. Configure Roster Entity
        modelBuilder.Entity<Roster>(entity =>
        {
            //entity.ToTable("rosters");
            //entity.Property(r => r.SysPeriod).HasColumnType("tstzrange");

            // Map the unique constraint: athlete_id + team_id + position_id
            entity.HasIndex(r => new { r.AthleteId, r.TeamId, r.PositionId })
                  .IsUnique()
                  .HasDatabaseName("rosters_athlete_id_team_id_position_id_key");

            // Explicitly define foreign key relationships if needed
            entity.HasOne(r => r.Athlete)
                  .WithMany(a => a.Rosters)
                  .HasForeignKey(r => r.AthleteId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(r => r.Team)
                  .WithMany(t => t.Rosters)
                  .HasForeignKey(r => r.TeamId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        base.OnModelCreating(modelBuilder);
    }
}

