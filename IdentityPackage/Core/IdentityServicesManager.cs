using IdentityPackage.Models.Database;
using IdentityPackage.Models.Interfaces;
using IdentityPackage.Models.ValidationResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IdentityPackage.Core
{
    public class IdentityServiceManager<TUser, TDbContext> : IIdentityServiceManager<TUser>
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
        private readonly ILogger<IdentityServiceManager<TUser, TDbContext>> _logger;

        /// <summary>
        /// Identity options
        /// </summary>
        private readonly IdentityDbOptions _options;

        /// <summary>
        /// Password manager class containing any functions to do with the password
        /// </summary>
        private readonly IPasswordService _passwordManager;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="context">The database constructor</param>
        /// <param name="logger">Logger used to log</param>
        /// <param name="configuration">Configuration class</param>
        /// <exception cref="ArgumentNullException">Exception thrown when any of the injected classes is null</exception>
        public IdentityServiceManager(TDbContext context, ILogger<IdentityServiceManager<TUser, TDbContext>> logger, IPasswordService passwordService, IdentityDbOptions options)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _passwordManager = passwordService ?? throw new ArgumentNullException(nameof(passwordService));
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        /// <summary>
        /// Sign in function that will validate a user sign in
        /// </summary>
        /// <param name="email">The user email</param>
        /// <param name="password">The user password</param>
        /// <returns><see cref="UserLoginResult"/> A model containing the login results</returns>
        public async Task<UserLoginResult> SignIn(TUser request)
        {
            var user = await _context.Users.Where(x => x.Email == request.Email).FirstOrDefaultAsync();

            if (user == null)
            {
                return new()
                {
                    IsSuccessful = false,
                    TimeRemaining = -1,
                    Message = $"User does not exist"
                };
            }

            if (_options.LockOutUserEnabled && user.AccountLockedOut)
            {
                if ((user.FailedTimoutTime != null && user.FailedTimoutTime > DateTime.UtcNow))
                {

                    TimeSpan span = user.FailedTimoutTime.Value - DateTime.UtcNow;
                    return new()
                    {
                        IsSuccessful = false,
                        TimeRemaining = (int)span.TotalMinutes,
                        Message = $"Multiple login attempts failed. Please try again later"
                    };
                }
            }
            if (user.Password != _passwordManager.HashPassword(request.Password))
            {
                if (_options.LockOutUserEnabled)
                {
                    user.LoginFailedCount++;
                    if (user.LoginFailedCount >= _options.LockoutAfter)
                    {
                        if(_options.LockoutAfter == user.LoginFailedCount)
                        {
                            user.FailedTimoutTime = DateTime.UtcNow.AddMinutes(_options.LockFailTimer[0]);
                        }
                        else if((user.LoginFailedCount - _options.LockoutAfter) <= _options.LockFailTimer.Count+1)
                        {
                            user.FailedTimoutTime = DateTime.UtcNow
                                .AddMinutes(_options.LockFailTimer[user.LoginFailedCount - _options.LockoutAfter]);
                        }
                        else
                        {
                            user.FailedTimoutTime = DateTime.UtcNow.AddMinutes(_options.LockFailTimer[^0]);
                        }
                        user.AccountLockedOut = true;
                        _context.SaveChanges();
                        TimeSpan span = user.FailedTimoutTime.Value - DateTime.UtcNow;

                        return new()
                        {
                            IsSuccessful = false,
                            TimeRemaining = (int)span.TotalMinutes,
                            Message = $"Multiple login attempts failed. Please try again later"
                        };
                    }
                }
                _context.SaveChanges();
                return new()
                {
                    IsSuccessful = false,
                    TimeRemaining = -1,
                    Message = $"Credentials invalid"
                };
            }
            else
            {
                if (user.LoginFailedCount > 0)
                {
                    user.AccountLockedOut = false;
                    user.FailedTimoutTime = null;
                    user.LoginFailedCount = 0;
                    _context.SaveChanges();
                }

                return new() { IsSuccessful = true };
            }
        }

        /// <summary>
        /// Registers a user into the database.
        /// </summary>
        /// <param name="request">The registration details of the user, must implement <see cref="IdentityDbUser"/> to be valid</param>
        /// <returns><see cref="UserRegistrationResult"/> A model containing the registration results</returns>
        public async Task<UserRegistrationResult> RegisterAsync(TUser request)
        {
            try
            {
                if (await _context.Users.AnyAsync(x => x.Email == request.Email))
                {
                    return new UserRegistrationResult()
                    {
                        IsSuccessful = false,
                        ErrorMessage = new List<FieldErrorMessage> {
                            new()
                            {
                                FieldName = "email",
                                ErrorMessages = new List<string>(){ "User already exists" }
                            }
                        }
                    };
                }
                FieldErrorMessage results = _passwordManager.ValidatePassword(request.Password);

                if (results.ErrorMessages.Count != 0)
                {
                    return new UserRegistrationResult()
                    {
                        IsSuccessful = false,
                        ErrorMessage = new List<FieldErrorMessage> { results }
                    };
                }

                request.Password = _passwordManager.HashPassword(request.Password);
                _context.Add(request);
                await _context.SaveChangesAsync();

                return new()
                {
                    IsSuccessful = true
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
