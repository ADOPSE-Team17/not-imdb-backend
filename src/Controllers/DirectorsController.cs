using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace src.Controllers
{
  [Authorize(Roles = "admin")]
  [ApiController]
  [Route("[controller]")]
  public class DirectorsController : ControllerBase
  {

    private readonly ILogger<DirectorsController> _logger;
    private readonly ApplicationDbContext _context;

    public DirectorsController(
      ILogger<DirectorsController> logger,
      ApplicationDbContext context
    )
    {
      _logger = logger;
      _context = context;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Director>>> Get()
    {
      var directors = await this._context.Directors
        .ToArrayAsync();

      return directors;
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<Director>> GetDirector(int id)
    {
      var director = await this._context.Directors
        .Where(d => d.Id == id)
        .FirstOrDefaultAsync();

      if (director is null)
      {
        return NotFound();
      }

      return director;
    }

    [HttpPost]
    public async Task<ActionResult<Director>> Createdirector(Director director)
    {
      this._context.Directors.Add(director);
      await _context.SaveChangesAsync();
      return director;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Director>> Updatedirector(int id, Director director)
    {

      if (id != director.Id)
      {
        return BadRequest();
      }

      _context.Entry(director).State = EntityState.Modified;
      var localdirector = await this._context.Directors.Where(d => d.Id == id).FirstOrDefaultAsync();

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (director is null)
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return director;

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Director>> DeleteDirector(int id)
    {
      var director = await _context.Directors.FindAsync(id);
      if (director == null)
      {
        return NotFound();
      }

      _context.Directors.Remove(director);
      await _context.SaveChangesAsync();

      return director;
    }
  }
}