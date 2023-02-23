using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityPackage.Models.Interfaces
{
  public interface IIdentityTokenService
  {

    public string CreateToken(IEnumerable<Claim> claims, DateTime expiryDate = default);
    public bool ValidateToken(string token);
  }
}
