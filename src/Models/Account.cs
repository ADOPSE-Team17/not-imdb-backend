using System.ComponentModel.DataAnnotations;

namespace src
{
  public class Account
  {
    [Key]
    public int Id { get; set; }

    public string email { get; set; }

    public string additionalType { get; set; }

    public string password { get; set; }
  }
}
