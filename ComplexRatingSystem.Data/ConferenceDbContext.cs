using System;
using ComplexRatingSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ComplexRatingSystem.Data
{
    public partial class ConferenceDbContext : DbContext
    {

        public ConferenceDbContext(DbContextOptions<ConferenceDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConferenceRating> ConferenceRatings { get; set; }
        public virtual DbSet<ConferenceXattendeeRating> ConferenceXattendeeRatings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=ConferenceDb;User Id=sa;Password=Fistikiu21!;MultipleActiveResultSets=false");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ConferenceRating>(entity =>
            {
                entity.HasKey(e => e.ExternalId)
                    .HasName("PK_ConferenceRating_1");

                entity.ToTable("ConferenceRating");

                entity.Property(e => e.ExternalId).ValueGeneratedNever();

                entity.Property(e => e.Avgrating)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("AVGRating");
            });

            modelBuilder.Entity<ConferenceXattendeeRating>(entity =>
            {
                entity.HasKey(e => new { e.ExternalId, e.UserId, e.Category })
                    .HasName("PK_ConferenceXAttendeeRating_1");

                entity.ToTable("ConferenceXAttendeeRating");

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.Rating).HasColumnType("decimal(3, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
