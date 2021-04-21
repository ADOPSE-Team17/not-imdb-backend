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
  public class FavoritesListController : MovieListsController
  {

    public FavoritesListController(
      ILogger<FavoritesListController> logger,
      ApplicationDbContext context
    ):base(logger,context,MovieList.FAVORITES)
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

    [HttpDelete("{id}")]
    public new async Task<ActionResult<MovieList>> DeleteMovieList(int id)
    {
        return await base.DeleteMovieList(id);
    }

    [HttpPost("{id}")]
    public async Task<ActionResult<MovieList>> AddMovieListItem(int id, MovieListItem item)
    {
      
      MovieList list = await this._context.MovieLists
        .Where(m => m.Id == id && m.additionalType.Equals(MovieList.FAVORITES))
        .Include("items")
        .FirstOrDefaultAsync();
        
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
    
    [HttpDelete("{listId}/remove/{movieId}")]
    public async Task<ActionResult<MovieList>> RemoveListItem(int listId, int movieId) {
      MovieList list = await this._context.MovieLists
        .Where(m => m.Id == listId && m.additionalType.Equals(MovieList.FAVORITES))
        .Include("items")
        .FirstOrDefaultAsync();
      
      if (list is null) {
        return NotFound(new {
          message = "favorites  list was not found"
        });
      } else if (!(list is null) && !(list.items.Any(i => i.movieId == movieId))) {
        return BadRequest(new {
          message = "Movie is not in the list"
        });
      }

      list.items = list.items.Where( i => i.movieId != movieId).ToList();
      await this._context.SaveChangesAsync();
      return list;
    }
  }
}