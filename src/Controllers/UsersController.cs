using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace src.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class UsersController : ControllerBase
  {
    private readonly ILogger<UsersController> _logger;
    private readonly ApplicationDbContext _context;


    public UsersController(
      ILogger<UsersController> logger,
      ApplicationDbContext context
    )
    {
      _logger = logger;
      _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> list()
    {

      var users = await this._context.Users
        .Include("person")
        .Select(u => new UserDto(u))
        .ToArrayAsync();

      return users;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> show(int id)
    {
      var user = await this._context.Users
        .Include("person")
        .Where(u => u.Id == id)
        .Select(u => new UserDto(u))
        .FirstOrDefaultAsync();

      if (user is null)
      {
        return NotFound();
      }

      return user;
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> create(UserDto user)
    {

      var existingUsers = await this._context.Users.Where(u => u.username == user.username).ToArrayAsync();

      if (existingUsers.Length >= 1)
      {
        return Conflict($"Username {user.username} already exists");
      }

      Person person = new Person();
      this._context.People.Add(person);
      await _context.SaveChangesAsync();

      User newUser = new User()
      {
        username = $@"{user.username}",
        isAdmin = user.isAdmin,
        personId = person.Id,
        isDisabled = false,
        isActive = false,
        isDeleted = false
      };
      this._context.Users.Add(newUser);
      await _context.SaveChangesAsync();
      return new UserDto(newUser);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserDto>> update(int id, UserDto userData)
    {
      if (id != userData.Id)
      {
        return BadRequest();
      }

      var localUser = await this._context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
      if (localUser is null)
      {
        return NotFound();
      }

      var user = new User()
      {
        personId = localUser.personId,
        Id = userData.Id,
        username = userData.username,
        isAdmin = userData.isAdmin,
        isDisabled = userData.isDisabled,
        isActive = userData.isActive,
        isDeleted = userData.isDeleted
      };

      _context.Entry(localUser).State = EntityState.Detached;
      _context.Entry(user).State = EntityState.Modified;

      var updatedUser = await this._context.Users
        .Where(u => u.Id == user.Id)
        .Include("person")
        .FirstOrDefaultAsync();
      try
      {
        await _context.SaveChangesAsync();
        return new UserDto(updatedUser);
      }
      catch (DbUpdateConcurrencyException)
      {
        throw;
      }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<UserDto>> delete(int id)
    {

      // Find the user in the database
      var user = await _context.Users.FindAsync(id);
      if (user == null)
      {
        return NotFound();
      }

      // Ensure that at least one admin remains in the system
      if (user.isAdmin)
      {
        var admins = this._context.Users
          .Where(u => u.isAdmin == true && u.isDeleted == false && u.isDisabled == false && u.isActive == true)
          .ToArray();
        if (admins.Length <= 1)
        {
          return Conflict("The last admin can not be deleted");
        }
      }

      // Delete the user
      var person = await this._context.People.Where(p => p.Id == user.Id).FirstOrDefaultAsync();
      if (!(person is null))
      {
        this._context.People.Remove(person);
      }

      _context.Users.Remove(user);
      await _context.SaveChangesAsync();
      return new UserDto(user);
    }
  }
}