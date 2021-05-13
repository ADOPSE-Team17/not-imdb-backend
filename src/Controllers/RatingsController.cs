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
  public class RatingsController : ControllerBase
  {

    private readonly ILogger<RatingsController> _logger;
    private readonly ApplicationDbContext _context;

    public RatingsController(
      ILogger<RatingsController> logger,
      ApplicationDbContext context
    )
    {
      _logger = logger;
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Rating>>> Get()
    {
      var ratings = await this._context.Ratings
        .ToArrayAsync();

      return ratings;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Rating>> GetRating(int id)
    {
      var rating = await this._context.Ratings
        .Where(m => m.Id == id)
        .FirstOrDefaultAsync();

      if (rating is null)
      {
        return NotFound();
      }

      return rating;
    }

    [HttpPost]
    public async Task<ActionResult<Rating>> CreateRating(Rating rating)
    {
      this._context.Ratings.Add(rating);
      await _context.SaveChangesAsync();
      return rating;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Rating>> UpdateRating(int id, Rating rating)
    {

      if (id != rating.Id)
      {
        return BadRequest();
      }

      _context.Entry(rating).State = EntityState.Modified;
      var localrating = await this._context.Ratings.Where(a => a.Id == id).FirstOrDefaultAsync();

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (rating is null)
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return rating;

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Rating>> DeleteRating(int id)
    {
      var rating = await _context.Ratings.FindAsync(id);
      if (rating == null)
      {
        return NotFound();
      }

      _context.Ratings.Remove(rating);
      await _context.SaveChangesAsync();

      return rating;
    }
  }
}