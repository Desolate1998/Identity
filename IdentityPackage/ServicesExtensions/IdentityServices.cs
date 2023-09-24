using IdentityPackage.Core;
using IdentityPackage.IdentityInternalServices;
using IdentityPackage.Models.Database;
using IdentityPackage.Models.Interfaces;
using Microsoft.Extensions.DependencyInjection;


namespace IdentityPackage.ServicesExtensions
{
  public static class IdentityServices
  {
    public static IServiceCollection AddIdentityServices<TUser, TDbContext>
      (this IServiceCollection services,
       IdentityDbOptions options,
      string passwordHashingSalt
      ) where TDbContext : IdentityDbContext<TUser> where TUser : IdentityDbUser
    {
      services.AddSingleton<IdentityDbOptions>(options);
      services.AddSingleton<IPasswordService, PasswordService>(provider => new PasswordService(passwordHashingSalt, options));
      services.AddTransient<IIdentityServiceManager<TUser>, IdentityServiceManager<TUser, TDbContext>>();
      return services;
    }
  }
}
