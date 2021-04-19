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

    [HttpDelete("{id}")]
    public new async Task<ActionResult<MovieList>> DeleteMovieList(int id) 
    {
        return await base.DeleteMovieList(id);
    }

  }
}