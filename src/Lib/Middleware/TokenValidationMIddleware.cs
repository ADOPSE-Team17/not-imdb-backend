using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
    }

    public async Task Invoke(
      HttpContext context,
      ApplicationDbContext dataContext
    ) {
      var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

      if (token != null) {
        await attachAccountToContext(context, dataContext, token);
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
        var accountId = int.Parse(jwtToken.Claims.First(x => x.Type == "userId").Value);
        context.Items["User"] = dataContext.Users.Where(u => u.Id == accountId).Include("person").FirstOrDefault();
      }
      catch
      {
        // do nothing if jwt validation fails
        // account is not attached to context so request won't have access to secure routes
      }
    }
  }
}
