using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SocialNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SocialNetwork.Infrastruture.Persistence.Context
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> db) : base(db) { }


        public DbSet<User> Users { get; set; }
        public DbSet<Amigo> Friends { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comentarios> Comments { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "DefaultAppUser";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "DefaultAppUser";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            #region PrimaryKeys

            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<Amigo>().HasKey(x => x.Id);
            modelBuilder.Entity<Post>().HasKey(x => x.Id);
            modelBuilder.Entity<Comentarios>().HasKey(x => x.Id);

            #endregion



            #region Configuration

            modelBuilder.Entity<User>()
                .Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
                .HasIndex(x => x.Email).IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(x => x.Username).IsUnique();




            #endregion


            #region foreign keys

            modelBuilder.Entity<User>()
                .HasMany<Post>(x => x.Posts)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Amigo>()
                .HasOne<User>(x => x.User)
                .WithMany(x => x.Friends)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Amigo>()
                .HasOne<User>(x => x.FriendUser)
                .WithMany(x => x.FriendsOf)
                .HasForeignKey(x => x.FriendId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Comentarios>()
                .HasOne<User>(x => x.User)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comentarios>()
                .HasOne<Post>(x => x.Post)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comentarios>()
                .HasOne(x => x.ParentComment)
                .WithMany(x => x.Replies)
                .HasForeignKey(x => x.ParentCommentId)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion

        }

    }
}
