using Microsoft.AspNetCore.Http;

namespace IdentityPackage.Models.Interfaces
{
  internal interface IIdentityAuthorization
  {
    /// <summary>
    /// The method that gets invoked by the request passing through the middle ware 
    /// </summary>
    /// <param name="context">The HTTP context that is passed through the request</param>
    public Task Invoke(HttpContext context);
  }
}
