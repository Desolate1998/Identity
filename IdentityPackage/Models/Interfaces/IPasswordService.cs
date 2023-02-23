using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityPackage.Models.Interfaces
{
  public interface IPasswordService
  {
    public bool ValidatePassword(string password, string hashedPassword);
    public string HashPassword(string password);
  }
}
