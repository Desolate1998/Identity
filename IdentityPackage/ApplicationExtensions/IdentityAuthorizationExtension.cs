using IdentityPackage.Core;
using Microsoft.AspNetCore.Builder;

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
