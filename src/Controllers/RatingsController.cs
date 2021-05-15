using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace src.Controllers
{
  [Authorize(Roles = "admin, user")]
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

    [Authorize(Roles = "admin")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Rating>>> Get()
    {
      var ratings = await this._context.Ratings
        .ToArrayAsync();

      return ratings;
    }

    [Authorize(Roles = "admin")]
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

    [HttpPost("{movieId}")]
    public async Task<ActionResult<Rating>> CreateRating(int movieId, Rating rating)
    {
      Movie movie = await this._context.Movies
        .Where(m => m.Id == movieId)
        .Include("ratings")
        .FirstOrDefaultAsync();

      if (movie is null)
      {
        return NotFound(new
        {
          message = "Movie not found!"
        });
      }

      /*try 
      {*/
      if (movie.ratings is null)
      {
        movie.ratings = new List<Rating>();
      }

      this._context.Set<Rating>().Attach(rating);
      movie.ratings.Add(rating);
      /*}
      catch 
      {
        NotFound();
      } */

      Movie avgRating = await this._context.Movies
        .Include("ratings")
        .Where(m => m.Id == movieId)
        //.Select(c => c.ratings.Average(m => m.ratingValue))
        .FirstOrDefaultAsync();
      double av = 0;
      for (int i = 0; i < avgRating.ratings.Count; i++)
      {
        av += avgRating.ratings[i].ratingValue;
      }

      if (avgRating.ratings.Count > 0)
      {
        movie.rating = av / avgRating.ratings.Count;

      }

      await this._context.SaveChangesAsync();
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