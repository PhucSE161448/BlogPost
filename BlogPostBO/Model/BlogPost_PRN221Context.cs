using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BlogPostBO.Model
{
    public partial class BlogPost_PRN221Context : DbContext
    {
        public BlogPost_PRN221Context()
        {
        }

        public BlogPost_PRN221Context(DbContextOptions<BlogPost_PRN221Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<BlogPost> BlogPosts { get; set; } = null!;
        public virtual DbSet<BlogPostComment> BlogPostComments { get; set; } = null!;
        public virtual DbSet<BlogPostLike> BlogPostLikes { get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", true, true)
                        .Build();
            var strConn = config.GetConnectionString("DBDefault");
            return strConn;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.IsDelete)
                    .IsRequired()
                    .HasColumnName("Is_Delete")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.Role).HasMaxLength(255);
            });

            modelBuilder.Entity<BlogPost>(entity =>
            {
                entity.ToTable("BlogPost");

                entity.Property(e => e.Content).HasMaxLength(255);

                entity.Property(e => e.Heading).HasMaxLength(255);

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(255)
                    .HasColumnName("Image_Url");

                entity.Property(e => e.PageTitle).HasMaxLength(255);

                entity.Property(e => e.PublishedDate).HasColumnType("datetime");

                entity.Property(e => e.ShortDescription).HasMaxLength(255);

                entity.Property(e => e.UrlHandle)
                    .HasMaxLength(255)
                    .HasColumnName("Url_Handle");

                entity.Property(e => e.Visible)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.BlogPosts)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("blogpost_accountid_foreign");
            });

            modelBuilder.Entity<BlogPostComment>(entity =>
            {
                entity.ToTable("BlogPostComment");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.BlogPostComments)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("blogpostcomment_accountid_foreign");

                entity.HasOne(d => d.BlogPost)
                    .WithMany(p => p.BlogPostComments)
                    .HasForeignKey(d => d.BlogPostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("blogpostcomment_blogpostid_foreign");
            });

            modelBuilder.Entity<BlogPostLike>(entity =>
            {
                entity.ToTable("BlogPostLike");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.BlogPostLikes)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("blogpostlike_accountid_foreign");

                entity.HasOne(d => d.BlogPost)
                    .WithMany(p => p.BlogPostLikes)
                    .HasForeignKey(d => d.BlogPostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("blogpostlike_blogpostid_foreign");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasOne(d => d.BlogPost)
                    .WithMany(p => p.Tags)
                    .HasForeignKey(d => d.BlogPostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tags_blogpostid_foreign");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
