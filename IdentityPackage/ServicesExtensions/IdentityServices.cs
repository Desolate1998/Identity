using IdentityPackage.Core;
using IdentityPackage.IdentitityInternalServices;
using IdentityPackage.Models.Database;
using IdentityPackage.Models.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

      PasswordService.options = options;
      PasswordService.salt = passwordHashingSalt;
      services.AddTransient<IIdentityServiceManager<TUser>, IdentityServicesManager<TUser, TDbContext>>();
      return services;
    }
  }
}
