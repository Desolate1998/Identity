namespace IdentityPackage.Models.BuilderModels
{
  /// <summary>
  /// Identity token setup 
  /// </summary>
  public class IdentityTokenSetup
  {
    /// <summary>
    /// Validates the token life time
    /// </summary>
    public bool ValidateLifetime { get; set; }

    /// <summary>
    /// Key used to generate JWT token
    /// </summary>
    public string IssuerSigningKey { get; set; } = string.Empty;
  }
}
