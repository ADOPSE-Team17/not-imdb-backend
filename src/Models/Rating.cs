using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src
{
  public class Rating
  {
    [Key]
    public int Id { get; set; }

    [ForeignKey("Movie")]
    public int reviewAspect { get; set; }

    public User author { get; set; }

    public int ratingValue { get; set; }
  }
}
