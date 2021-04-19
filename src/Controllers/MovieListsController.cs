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
  public class MovieListsController : ControllerBase
  {
    private readonly ILogger<MovieListsController> _logger;
    private readonly ApplicationDbContext _context;


    public MovieListsController(
      ILogger<MovieListsController> logger,
      ApplicationDbContext context
    )
    {
      _logger = logger;
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieList>>> list()
    {

      var lists = await this._context.MovieLists
        .Include("user")
        .ToArrayAsync();

      return lists;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MovieList>> GetMovieList(int id)
    {
      var list = await this._context.MovieLists
        .Include("user")
        .Where(m => m.Id == id)
        .FirstOrDefaultAsync();

      if (list is null)
      {
        return NotFound();
      }

      return list;
    }

    [HttpPost]
    public async Task<ActionResult<MovieList>> CreateMovieList(MovieList list)
    {
      this._context.MovieLists.Add(list);
      await _context.SaveChangesAsync();
      return list;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MovieList>> UpdateMovieList(int id, MovieList list)
    {

      if (id != list.Id)
      {
        return BadRequest();
      }

      _context.Entry(list).State = EntityState.Modified;
      var localList = await this._context.MovieLists.Where(m => m.Id == id).FirstOrDefaultAsync();

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (list is null)
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return list;

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<MovieList>> DeleteMovieList(int id)
    {
      var list = await _context.MovieLists.FindAsync(id);
      if (list == null)
      {
        return NotFound();
      }

      _context.MovieLists.Remove(list);
      await _context.SaveChangesAsync();

      return list;
    }
  }
}