using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace src
{
  internal class MyLocalAuthenticationPolicyProvider : IAuthorizationPolicyProvider
  {


    public MyLocalAuthenticationPolicyProvider()
    {

    }
    const string POLICY_PREFIX = "LocalAuthorize";
    private string[] POLICY_ROLES = new string[] { "User", "Administrator" };

    public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
    {
      Console.WriteLine("GetDefaultPolicyAsync()");
      return Task.FromResult<AuthorizationPolicy>(this.getRolesPolicy("TEST"));
    }

    public Task<AuthorizationPolicy> GetFallbackPolicyAsync()
    {
      return Task.FromResult<AuthorizationPolicy>(this.getRolesPolicy("TEST"));
    }

    // Policies are looked up by string name, so expect 'parameters' (like age)
    // to be embedded in the policy names. This is abstracted away from developers
    // by the more strongly-typed attributes derived from AuthorizeAttribute
    // (like [MinimumAgeAuthorize()] in this sample)
    public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
    {
      return Task.FromResult<AuthorizationPolicy>(this.getRolesPolicy(policyName));
    }

    Task<AuthorizationPolicy> IAuthorizationPolicyProvider.GetPolicyAsync(string policyName)
    {
      return Task.FromResult<AuthorizationPolicy>(this.getRolesPolicy("TEST"));
    }

    AuthorizationPolicy getRolesPolicy(string policyName)
    {
      if (policyName.StartsWith(POLICY_PREFIX, StringComparison.OrdinalIgnoreCase))
      {
        var policy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
        return policy.Build();
      }
      else
      {
        var policy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
        Console.WriteLine(policy.ToString());
        policy.AddRequirements(new UserRoleRequirement("Administrator"));
        return policy.Build();
      }
    }
  }

  public class UserRoleRequirement : IAuthorizationRequirement
  {
    public string Role { get; }

    public UserRoleRequirement(string role)
    {
      Role = role;
    }
  }


  public class UserRoleHandler : AuthorizationHandler<UserRoleRequirement>
  { 

    private readonly ApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly JwtSecurityTokenHandler _tokenHandler;

    public UserRoleHandler(
      ApplicationDbContext context,
      IHttpContextAccessor httpContextAccessor) {
      this._context = context;
      this._tokenHandler = new JwtSecurityTokenHandler();
      this._httpContextAccessor = httpContextAccessor;
    }

    protected override Task HandleRequirementAsync(
      AuthorizationHandlerContext userContext,
      UserRoleRequirement requirement)
    {

      if (!userContext.User.HasClaim(c => c.Type == "Usesrname") && userContext.User.Identity.IsAuthenticated)
      {
        userContext.Fail();
        return Task.CompletedTask;
      } else {
        userContext.Succeed(requirement);
      }
      userContext.Succeed(requirement);
      return Task.CompletedTask;
    }
  }
}
