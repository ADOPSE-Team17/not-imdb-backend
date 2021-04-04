using System.ComponentModel.DataAnnotations;

namespace src
{
  public class Actor
  {
    [Key]
    public int Id { get; set; }

    public Person person { get; set; }
  }
}
