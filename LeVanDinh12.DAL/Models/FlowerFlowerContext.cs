using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LeVanDinh12.DAL.Models
{
    public partial class FlowerFlowerContext : DbContext
    {
        public FlowerFlowerContext()
        {
        }

        public FlowerFlowerContext(DbContextOptions<FlowerFlowerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anonymouse> Anonymouses { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryFlower> CategoryFlowers { get; set; }
        public virtual DbSet<CategoryPost> CategoryPosts { get; set; }
        public virtual DbSet<Flower> Flowers { get; set; }
        public virtual DbSet<FlowerComment> FlowerComments { get; set; }
        public virtual DbSet<FlowerOrder> FlowerOrders { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostComment> PostComments { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=MINHTRIEU\\SQLEXPRESS01;Initial Catalog=FlowerFlower;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Anonymouse>(entity =>
            {
                entity.HasIndex(e => e.Phone, "anonymouses_phone_unique")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<CategoryFlower>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.FlowerId })
                    .HasName("categoryflower_categoryid_flowerid_primary");

                entity.ToTable("CategoryFlower");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.FlowerId).HasColumnName("FlowerID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategoryFlowers)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("categoryflower_categoryid_foreign");

                entity.HasOne(d => d.Flower)
                    .WithMany(p => p.CategoryFlowers)
                    .HasForeignKey(d => d.FlowerId)
                    .HasConstraintName("categoryflower_flowerid_foreign");
            });

            modelBuilder.Entity<CategoryPost>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.PostId })
                    .HasName("categorypost_categoryid_postid_primary");

                entity.ToTable("CategoryPost");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategoryPosts)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("categorypost_categoryid_foreign");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.CategoryPosts)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("categorypost_postid_foreign");
            });

            modelBuilder.Entity<Flower>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Body).IsRequired();

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.MainImageUrl)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("MainImageURL");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Quantity).HasDefaultValueSql("('1')");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Flowers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("flowers_userid_foreign");
            });

            modelBuilder.Entity<FlowerComment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AnonymousId).HasColumnName("AnonymousID");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.FlowerId).HasColumnName("FlowerID");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Anonymous)
                    .WithMany(p => p.FlowerComments)
                    .HasForeignKey(d => d.AnonymousId)
                    .HasConstraintName("flowercomments_anonymousid_foreign");

                entity.HasOne(d => d.Flower)
                    .WithMany(p => p.FlowerComments)
                    .HasForeignKey(d => d.FlowerId)
                    .HasConstraintName("flowercomments_flowerid_foreign");
            });

            modelBuilder.Entity<FlowerOrder>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.FlowerId })
                    .HasName("flowerorder_orderid_flowerid_primary");

                entity.ToTable("FlowerOrder");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.FlowerId).HasColumnName("FlowerID");

                entity.Property(e => e.Quantity).HasDefaultValueSql("('1')");

                entity.HasOne(d => d.Flower)
                    .WithMany(p => p.FlowerOrders)
                    .HasForeignKey(d => d.FlowerId)
                    .HasConstraintName("flowerorder_flowerid_foreign");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.FlowerOrders)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("flowerorder_orderid_foreign");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AnonymousId).HasColumnName("AnonymousID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Note).HasMaxLength(255);

                entity.Property(e => e.PaidAt).HasColumnType("datetime");

                entity.Property(e => e.ShippingCost).HasDefaultValueSql("('0')");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Anonymous)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.AnonymousId)
                    .HasConstraintName("orders_anonymousid_foreign");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Body).IsRequired();

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.MainImageUrl)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("MainImageURL");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("posts_userid_foreign");
            });

            modelBuilder.Entity<PostComment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AnonymousId).HasColumnName("AnonymousID");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Anonymous)
                    .WithMany(p => p.PostComments)
                    .HasForeignKey(d => d.AnonymousId)
                    .HasConstraintName("postcomments_anonymousid_foreign");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostComments)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("postcomments_postid_foreign");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "users_email_unique")
                    .IsUnique();

                entity.HasIndex(e => e.Token, "users_token_unique")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
