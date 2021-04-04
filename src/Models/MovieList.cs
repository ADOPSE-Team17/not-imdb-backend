using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src
{
  public class MovieList
  {
    [Key]
    public int Id { get; set; }

    [ForeignKey("User")]
    public int ownerId {get; set;}

    public virtual User owner { get; set; }

    public virtual List<MovieListItem> items { get; set; }

    public string itemListOrder { get; set; }

    public int numberOfItems { get; set; }

    public string alternateName { get; set; }

    public string additionalType { get; set; }

    public string headline { get; set; }

    public string description { get; set; }
  }
}
