using System.ComponentModel.DataAnnotations;

namespace src
{
  public class Director
  {
    [Key]
    public int Id { get; set; }

    public Person person { get; set; }
  }
}
