using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace src {
  public class AuthenticationService {

    private string key {get; set;}
    private string issuer {get; set;}

    public AuthenticationService(string key, string issuer) {
      this.key = key;
      this.issuer = issuer;
    }

    public string GenerateJWT(UserDto userInfo)
    {
      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.key));
      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


      var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.username),
                new Claim("Date", DateTime.UtcNow.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };


      var token = new JwtSecurityToken(this.issuer,
        this.issuer,
        claims,
        expires: DateTime.Now.AddHours(2), // TODO: Make configurable
        signingCredentials: credentials);

      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}
