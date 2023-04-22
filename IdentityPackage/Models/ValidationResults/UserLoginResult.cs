using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityPackage.Models.ValidationResults
{
  public class UserLoginResult
  {
    /// <summary>
    /// Indication if the login was successful
    /// </summary>
    public bool IsSuccessful { get; set; }

    /// <summary>
    /// Message related to why the login failed
    /// </summary>
    public string Message { get; set; }
  }
}
