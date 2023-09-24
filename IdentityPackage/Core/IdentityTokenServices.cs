using IdentityPackage.Models.BuilderModels;
using IdentityPackage.Models.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityPackage.Core
{
  public class IdentityTokenServices: IIdentityTokenService
  {
    private readonly IdentityTokenSetup _tokenSettings;

    public IdentityTokenServices(IdentityTokenSetup tokenSettings)
    {
      _tokenSettings = tokenSettings;
    }

    public string CreateToken(IEnumerable<Claim> claims, DateTime expiryDate = default)
    {
      if (expiryDate == default)
      {
        expiryDate = DateTime.UtcNow.AddDays(30).Date;
      }

      SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_tokenSettings.IssuerSigningKey));
      SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha512Signature);
      SecurityTokenDescriptor tokenDescriptor = new()
      {
        Subject = new ClaimsIdentity(claims),
        Expires = expiryDate,
        SigningCredentials = credentials,
        IssuedAt = DateTime.UtcNow,
      };

      JwtSecurityTokenHandler tokenHandler = new();
      SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }

    public bool ValidateToken(string token)
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_tokenSettings.IssuerSigningKey);

      try
      {
        tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(key),
          ValidateIssuer = true,
          ValidateAudience = true,
          ClockSkew = TimeSpan.Zero
        }, out SecurityToken validatedToken);

        return true;
      }
      catch
      {
        return false;
      }
    }
  }
}
