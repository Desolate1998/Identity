﻿using System.Web;
using Microsoft.AspNetCore.Http.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityPackage.Models.Attributes
{
  public class AuthorizedAttribute : Attribute
  {
    public AuthorizedAttribute()
    {


    }
  }
}
