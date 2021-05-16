using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace src.Controllers
{

  public class MovieListsController : ControllerBase
  {
    protected readonly ILogger<MovieListsController> _logger;
    protected readonly ApplicationDbContext _context;
    protected readonly string additionalType;


    public MovieListsController(
      ILogger<MovieListsController> logger,
      ApplicationDbContext context,
      string type
    )
    {
      _logger = logger;
      _context = context;
      additionalType = type;
    }

    [ApiExplorerSettings(IgnoreApi=true)]
    public async Task<ActionResult<IEnumerable<MovieList>>> list()
    {

      var lists = await this._context.MovieLists
        .Where(m=>m.additionalType==this.additionalType) 
        .Include("items")
        .ToArrayAsync();

      return lists;
    }

    [ApiExplorerSettings(IgnoreApi=true)]
    public async Task<ActionResult<MovieList>> GetMovieList(int id)
    {
      var list = await this._context.MovieLists
        .Where(m => m.Id == id && m.additionalType==this.additionalType)
        .Include("items")
        .FirstOrDefaultAsync();

      if (list is null)
      {
        return NotFound();
      }

      return list;
    }

    [ApiExplorerSettings(IgnoreApi=true)]
    public async Task<ActionResult<MovieList>> CreateMovieList(MovieList list)
    {
      var user = this.HttpContext.Items["User"] as User;

      list.additionalType = this.additionalType;
      this._context.MovieLists.Add(list);
      list.ownerId = user.Id;
      
      await _context.SaveChangesAsync();
      return list;
    }

    [ApiExplorerSettings(IgnoreApi=true)]
    public async Task<ActionResult<MovieList>> UpdateMovieList(int id, MovieList list)
    {

      if (id != list.Id)
      {
        return BadRequest();
      }

      _context.Entry(list).State = EntityState.Modified;
      var localList = await this._context.MovieLists.Where(m => m.Id == id && m.additionalType==this.additionalType).FirstOrDefaultAsync();

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

    [ApiExplorerSettings(IgnoreApi=true)]
    public async Task<ActionResult<MovieList>> DeleteMovieList(int id)
    {
      var list = await _context.MovieLists.Where(m => m.Id == id && m.additionalType==this.additionalType).Include("items").FirstOrDefaultAsync();

      if (list == null)
      {
        return NotFound();
      }

      if (!(list.items is null)) {
        list.items.ForEach(i => this._context.Entry(i).State = EntityState.Deleted);
      }
      this._context.Entry(list).State = EntityState.Deleted;;
      await _context.SaveChangesAsync();

      return list;
    }
  }
}