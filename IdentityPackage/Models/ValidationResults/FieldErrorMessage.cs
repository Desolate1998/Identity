using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityPackage.Models.ValidationResults
{
  public class FieldErrorMessage
  {
    /// <summary>
    /// The file name for which the validation failed
    /// </summary>
    public string FieldName { get; set; }

    /// <summary>
    /// The error message for the field
    /// </summary>
    public ICollection<string> ErrorMessages { get; set; }
  }
}
