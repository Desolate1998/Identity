namespace IdentityPackage.Models.BuilderModels
{
  /// <summary>
  /// Default rules for password validation 
  /// </summary>
  public class PasswordValidationRule
  {
    /// <summary>
    /// The max length of the password, by default it is null.
    /// When set to null there will be no max length validation
    /// </summary>
    public int? MaxLength { get; set; } = null;

    /// <summary>
    /// Message displayed if the password is more than the max length
    /// </summary>
    public string MaxLengthMessage { get; set; } = "Password does not meet max length required";

    /// <summary>
    /// The min length of the password, by default it is null.
    /// When set to null there will be no min length validation
    /// </summary>
    public int? MinLength { get; set; } = null;

    /// <summary>
    /// Message displayed if the password is more than the min length
    /// </summary>
    public string MinLengthMessage { get; set; } = "Password does not meet min length required";

    /// <summary>
    /// If validation is enabled to ensure the password contains a special character
    /// </summary>
    public bool MustHaveSpecialCharacter { get; set; } = false;

    /// <summary>
    /// Message if the password does not have a special character
    /// </summary>
    public string SpecialCharacterMessage { get; set; } = "Password does not contain special character";

    /// <summary>
    /// When enabled will ensure that the password contains lowercase validation
    /// if set to null the password can either contain upper case or not. When set to false the password
    /// wont be allowed any lowercase character. 
    /// </summary>
    public bool? MustHaveLowerCaseCharacter { get; set; } = null;

    /// <summary>
    /// Message displayed when the lowerCase requirements are not met
    /// </summary>
    public string LowerCaseCharacterMessage { get; set; } = "Password does not contain lower case character";

    /// <summary>
    /// When enabled will ensure that the password contains uppercase validation
    /// if set to null the password can either contain upper case or not. When set to false the password
    /// wont be allowed any uppercase character. 
    /// </summary>
    public bool? MustHaveUpperCaseCharacter { get; set; } = null;

    /// <summary>
    /// Message displayed when the uppercase requirements are not met
    /// </summary>
    public string UpperCharacterMessage { get; set; } = "Password does not contain lower special character";
  }
}
