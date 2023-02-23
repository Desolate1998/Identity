using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityPackage.Models.Enums
{
  public enum RegistrationErrorType
  {
    Validation,
    Password,
    UserAlreadyExists,
    UnkownError
  }
}
