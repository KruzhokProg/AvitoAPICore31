using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AvitoAPICore31
{
    public partial class AvitoContext : DbContext
    {
        public AvitoContext()
        {
        
        }

        public AvitoContext(DbContextOptions<AvitoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ad> Ad { get; set; }
        public virtual DbSet<AdPhotos> AdPhotos { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Condition> Condition { get; set; }
        public virtual DbSet<CreditCard> CreditCard { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<WatchHistory> WatchHistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source = SQL5052.site4now.net; Initial Catalog = DB_A5E27C_ms2020; User Id = DB_A5E27C_ms2020_admin; Password =wsrwsr2020");

                //"Data Source=S-2120-082;Initial Catalog=Avito;Integrated Security=True"
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ad>(entity =>
            {
                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.Communication)
                    .IsRequired()
                    .HasColumnName("communication")
                    .HasMaxLength(50);

                entity.Property(e => e.ConditionId).HasColumnName("conditionId");

                entity.Property(e => e.DateOfPublication)
                    .HasColumnName("dateOfPublication")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(500);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.TypeId).HasColumnName("typeId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Ad)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ad_Category");

                entity.HasOne(d => d.Condition)
                    .WithMany(p => p.Ad)
                    .HasForeignKey(d => d.ConditionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ad_Condition");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Ad)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ad_Type");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ad)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ad_User");
            });

            modelBuilder.Entity<AdPhotos>(entity =>
            {
                entity.ToTable("adPhotos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdId).HasColumnName("adId");

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasMaxLength(200);

                entity.HasOne(d => d.Ad)
                    .WithMany(p => p.AdPhotos)
                    .HasForeignKey(d => d.AdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_adPhotos_Ad");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdId).HasColumnName("adId");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(100);

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.UserIdReceiver).HasColumnName("userIdReceiver");

                entity.Property(e => e.UserIdSender).HasColumnName("userIdSender");

                entity.HasOne(d => d.Ad)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.AdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_Ad");

                entity.HasOne(d => d.UserIdReceiverNavigation)
                    .WithMany(p => p.CommentUserIdReceiverNavigation)
                    .HasForeignKey(d => d.UserIdReceiver)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_User");

                entity.HasOne(d => d.UserIdSenderNavigation)
                    .WithMany(p => p.CommentUserIdSenderNavigation)
                    .HasForeignKey(d => d.UserIdSender)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_User1");
            });

            modelBuilder.Entity<Condition>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CreditCard>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Balance).HasColumnName("balance");

                entity.Property(e => e.BankLogo)
                    .IsRequired()
                    .HasColumnName("bankLogo")
                    .HasMaxLength(100);

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasColumnName("bankName")
                    .HasMaxLength(100);

                entity.Property(e => e.CardNumber)
                    .HasColumnName("cardNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CreditCard)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreditCard_User");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Adress)
                    .HasColumnName("adress")
                    .HasMaxLength(500);

                entity.Property(e => e.Balance).HasColumnName("balance");

                entity.Property(e => e.CompanyName)
                    .HasColumnName("companyName")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50);

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasMaxLength(500);

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

            modelBuilder.Entity<WatchHistory>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.AdId });

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.AdId).HasColumnName("adId");

                entity.Property(e => e.Liked).HasColumnName("liked");

                entity.Property(e => e.Seen).HasColumnName("seen");

                entity.HasOne(d => d.Ad)
                    .WithMany(p => p.WatchHistory)
                    .HasForeignKey(d => d.AdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WatchHistory_Ad");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WatchHistory)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WatchHistory_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
