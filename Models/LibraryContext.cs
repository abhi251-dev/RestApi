using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace libraryrestapi.Models
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookAuthor> BookAuthors { get; set; }
        public virtual DbSet<BookCopy> BookCopies { get; set; }
        public virtual DbSet<BookLending> BookLendings { get; set; }
        public virtual DbSet<Card1> Card1s { get; set; }
        public virtual DbSet<LibraryBranch> LibraryBranches { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<VBook> VBooks { get; set; }
        public virtual DbSet<VPublication> VPublications { get; set; }
        public object Book { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=Abhinav;Database=Library;Trusted_connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book");

                entity.Property(e => e.BookId)
                    .ValueGeneratedNever()
                    .HasColumnName("book_id");

                entity.Property(e => e.PubYear).HasColumnName("pub_year");

                entity.Property(e => e.PublisherName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("publisher_name");

                entity.Property(e => e.Title)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.HasOne(d => d.PublisherNameNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.PublisherName)
                    .HasConstraintName("FK__book__publisher___29572725");
            });

            modelBuilder.Entity<BookAuthor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("book_authors");

                entity.Property(e => e.AuthorName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("author_name");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.HasOne(d => d.Book)
                    .WithMany()
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__book_auth__book___2B3F6F97");
            });

            modelBuilder.Entity<BookCopy>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("book_copies");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.BranchId).HasColumnName("branch_id");

                entity.Property(e => e.NoofCopies).HasColumnName("noof_copies");

                entity.HasOne(d => d.Book)
                    .WithMany()
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__book_copi__book___31EC6D26");

                entity.HasOne(d => d.Branch)
                    .WithMany()
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK__book_copi__branc__32E0915F");
            });

            modelBuilder.Entity<BookLending>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("book_lending");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.BranchId).HasColumnName("branch_id");

                entity.Property(e => e.CardNo).HasColumnName("card_no");

                entity.Property(e => e.DateOut)
                    .HasColumnType("date")
                    .HasColumnName("date_out");

                entity.Property(e => e.DueDate)
                    .HasColumnType("date")
                    .HasColumnName("due_date");

                entity.HasOne(d => d.Book)
                    .WithMany()
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__book_lend__book___36B12243");

                entity.HasOne(d => d.Branch)
                    .WithMany()
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK__book_lend__branc__37A5467C");

                entity.HasOne(d => d.CardNoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CardNo)
                    .HasConstraintName("FK__book_lend__card___38996AB5");
            });

            modelBuilder.Entity<Card1>(entity =>
            {
                entity.HasKey(e => e.CardNo)
                    .HasName("PK__card1__BDF5DAFDC741C6C5");

                entity.ToTable("card1");

                entity.Property(e => e.CardNo)
                    .ValueGeneratedNever()
                    .HasColumnName("card_no");
            });

            modelBuilder.Entity<LibraryBranch>(entity =>
            {
                entity.HasKey(e => e.BranchId)
                    .HasName("PK__library___E55E37DE9BE6BF16");

                entity.ToTable("library_branch");

                entity.Property(e => e.BranchId)
                    .ValueGeneratedNever()
                    .HasColumnName("branch_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("branch_name");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__publishe__72E12F1A46C6EB5D");

                entity.ToTable("publisher");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Address)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<VBook>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_BOOKS");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.Sum).HasColumnName("sum");

                entity.Property(e => e.Title)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<VPublication>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_PUBLICATION");

                entity.Property(e => e.PubYear).HasColumnName("PUB_YEAR");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
