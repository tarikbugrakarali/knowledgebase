using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace knowledgeBase.Models
{
    public partial class knowledgeBaseContext : DbContext
    {
        public knowledgeBaseContext()
        {
        }

        public knowledgeBaseContext(DbContextOptions<knowledgeBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Faq> Faqs { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Text> Texts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-N14KV3H;Database=knowledgeBase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Article>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.FileName).HasMaxLength(50);

                entity.Property(e => e.FilePath).HasMaxLength(50);

                entity.Property(e => e.Tag).HasMaxLength(50);
            });

            modelBuilder.Entity<Faq>(entity =>
            {
                entity.ToTable("FAQ");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Answer).HasMaxLength(1000);

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.Question).HasMaxLength(50);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("login");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Text>(entity =>
            {
                entity.ToTable("Text");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Article).HasMaxLength(1000);

                entity.Property(e => e.Date).HasMaxLength(50);

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.Header).HasMaxLength(50);

                entity.Property(e => e.Tag).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
