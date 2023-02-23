using IdentityPackage.Core;
using IdentityPackage.Models;
using IdentityPackage.Models.Attributes;
using IdentityPackage.Models.BuilderModels;
using IdentityPackage.Models.Structs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace IdentityPackage.ApplicationExtensions
{
  public static class IdentityAuthorizationExtension
  {
    public static IApplicationBuilder UseIdentityAuthorization(this IApplicationBuilder app)
    {
      return app.UseMiddleware<IdentityAuthorization>();
    }
  }
}
  