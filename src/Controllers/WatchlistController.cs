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
  public class WatchlistController : MovieListsController
  {

    public WatchlistController(
      ILogger<WatchlistController> logger,
      ApplicationDbContext context
    ):base(logger,context,MovieList.WATCHLIST)
    {

    }

    [HttpGet]
    public new async Task<ActionResult<IEnumerable<MovieList>>> list()
    {
        return await base.list();
    }

    [HttpGet("{id}")]
    public new async Task<ActionResult<MovieList>> GetMovieList(int id)
    {
        return await base.GetMovieList(id);
    }

    [HttpPost]
    public new async Task<ActionResult<MovieList>> CreateMovieList(MovieList list)
    {
        return await base.CreateMovieList(list);
    }

    [HttpPut("{id}")]
    public new async Task<ActionResult<MovieList>> UpdateMovieList(int id, MovieList list)
    {
        return await base.UpdateMovieList(id, list);
    }

    [HttpPatch("{id}")]
    public new async Task<ActionResult<MovieList>> DeleteMovieList(int id)
    {
        return await base.DeleteMovieList(id);
    }

    [HttpPost("{id}")]
    public async Task<ActionResult<MovieList>> AddMovieListItem(int id, MovieListItem item)
    {
      
      MovieList list = this._context.MovieLists.Where(m => m.Id == id && m.additionalType == this.additionalType).FirstOrDefault();
      if (list is null) 
      {
        return NotFound();
      }

      try
      {
        if (list.items is null) 
        {
          list.items = new List<MovieListItem>(); 
        }
        this._context.Set<MovieListItem>().Attach(item);
        if (list.items.Any(m => m.movieId == item.movieId)) 
        {
          return Conflict(new {
            message = "movie already exists"
          });
        }
        list.items.Add(item);
      } 
      catch 
      {
        return NotFound();
      } 

      await this._context.SaveChangesAsync();
      return list;
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<MovieList>> RemoveMovieListItem(int id, MovieListItem item)
    {
      MovieList list = this._context.MovieLists.Where(m => m.Id == id && m.additionalType == this.additionalType).FirstOrDefault();
      if (list is null) 
      {
        return NotFound();
      }
      try
      {
        if (list.items is null) 
        {
          return Conflict(new {
            message = "the list is empty"
          });
        }
        if (!list.items.Any(m => m.movieId == item.movieId)) 
        {
          return Conflict(new {
            message = "item doesn't exists"
          });
        }
        list.items.Remove(item);
      }
      catch
      {
        return NotFound();
      }
      await this._context.SaveChangesAsync();
      return list;
    }
  }
}