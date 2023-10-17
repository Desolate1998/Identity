using System.Security.Claims;

namespace IdentityPackage.Models.Interfaces;


/// <summary>
/// JWT token services
/// </summary>
public interface IIdentityTokenService
{
    /// <summary>
    /// Create a JWT token
    /// </summary>
    /// <param name="claims">The user claims to be added to the token</param>
    /// <param name="issuer">The issuer of the token</param>
    /// <param name="expiryDate">The date the token will expire defaults to 2 hours</param>
    /// <returns>a valid JWT token</returns>
    public string CreateToken(IEnumerable<Claim> claims, string issuer, string audience, DateTime expiryDate = default);

    /// <summary>
    /// Validates the user's JWT token
    /// </summary>
    /// <param name="token">token to be validated</param>
    /// <returns>Indication if the token is valid or not</returns>
    public bool ValidateToken(string token);
}
