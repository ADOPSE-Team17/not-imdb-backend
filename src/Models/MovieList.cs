using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace src
{
  public class MovieList
  {
    [Key]
    public int Id { get; set; }

    public User owner { get; set; }

    public List<MovieListItem> items { get; set; }

    public string itemListOrder { get; set; }

    public int numberOfItems { get; set; }

    public string alternateName { get; set; }

    public string additionalType { get; set; }

    public string headline { get; set; }

    public string description { get; set; }
  }
}
