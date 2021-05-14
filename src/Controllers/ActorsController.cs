using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace src.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ActorsController : ControllerBase
  {

    private readonly ILogger<ActorsController> _logger;
    private readonly ApplicationDbContext _context;

    public ActorsController(
      ILogger<ActorsController> logger,
      ApplicationDbContext context
    )
    {
      _logger = logger;
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Actor>>> Get()
    {
      var actors = await this._context.Actors
        .ToArrayAsync();

      return actors;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Actor>> GetActor(int id)
    {
      var actor = await this._context.Actors
        .Where(m => m.Id == id)
        .FirstOrDefaultAsync();

      if (actor is null)
      {
        return NotFound();
      }

      return actor;
    }

    [HttpPost]
    public async Task<ActionResult<Actor>> CreateActor(Actor actor)
    {
      this._context.Actors.Add(actor);
      await _context.SaveChangesAsync();
      return actor;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Actor>> UpdateActor(int id, Actor actor)
    {

      if (id != actor.Id)
      {
        return BadRequest();
      }

      _context.Entry(actor).State = EntityState.Modified;
      var localactor = await this._context.Actors.Where(a => a.Id == id).FirstOrDefaultAsync();

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (actor is null)
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return actor;

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Actor>> DeleteActor(int id)
    {
      var actor = await _context.Actors.FindAsync(id);
      if (actor == null)
      {
        return NotFound();
      }

      _context.Actors.Remove(actor);
      await _context.SaveChangesAsync();

      return actor;
    }
  }
}