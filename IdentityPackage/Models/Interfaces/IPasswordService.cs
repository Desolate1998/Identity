using IdentityPackage.Models.ValidationResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityPackage.Models.Interfaces
{
  public interface IPasswordService
  {
    /// <summary>
    /// Validates the user password against the hashed password
    /// </summary>
    /// <param name="password"></param>
    /// <param name="hashedPassword"></param>
    /// <returns>Indication if the two passwords matches</returns>
    public bool ValidatePasswordLogin(string password, string hashedPassword);

    /// <summary>
    /// Hashes the users password
    /// </summary>
    /// <param name="password">The users password</param>
    public string HashPassword(string password);

    /// <summary>
    /// validates the users password for security 
    /// </summary>
    /// <param name="password">The users password</param>
    /// <returns>List of errors for the password field</returns>
    public FieldErrorMessage ValidatePassword(string password);
  }
}
