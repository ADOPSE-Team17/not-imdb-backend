using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace src.Controllers
{

  public class CommentsController : ControllerBase
  {
    protected readonly ILogger<CommentsController> _logger;
    protected readonly ApplicationDbContext _context;

    public CommentsController(
      ILogger<CommentsController> logger,
      ApplicationDbContext context,
      string type
    )
    {
      _logger = logger;
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Comment>>> list()
    {

      var comments = await this._context.Comments
        .ToArrayAsync();

      return comments;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Comment>> GetComment(int id)
    {
      var comment = await this._context.Comments
        .Where(m => m.Id == id)
        .FirstOrDefaultAsync();

      if (comment is null)
      {
        return NotFound();
      }

      return comment;
    }


    [HttpPost("{movieId}")]
    public async Task<ActionResult<Comment>> CreateComment(Comment comment, int movieId)
    {
      this._context.Comments.Add(comment);
      await _context.SaveChangesAsync();

      Movie movie = await this._context.Movies
        .Where(m => m.Id == movieId)
        .Include("comments")
        .FirstOrDefaultAsync();

      if (movie is null) {
          return NotFound(new {
              message = "Movie not found!"
          });
      }
      
      try 
      {
        if(movie.comments is null) 
        {
          movie.comments = new List<Comment>();
        }
      
        this._context.Set<Comment>().Attach(comment);
        movie.comments.Add(comment);
      }
      catch 
      {
        NotFound();
      }

      await this._context.SaveChangesAsync();
      return comment;
    }

    [HttpPost("{answer/{commentId}}")]
    public async Task<ActionResult<Comment>> CreateAnswerComment(int commentId, Comment answer) 
    {
      Comment comment = await this._context.Comments
        .Where(m => m.Id == commentId)
        .Include("answers")
        .FirstOrDefaultAsync();

      if (comment is null) {
          return NotFound(new {
              message = "Comment not found!"
          });
      }
      try 
      {
        if (comment.answers is null ) 
          {
              comment.answers = new List<Comment>();
          }
          this._context.Set<Comment>().Attach(answer);
          comment.answers.Add(answer);
      }
      catch 
      {
          return NotFound();
      }
      await this._context.SaveChangesAsync();
      return comment;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Comment>> UpdateComment(int id, Comment comment) 
    {
      if (id != comment.Id)
      {
        return BadRequest();
      }

      _context.Entry(comment).State = EntityState.Modified;
      var localComment = await this._context.Comments.Where(m => m.Id == id).FirstOrDefaultAsync();

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (comment is null)
        {
          return NotFound();
        }
        else
        {
            throw;
        }
      }

      return comment;
    }


    [HttpDelete("{movieId}/remove/{commentId}")]
    public async Task<ActionResult<Movie>> RemoveCommentFromMovie(int movieId, int commentId) 
    {
        Movie movie = await this._context.Movies
            .Where(m => m.Id == movieId)
            .Include("comments")
            .FirstOrDefaultAsync();
        
        if (movie is null) 
        {
            return NotFound(new {
                message = "Movie not found"
            });
        } else if (!(movie.comments.Any(i => i.Id == commentId)))
        {
            return BadRequest(new {
                message = "Comment not found"
            });
        }

        movie.comments = movie.comments.Where( i => i.Id != commentId).ToList();
        await this._context.SaveChangesAsync();
        return movie;
    }

    [HttpDelete("{commentId}/remove/{answerId}")]
    public async Task<ActionResult<Comment>> RemoveAnswerComment(int commentId, int answerId) 
    {
        Comment comment = await this._context.Comments
            .Where(m => m.Id == commentId)
            .Include("answers")
            .FirstOrDefaultAsync();
        if (comment is null)
        {
            return NotFound(new {
                message = "Comment not found"
            });
        } else if (!(comment.answers.Any(i => i.Id == answerId)))
        {
            return BadRequest(new {
                message = "Answer not found"
            });
        }

        comment.answers = comment.answers.Where( i => i.Id != answerId).ToList();
        await this._context.SaveChangesAsync();
        return comment;
    }
  }
}