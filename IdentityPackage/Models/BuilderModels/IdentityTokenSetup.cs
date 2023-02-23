namespace IdentityPackage.Models.BuilderModels
{
  public class IdentityTokenSetup
  {
    /// <summary>
    /// Validates the token life time
    /// </summary>
    public bool ValidateLifetime { get; set; }

    /// <summary>
    /// The issues signing key
    /// </summary>
    public string IssuerSigningKey { get; set; }
  }
}
