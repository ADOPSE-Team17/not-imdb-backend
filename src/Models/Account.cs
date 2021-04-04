using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src
{
  public class Account
  {
    [Key]
    public int Id { get; set; }

    [ForeignKey("User")]
    public int userId { get; set; }
    public string email { get; set; }

    public string additionalType { get; set; }

    public string password { get; set; }
  }
}
