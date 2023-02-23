using IdentityPackage.Models.BuilderModels;
using Microsoft.EntityFrameworkCore;

namespace IdentityPackage.Models.Database
{
  /// <summary>
  /// IdentityDb context options
  /// </summary>
  public class IdentityDbOptions
  {

    /// <summary>
    /// If failed to logging in locks out the user
    /// </summary>
    public bool LockOutUserEnabled { get; set; }

    /// <summary>
    /// After how many attempts does the user get logged out
    /// </summary>
    public int LockoutAfter { get; set; }

    /// <summary>
    /// An array consisting of the timeouts to failures mapping after lockout [1:5,2:15,3:60]
    /// The max will be used when the user has tried more times
    /// </summary>
    public List<int> LockFailTimer { get; set; } = new List<int>();

    /// <summary>
    /// If only verified accounts are allowed to be logged in
    /// </summary>
    public bool VerfiedUserLoginOnly { get; set; }

    /// <summary>
    /// The password validation rules
    /// </summary>
    public PasswordValidationRule PasswordValidationRules { get; set; }
  }
}
