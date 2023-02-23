using IdentityPackage.Models.Interfaces;
using IdentityPackage.Models.Structs;

namespace IdentityPackage.Models.Misc
{
  internal class ActionControllerInformation : IActionControllerInformation
  {
    public ICollection<ActionInfromation> ActionInformation{ get; set; }
  }
}
