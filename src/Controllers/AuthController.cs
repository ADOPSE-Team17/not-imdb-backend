using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace src
{
  [AllowAnonymous]
  [ApiController]
  [Route("[controller]")]
  public class AuthController : ControllerBase
  {
    private readonly ILogger<AuthController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly AuthenticationService _authenticationService;

    public AuthController(
      ILogger<AuthController> logger,
      ApplicationDbContext context,
      AuthenticationService authenticationService
    )
    {
      _logger = logger;
      _context = context;
      _authenticationService = authenticationService;
    }

    [Route("Register")]
    [HttpPost]
    public async Task<ActionResult<UserDto>> Register(RegisterDto dto)
    {
      if (dto.password != dto.passwordRepeat)
      {
        return BadRequest(new
        {
          message = "password mismatch"
        });
      }

      using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
      {
        try
        {
          Person person = new Person();
          this._context.Set<Person>().Attach(person);

          User user = new User();
          user.username = dto.username;
          user.person = person;
          user.accounts = new System.Collections.Generic.List<Account>();
          user.isActive = true;
          this._context.Set<User>().Attach(user);

          Account account = new Account();
          account.additionalType = "local";
          account.email = dto.email;
          account.password = dto.password;
          account.userId = user.Id;
          this._context.Set<Account>().Attach(account);

          user.accounts.Add(account);
          await this._context.SaveChangesAsync();
          await transaction.CommitAsync();
          return new UserDto(user);
        }
        catch (Exception e)
        {
          await transaction.RollbackAsync();
          throw new Exception(e.Message);
        }
      }
    }

    [Route("Login")]
    [HttpPost]
    public async Task<ActionResult<LoginResponseDto>> Login(LoginDto dto)
    {
      User user = await this._context.Users
                .Where(u => dto.identifier == u.username && !u.isDeleted && !u.isDisabled && u.isActive)
                .Include("accounts")
                .Where(u => u.accounts.Any(a => a.password == dto.password))
                .Include("person")
                .FirstOrDefaultAsync();

      if (!(user is null))
      {
        return new LoginResponseDto(this._authenticationService.GenerateJWT(new UserDto(user)), new UserDto(user));
      }

      Account account = await this._context.Accounts
          .Where(a => a.email == dto.identifier && a.password == dto.password)
          .FirstOrDefaultAsync();

      if (account is null)
      {
        return Unauthorized();
      }
      else
      {
        User sUser = await this._context.Users
            .Where(u => u.Id == account.userId && !u.isDeleted && !u.isDisabled && u.isActive)
            .Include("person")
            .FirstOrDefaultAsync();

        return new LoginResponseDto(this._authenticationService.GenerateJWT(new UserDto(sUser)), new UserDto(sUser));
      }
    }
  
    [Route("verify")]
    [HttpGet]
    public async Task<ActionResult<UserDto>> Verify() {
      HttpContext localContext = this.HttpContext;
      bool isAuthenticated = this.HttpContext.User.Identity.IsAuthenticated;
      User user = this.HttpContext.Items["User"] as User;
      if (isAuthenticated && !(user is null)) {
        return new UserDto(user);
      } else {
        return Unauthorized();
      }
    }
  }

  public class RegisterDto
  {
    public string username { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string passwordRepeat { get; set; }
  }

  public class LoginDto
  {
    public string identifier { get; set; }
    public string password { get; set; }
  }

  public class LoginResponseDto
  {
    public string token { get; set; }

    public UserDto user { get; set; }

    public LoginResponseDto() { }

    public LoginResponseDto(string token, UserDto user)
    {
      this.token = token;
      this.user = user;
    }
  }
}
