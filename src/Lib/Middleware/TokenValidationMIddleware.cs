using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace src
{
  public class JwtMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
    {
      _next = next;
      _configuration = configuration;
      Console.WriteLine("Hello from the authenticaation middleware");
    }

    public async Task Invoke(
      HttpContext context,
      ApplicationDbContext dataContext
    ) {
      var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

      if (token != null) {
        Console.WriteLine("token is not null: " + token);
        await attachAccountToContext(context, dataContext, token);
      } else {
        Console.WriteLine("token IS null");
      }

      await _next(context);
    }

    // it's not being used right now
    private async Task attachAccountToContext(
      HttpContext context, 
      ApplicationDbContext dataContext,
      string token)
    {
      try
      {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(this._configuration["Jwt:Key"]);
        tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(key),
          ValidateIssuer = false,
          ValidateAudience = false,
          // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
          ClockSkew = TimeSpan.Zero
        }, out SecurityToken validatedToken);

        var jwtToken = (JwtSecurityToken)validatedToken;
        // var accountId = int.Parse(jwtToken.Claims.First(x => x.Type == "accountId").Value);

        // attach account to context on successful jwt validation
        context.Items["Account"] = "Hello world";
        Claim[] claims  = new[] {
          new Claim("name", "username"),
          new Claim("username", "admin01"),
          new Claim(ClaimTypes.Role, "admin")
        };

        var identity = new ClaimsIdentity(claims, "basic");
        context.User = new ClaimsPrincipal(identity);
        // userContext.User.Claims.Append(new System.Security.Claims.Claim("username", "this is my name"));
      }
      catch
      {
        Console.WriteLine("I am in the middleware catch");
        // do nothing if jwt validation fails
        // account is not attached to context so request won't have access to secure routes
      }
    }
  }
}
