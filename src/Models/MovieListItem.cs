using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src
{
  public class MovieListItem
  {
    [Key]
    public int id { get; set; }

    [ForeignKey("MovieList")]
    public int parentListId { get; set; }

    [ForeignKey("Movie")]
    public int movieId { get; set; }

    public virtual Movie item { get; set; }

    public int order { get; set; }
  }
}
