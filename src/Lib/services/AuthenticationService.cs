using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using Microsoft.IdentityModel.Tokens;

namespace src
{
  public class AuthenticationService
  {

    private string key { get; set; }
    private string issuer { get; set; }
    private int hours { get; set; }

    public AuthenticationService(string key, string issuer, int hours)
    {
      this.key = key;
      this.issuer = issuer;
      this.hours = hours;
    }

    public string GenerateJWT(UserDto userInfo)
    {
      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.key));
      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


      Claim[] claims = new[] {
                new Claim("userId", userInfo.Id.ToString()),
                new Claim("Date", DateTime.UtcNow.ToString()),
                new Claim(ClaimTypes.Role, userInfo.isAdmin ? "admin" : "user"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

      var token = new JwtSecurityToken(this.issuer,
        this.issuer,
        claims,
        expires: DateTime.Now.AddHours(this.hours),
        signingCredentials: credentials);

      return new JwtSecurityTokenHandler().WriteToken(token);
    }


    public string DecodeToken(string Input)
    {
      var key = Encoding.ASCII.GetBytes(this.key);
      var handler = new JwtSecurityTokenHandler();
      var tokenSecure = handler.ReadToken(Input) as SecurityToken;
      var validations = new TokenValidationParameters
      {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
      };

      var claims = handler.ValidateToken(Input, validations, out tokenSecure);
      var prinicpal = (ClaimsPrincipal)Thread.CurrentPrincipal;

      // if (prinicpal is ClaimsPrincipal claims)
      // {
      //   return new ApplicationDTO
      //   {
      //     Id = claims.Claims.FirstOrDefault(x => x.Type == "sub")?.Value ?? "",
      //     UserName = claims.Claims.FirstOrDefault(x => x.Type == "preferred_username")?.Value ?? "",
      //     Email = claims.Claims.FirstOrDefault(x => x.Type == "email")?.Value ?? ""
      //   };
      // }

      return null;
    }
  }
}
