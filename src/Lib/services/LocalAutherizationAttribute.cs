using System;
using Microsoft.AspNetCore.Authorization;

namespace src
{
  internal class LocalAuthorizeAttribute : AuthorizeAttribute
  {
    const string POLICY_PREFIX = "LocalAuthorize";

    public LocalAuthorizeAttribute(string role) {
      Role = role;
    } 

    // Get or set the Age property by manipulating the underlying Policy property
    public string Role
    {
      get
      {
        return Policy.Substring(POLICY_PREFIX.Length);
      }
      set
      {
        Policy = $"{POLICY_PREFIX}{value.ToString()}";
      }
    }
  }
}
