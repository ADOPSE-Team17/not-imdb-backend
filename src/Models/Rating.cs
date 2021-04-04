using System.ComponentModel.DataAnnotations;

namespace src
{
  public class Rating
  {
    [Key]
    public int Id { get; set; }

    public User author { get; set; }

    public int ratingValue { get; set; }
  }
}
