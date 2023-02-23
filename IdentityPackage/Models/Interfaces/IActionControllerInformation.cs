using IdentityPackage.Models.Structs;

namespace IdentityPackage.Models.Interfaces
{
  public interface IActionControllerInformation
  {
    public ICollection<ActionInfromation> ActionInformation { get; set; }
  }
}
