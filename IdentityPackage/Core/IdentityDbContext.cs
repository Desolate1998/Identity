using IdentityPackage.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace IdentityPackage.Core
{
    public class IdentityDbContext<TUser> : DbContext where TUser : IdentityDbUser
    {
        public IdentityDbContext(DbContextOptions options) : base(options)
        {

        }

        /// <summary>
        /// The user table
        /// </summary>
        public DbSet<TUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TUser>(e => e.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()"));
            base.OnModelCreating(modelBuilder);
        }
    }
}
