using IdentityPackage.Models.Database;
using IdentityPackage.Models.Interfaces;
using IdentityPackage.Models.ValidationResults;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace IdentityPackage.IdentityInternalServices
{
  public class PasswordService: IPasswordService
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
    public bool ValidatePasswordLogin(string password, string hashedPassword)
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

    /// <summary>
    /// Validates the users password to ensure security is up to standards
    /// </summary>
    /// <param name="password">The users password</param>
    /// <returns></returns>
    public FieldErrorMessage ValidatePassword(string password)
    {
      FieldErrorMessage errors = new()
      {
        ErrorMessages = new List<string>(),
        FieldName = "password"
      };

      if (password.Length < 0 || string.IsNullOrWhiteSpace(password))
      {
        errors.ErrorMessages.Add("Invalid password, password cannot be empty");
      }

      #region Lower case

      if (_options.PasswordValidationRules.MustHaveLowerCaseCharacter == true && !password.Any(char.IsLower))
      {
        errors.ErrorMessages.Add(_options.PasswordValidationRules.LowerCaseCharacterMessage);
      } 
      else if (_options.PasswordValidationRules.MustHaveLowerCaseCharacter == false && password.Any(char.IsLower))
      {
        errors.ErrorMessages.Add("Password cannot contain lower case character");
      }

      #endregion Lower case

      #region Upper case

      if (_options.PasswordValidationRules.MustHaveUpperCaseCharacter == true && !password.Any(char.IsUpper))
      {
        errors.ErrorMessages.Add(_options.PasswordValidationRules.UpperCharacterMessage);
      }
      else if (_options.PasswordValidationRules.MustHaveLowerCaseCharacter == false && password.Any(char.IsUpper))
      {
        errors.ErrorMessages.Add("Password cannot contain upper case character");
      }

      #endregion Upper case
      
      #region Length

      if (_options.PasswordValidationRules.MinLength != null && password.Length < _options.PasswordValidationRules.MinLength)
      {
        errors.ErrorMessages.Add(_options.PasswordValidationRules.MinLengthMessage);
      }

      if (_options.PasswordValidationRules.MaxLength != null && password.Length > _options.PasswordValidationRules.MaxLength)
      {
        errors.ErrorMessages.Add(_options.PasswordValidationRules.MaxLengthMessage);
      }

      #endregion Length

      var specialCharPassword = Regex.Replace(password, @"[A-z/0-9]", string.Empty);

      if (_options.PasswordValidationRules.MustHaveSpecialCharacter && specialCharPassword.Length == 0)
      {
        errors.ErrorMessages.Add(_options.PasswordValidationRules.SpecialCharacterMessage);
      }

      return errors;
    }
  } 
}
