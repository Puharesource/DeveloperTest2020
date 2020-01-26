using Microsoft.EntityFrameworkCore;

namespace DeveloperTest2020.Models
{
    public partial class WordContext : DbContext
    {
        public WordContext()
        {
        }

        public WordContext(DbContextOptions<WordContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SeenWord> SeenWords { get; set; }
        public virtual DbSet<WordWatchlist> WordWatchlists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SeenWord>(entity =>
            {
                entity.HasIndex(e => e.Word)
                    .HasName("IX_Words")
                    .IsUnique();

                entity.Property(e => e.Word)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<WordWatchlist>(entity =>
            {
                entity.ToTable("WordWatchlist");

                entity.HasIndex(e => e.Word)
                    .HasName("IX_WordWatchlist")
                    .IsUnique();

                entity.Property(e => e.Word)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
