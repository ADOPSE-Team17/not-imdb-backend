using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System;

namespace src.Controllers
{
  [Authorize(Roles = "admin")]
  [ApiController]
  [Route("[controller]")]
  public class MoviesController : ControllerBase
  {

    private readonly ILogger<MoviesController> _logger;
    private readonly ApplicationDbContext _context;

    public MoviesController(
      ILogger<MoviesController> logger,
      ApplicationDbContext context
    )
    {
      _logger = logger;
      _context = context;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Movie>>> Get([FromQuery(Name = "search")] string search)
    {
      var moviesQery = this._context.Movies
        .Include("comments")
        .Include("events")
        .Include("products")
        .Include("parentMovie")
        .Include("ratings");
      
      if (!(search is null)) {
        moviesQery = moviesQery.Where(m => m.headline.Contains(search) || m.about.Contains(search) || m.abstractText.Contains(search));
      }

      Console.WriteLine("search: " + search);
      
      Movie[] movies = await moviesQery.ToArrayAsync();
      return movies;
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<Movie>> Getmovie(int id)
    {
      var movie = await this._context.Movies
        .Include("comments")
        .Include("events")
        .Include("products")
        .Include("parentMovie")
        .Include("ratings")
        .Where(m => m.Id == id)
        .FirstOrDefaultAsync();

      if (movie is null)
      {
        return NotFound();
      }

      return movie;
    }

    [HttpPost]
    public async Task<ActionResult<Movie>> CreateMovie(Movie movie)
    {
      this._context.Movies.Add(movie);
      await _context.SaveChangesAsync();
      return movie;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Movie>> UpdateMovie(int id, Movie movie)
    {

      if (id != movie.Id)
      {
        return BadRequest();
      }

      _context.Entry(movie).State = EntityState.Modified;
      var localmovie = await this._context.Movies.Where(m => m.Id == id).FirstOrDefaultAsync();

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (movie is null)
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return movie;

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Movie>> DeleteMovie(int id)
    {
      var movie = await _context.Movies.FindAsync(id);
      if (movie == null)
      {
        return NotFound();
      }

      _context.Movies.Remove(movie);
      await _context.SaveChangesAsync();

      return movie;
    }
  }
}
