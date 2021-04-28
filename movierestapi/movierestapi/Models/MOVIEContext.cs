using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace movierestapi.Models
{
    public partial class MOVIEContext : DbContext
    {
        public MOVIEContext()
        {
        }

        public MOVIEContext(DbContextOptions<MOVIEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Employee1> Employee1s { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieCast> MovieCasts { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=Abhinav;Database=MOVIE;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasKey(e => e.ActId)
                    .HasName("PK__ACTOR__CDFB302A658D335C");

                entity.ToTable("ACTOR");

                entity.Property(e => e.ActId)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("ACT_ID");

                entity.Property(e => e.ActGender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACT_GENDER")
                    .IsFixedLength(true);

                entity.Property(e => e.ActName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ACT_NAME");
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.HasKey(e => e.DirId)
                    .HasName("PK__DIRECTOR__B28024E2758AD36A");

                entity.ToTable("DIRECTOR");

                entity.Property(e => e.DirId)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("DIR_ID");

                entity.Property(e => e.DirName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DIR_NAME");

                entity.Property(e => e.DirPhone)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("DIR_PHONE");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Employeid)
                    .HasName("PK__EMPLOYEE__C8A00C9D0FC7392B");

                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.Employeid).HasColumnName("EMPLOYEID");

                entity.Property(e => e.Managerid).HasColumnName("managerid");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Employee1>(entity =>
            {
                entity.HasKey(e => e.Employeid)
                    .HasName("PK__EMPLOYEE__C8A00C9D95F4F491");

                entity.ToTable("EMPLOYEE1");

                entity.Property(e => e.Employeid).HasColumnName("EMPLOYEID");

                entity.Property(e => e.Managerid).HasColumnName("managerid");

                entity.Property(e => e.Name1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name1");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.MovId)
                    .HasName("PK__MOVIES__7407EC4B48D0F32C");

                entity.ToTable("MOVIES");

                entity.Property(e => e.MovId)
                    .HasColumnType("numeric(4, 0)")
                    .HasColumnName("MOV_ID");

                entity.Property(e => e.DirId)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("DIR_ID");

                entity.Property(e => e.MovLang)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("MOV_LANG");

                entity.Property(e => e.MovTitle)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("MOV_TITLE");

                entity.Property(e => e.MovYear)
                    .HasColumnType("numeric(4, 0)")
                    .HasColumnName("MOV_YEAR");

                entity.HasOne(d => d.Dir)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.DirId)
                    .HasConstraintName("FK__MOVIES__DIR_ID__286302EC");
            });

            modelBuilder.Entity<MovieCast>(entity =>
            {
                entity.HasKey(e => new { e.ActId, e.MovId })
                    .HasName("PK__MOVIE_CA__6ABB4EEE7E9E7FE8");

                entity.ToTable("MOVIE_CAST");

                entity.Property(e => e.ActId)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("ACT_ID");

                entity.Property(e => e.MovId)
                    .HasColumnType("numeric(4, 0)")
                    .HasColumnName("MOV_ID");

                entity.Property(e => e.Role)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ROLE");

                entity.HasOne(d => d.Act)
                    .WithMany(p => p.MovieCasts)
                    .HasForeignKey(d => d.ActId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MOVIE_CAS__ACT_I__2B3F6F97");

                entity.HasOne(d => d.Mov)
                    .WithMany(p => p.MovieCasts)
                    .HasForeignKey(d => d.MovId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MOVIE_CAS__MOV_I__2C3393D0");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasKey(e => e.MovId)
                    .HasName("PK__RATING__7407EC4B2B5A254F");

                entity.ToTable("RATING");

                entity.Property(e => e.MovId)
                    .HasColumnType("numeric(4, 0)")
                    .HasColumnName("MOV_ID");

                entity.Property(e => e.RevStars)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("REV_STARS");

                entity.HasOne(d => d.Mov)
                    .WithOne(p => p.Rating)
                    .HasForeignKey<Rating>(d => d.MovId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RATING__MOV_ID__2F10007B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
