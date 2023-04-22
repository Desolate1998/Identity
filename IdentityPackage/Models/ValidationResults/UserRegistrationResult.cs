
namespace IdentityPackage.Models.ValidationResults
{
  /// <summary>
  /// Model used when a user register, the results of their reregistration will be contained in this model
  /// </summary>
  public class UserRegistrationResult
  {
    /// <summary>
    /// Indication if the registration was successful or not
    /// </summary>
    public bool IsSuccessful { get; set; }

    /// <summary>
    /// A list of error messages on why the registration was not successful
    /// </summary>
    public ICollection<FieldErrorMessage>? ErrorMessage { get; set; } 
  }
}
