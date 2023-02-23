using IdentityPackage.Core;
using IdentityPackage.Models.Attributes;
using IdentityPackage.Models.BuilderModels;
using IdentityPackage.Models.Database;
using IdentityPackage.Models.Interfaces;
using IdentityPackage.Models.Misc;
using IdentityPackage.Models.Structs;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IdentityPackage.ServicesExtensions
{
  public static class TokenServices
  {
    public static IServiceCollection AddTokenServices(this IServiceCollection services, IdentityTokenSetup tokenSettings)
    {
      var entryAssembly = Assembly.GetEntryAssembly() ?? throw new InvalidOperationException("Entry assembly is null");
      var actions = entryAssembly.GetTypes().SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                                 .Where(method => !method.GetCustomAttributes(typeof(CompilerGeneratedAttribute), true).Any()
                                     && method.GetCustomAttributes().OfType<HttpMethodAttribute>().Any())
                                 .Select(method => new ActionInfromation()
                                 {
                                   Controller = method.DeclaringType?.Name.Replace("Controller", "") ?? throw new NullReferenceException(nameof(method.DeclaringType)),
                                   Action = method.Name,
                                   AuthorizeController = method.DeclaringType.GetCustomAttributes<AuthorizedAttribute>().Any(),
                                   AllowUnauthorize = method.GetCustomAttributes<AllowUnauthorizeAttribute>().Any(),
                                   Route = method.GetCustomAttributes().OfType<HttpMethodAttribute>().FirstOrDefault()?.Name ?? method.Name,
                                   ActionAttributes = string.Join(",", method.GetCustomAttributes().Select(attr => attr.GetType().Name.Replace("Attribute", "")))
                                 }).Where(x => !x.AllowUnauthorize && x.AuthorizeController)//This could be part of the top piece of code, but for readability it was added here 
                                 .OrderBy(info => info.Controller)
                                 .ThenBy(info => info.Action)
                                 .ToList();

      services.AddSingleton<IActionControllerInformation, ActionControllerInformation>(provider => new ActionControllerInformation() { ActionInformation = actions });
      services.AddSingleton<IIdentityTokenService, IdentityTokenServices>((provider) => new IdentityTokenServices(tokenSettings));
      return services;
    }
  }
}
