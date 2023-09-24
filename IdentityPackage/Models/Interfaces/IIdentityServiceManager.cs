using IdentityPackage.Core;
using IdentityPackage.Models.Database;
using IdentityPackage.Models.ValidationResults;

namespace IdentityPackage.Models.Interfaces
{
  /// <summary>
  /// Interface used by <see cref="IdentityServiceManager{TUser, TDbContext}"/>
  /// contains all the identity functions required for the package.
  /// </summary>
  /// <typeparam name="TUser"></typeparam>
  public interface IIdentityServiceManager<TUser> where TUser : IdentityDbUser
  {
    /// <summary>
    /// Sign in function that will validate a user sign in
    /// </summary>
    /// <param name="email">The user email</param>
    /// <param name="password">The user password</param>
    /// <returns><see cref="UserLoginResult"/> A model containing the login results</returns>
    Task<UserLoginResult> SignIn(TUser request);

    /// <summary>
    /// Registers a user into the database.
    /// </summary>
    /// <param name="request">The registration details of the user, must implement <see cref="IdentityDbUser"/> to be valid</param>
    /// <returns><see cref="UserRegistrationResult"/> A model containing the registration results</returns>
    Task<UserRegistrationResult> RegisterAsync(TUser request);
  }
}
