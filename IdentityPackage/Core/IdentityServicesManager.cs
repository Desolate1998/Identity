using IdentityPackage.IdentitityInternalServices;
using IdentityPackage.Models.Database;
using IdentityPackage.Models.Enums;
using IdentityPackage.Models.Interfaces;
using IdentityPackage.Models.ValidationResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace IdentityPackage.Core
{
  public class IdentityServicesManager<TUser, TDbContext> : IIdentityServiceManager<TUser>
    where TDbContext : IdentityDbContext<TUser>
    where TUser : IdentityDbUser
  {
    /// <summary>
    /// Database context
    /// </summary>
    private readonly TDbContext _context;

    /// <summary>
    /// ILogger used for logging
    /// </summary>
    private readonly ILogger<IdentityServicesManager<TUser, TDbContext>> _logger;

    /// <summary>
    /// Password manager class containing any functions to do with the password
    /// </summary>
    private readonly PasswordService _passwordManager;

    /// <summary>
    /// Default Constructor
    /// </summary>
    /// <param name="context">The database constructor</param>
    /// <param name="logger">Logger used to log</param>
    /// <param name="configuration">Configuration class</param>
    /// <exception cref="ArgumentNullException">Exception thrown when any of the injected classes is null</exception>
    public IdentityServicesManager(TDbContext context, ILogger<IdentityServicesManager<TUser, TDbContext>> logger)
    {
      _context = context ?? throw new ArgumentNullException(nameof(context));
      _logger = logger ?? throw new ArgumentNullException(nameof(logger));
     
    }

    /// <summary>
    /// Sign in function that will validate a user sign in
    /// </summary>
    /// <param name="email">The user email</param>
    /// <param name="password">The user password</param>
    /// <returns><see cref="UserLoginResult"/> A model containing the login results</returns>
    public Task<UserLoginResult> SignIn(string email, string password)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Registers a user into the database.
    /// </summary>
    /// <param name="request">The registration details of the user, must implement <see cref="IdentityDbUser"/> to be valid</param>
    /// <returns><see cref="UserRegistrationResult"/> A model containing the registration results</returns>
    public async Task<UserRegistrationResult> Register(TUser request)
    {
      try
      {
        
        if (await _context.Users.AnyAsync(x => x.Email == request.Email))
        {
          return new UserRegistrationResult()
          {
            Succesfull = false,
            ErrorMessage = {
              new()
              {
                FieldName = nameof(request.Email),
                ErrorMessage = "User already exists"
              }
            },
            ErrorType = RegistrationErrorType.UserAlreadyExists
          };
        }
        request.Password = _passwordManager.HashPassword(request.Password);
        _ = _context.Add(request);
        _ = await _context.SaveChangesAsync();
        return new()
        {
          Succesfull = true
        };
      }
      catch (Exception ex)
      {
        _logger.LogTrace("An exception was thrown while trying to register user", ex);
        throw;
      }
    }

    public async Task<bool> DeactiveAccount(string email)
    {
      try
      {
        _logger.LogInformation("DeactiveAccount");
        _ = await _context.SaveChangesAsync();
        throw new NotImplementedException();
      }
      catch (Exception ex)
      {
        _logger.LogCritical(new EventId(), ex, "An exception was thrown while trying to register user");
        throw;
      }
    }
  }
}
