using System.ComponentModel.DataAnnotations;

namespace src
{
  public class MovieListItem
  {
    [Key]
    public int id { get; set; }

    public MovieList parentList { get; set; }

    public Movie item { get; set; }

    public int order { get; set; }
  }
}
