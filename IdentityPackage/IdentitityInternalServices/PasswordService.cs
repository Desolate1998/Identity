using IdentityPackage.Models.Database;
using IdentityPackage.Models.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IdentityPackage.IdentitityInternalServices
{
  internal class PasswordService: IPasswordService
  {

    private readonly IdentityDbOptions _options;
    private readonly string _salt;

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="salt">Salt used with the password</param>
    /// <param name="options">Identity db options</param>
    /// <exception cref="ArgumentNullException"></exception>
    public PasswordService(string salt, IdentityDbOptions options)
    {
      _salt = salt ?? throw new ArgumentNullException(nameof(salt));
      _options = options ?? throw new ArgumentNullException(nameof(options));
    }

    /// <summary>
    /// Validates the user password against the hashed password
    /// </summary>
    /// <param name="password"></param>
    /// <param name="hashedPassword"></param>
    /// <returns>Indication if the two passwords matches</returns>
    public bool ValidatePassword(string password, string hashedPassword)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Hashes the users password
    /// </summary>
    /// <param name="password">The users password</param>
    public string HashPassword (string password)
    {
      SHA256 hash = SHA256.Create();
      return Convert.ToHexString(hash.ComputeHash(Encoding.Default.GetBytes(password + _salt)));
    }
    

  }
}
