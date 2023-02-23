using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityPackage.Models.Structs
{
  public struct ActionInfromation
  {
    public string Controller { get; set; }
    public bool AuthorizeController { get; set; }
    public string Action { get; set; }
    public bool AllowUnauthorize { get; set; }
    public string Route { get; set; }
    public string ActionAttributes { get; set; }
  }
}
