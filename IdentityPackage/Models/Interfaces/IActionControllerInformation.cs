using IdentityPackage.Models.Structs;

namespace IdentityPackage.Models.Interfaces
{
  /// <summary>
  /// Contains the information of controllers and actions in the API package and indication if they should be authorized or not for the route
  /// </summary>
  public interface IActionControllerInformation
  {
    /// <summary>
    /// Controller and action information
    /// </summary>
    public ICollection<ActionInfromation> ActionInformation { get; set; }
  }
}
