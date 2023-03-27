namespace IdentityPackage.Models.Structs
{
  /// <summary>
  /// Struct which is used to store information about Actions
  /// </summary>
  public struct ActionInfromation
  {
    /// <summary>
    /// API controller endpoint
    /// </summary>
    public string Controller { get; set; }

    /// <summary>
    /// Indication if the controller as a authorized tag
    /// </summary>
    public bool AuthorizeController { get; set; }

    /// <summary>
    /// The action being called form the controller
    /// </summary>
    public string Action { get; set; }

    /// <summary>
    /// Indication if the action has the authorized tag
    /// </summary>
    public bool AllowUnauthorize { get; set; }

    /// <summary>
    /// the route being accessed
    /// </summary>
    public string Route { get; set; }

    /// <summary>
    /// The attributes for the action
    /// </summary>
    public string ActionAttributes { get; set; }
  }
}
