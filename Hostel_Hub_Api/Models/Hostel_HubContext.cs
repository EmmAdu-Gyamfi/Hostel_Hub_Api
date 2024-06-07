using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Hostel_Hub_Api.Models
{
    public partial class Hostel_HubContext : DbContext
    {
        public Hostel_HubContext()
        {
        }

        public Hostel_HubContext(DbContextOptions<Hostel_HubContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FileStore> FileStores { get; set; }
        public virtual DbSet<Hostel> Hostels { get; set; }
        public virtual DbSet<HostelPhoto> HostelPhotos { get; set; }
        public virtual DbSet<HostelRating> HostelRatings { get; set; }
        public virtual DbSet<HostelReview> HostelReviews { get; set; }
        public virtual DbSet<HostelRoom> HostelRooms { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomPhoto> RoomPhotos { get; set; }

     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<FileStore>(entity =>
            {
                entity.HasKey(e => e.FileId)
                    .IsClustered(false);

                entity.ToTable("FileStore");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.FileData).IsRequired();

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MimeType)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Hostel>(entity =>
            {
                entity.HasKey(e => e.HostelId)
                    .IsClustered(false);

                entity.ToTable("Hostel");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Condition)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Furnishing)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Locality)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.PriceRange)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<HostelPhoto>(entity =>
            {
                entity.HasKey(e => new { e.HostelPhotoId, e.HostelId })
                    .IsClustered(false);

                entity.Property(e => e.HostelPhotoId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.File)
                    .WithMany(p => p.HostelPhotos)
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FileStore_HostelPhotos");

                entity.HasOne(d => d.Hostel)
                    .WithMany(p => p.HostelPhotos)
                    .HasForeignKey(d => d.HostelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hostel_HostelPhotos");
            });

            modelBuilder.Entity<HostelRating>(entity =>
            {
                entity.HasKey(e => new { e.HostelRatingId, e.HostelId })
                    .IsClustered(false);

                entity.ToTable("HostelRating");

                entity.Property(e => e.HostelRatingId).ValueGeneratedOnAdd();

                entity.Property(e => e.RatingValue).HasColumnType("decimal(2, 1)");

                entity.HasOne(d => d.Hostel)
                    .WithMany(p => p.HostelRatings)
                    .HasForeignKey(d => d.HostelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hostel_HostelRating");
            });

            modelBuilder.Entity<HostelReview>(entity =>
            {
                entity.HasKey(e => new { e.HostelReviewId, e.HostelId })
                    .IsClustered(false);

                entity.ToTable("HostelReview");

                entity.Property(e => e.HostelReviewId).ValueGeneratedOnAdd();

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Hostel)
                    .WithMany(p => p.HostelReviews)
                    .HasForeignKey(d => d.HostelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hostel_HostelReview");
            });

            modelBuilder.Entity<HostelRoom>(entity =>
            {
                entity.HasKey(e => e.HostelRoomId)
                    .IsClustered(false);

                entity.HasOne(d => d.Hostel)
                    .WithMany(p => p.HostelRooms)
                    .HasForeignKey(d => d.HostelId)
                    .HasConstraintName("FK_Hostel_HostelRooms");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.HostelRooms)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Room_HostelRooms");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.RoomId)
                    .IsClustered(false);

                entity.ToTable("Room");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.RoomCategory)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RoomLabel)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<RoomPhoto>(entity =>
            {
                entity.HasKey(e => new { e.RoomPhotosId, e.RoomId })
                    .IsClustered(false);

                entity.Property(e => e.RoomPhotosId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.File)
                    .WithMany(p => p.RoomPhotos)
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FileStore_RoomPhotos");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomPhotos)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Room_RoomPhotos");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
