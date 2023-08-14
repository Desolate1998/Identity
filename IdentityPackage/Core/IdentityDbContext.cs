using IdentityPackage.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace IdentityPackage.Core
{
  public class IdentityDbContext<TUser>: DbContext where TUser : IdentityDbUser
  {
    public IdentityDbContext(DbContextOptions options) : base(options)
    {
      
    }

    public DbSet<TUser> Users { get; set; }
  }
}
