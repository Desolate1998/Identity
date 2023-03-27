
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityPackage.Models.Database
{
  /// <summary>
  /// Model used for the DbUser in the database
  /// </summary>
  public class IdentityDbUser
  {
    /// <summary>
    /// The user password hash
    /// </summary>
    [Column("Password")]
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// The user email
    /// </summary>
    [Column("Email")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Indication if the email was confirmed or not
    /// </summary>
    [Column("Email_Confirmed")]
    public bool EmailConfirmed { get; set; }

    /// <summary>
    /// The user phone number
    /// </summary>
    [Column("Phone_Number")]
    public string PhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// Indication if the email was confirmed or not
    /// </summary>
    [Column("Phone_Number_Confirmed")]
    public bool PhoneNumberConfirmed { get; set; }

    /// <summary>
    /// If the user has two factor authentication enabled or not
    /// </summary>
    [Column("Two_Factor_Authentication_Enabled")]
    public bool TwoFactorAuthenticationEnabled { get; set; }

    /// <summary>
    /// The count the user has failed their login
    /// </summary>
    [Column("Login_Failed_Count")]
    public int LoginFailedCount { get; set; }

    /// <summary>
    /// The time after they are allowed to retry login
    /// </summary>
    [Column("Failed_Timout_Time")]
    public DateTime? FailedTimoutTime { get; set; }

    /// <summary>
    /// Indication if the account is active or not
    /// </summary>
    [Column("Account_Active")]
    public bool AccountActive { get; set; }
  }
}
