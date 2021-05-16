using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace src.Controllers
{
  [Authorize(Roles = "admin,user")]
  [ApiController]
  [Route("[controller]")]
  public class MeController : ControllerBase
  {
    private readonly ILogger<MeController> _logger;
    private readonly ApplicationDbContext _context;


    public MeController(
      ILogger<MeController> logger,
      ApplicationDbContext context
    )
    {
      _logger = logger;
      _context = context;
    }
    
    [HttpGet("profile")]
    public async Task<ActionResult<Person>> GetProfile()
    {
        var user = this.HttpContext.Items["User"] as User;
        return user.person;
    }

    [HttpGet("watchlist")]
    public async Task<ActionResult<MovieList>> GetWatchlist()
    {
        var user = this.HttpContext.Items["User"] as User;
        var watclist = await this._context.MovieLists
          .Include("items")
          .Where(w => w.ownerId == user.Id)
          .FirstOrDefaultAsync();
        
        return watclist;
    }

    [HttpGet("favorite")]
    public async Task<ActionResult<MovieList>> GetFavorite()
    {
        var user = this.HttpContext.Items["User"] as User;
        var favorite = await this._context.MovieLists
          .Include("items")
          .Where(w => w.ownerId == user.Id)
          .FirstOrDefaultAsync();
        
        return favorite;
    }

  }
}