using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace src
{
  public class User
  {
    [Key]
    public int Id { get; set; }

    public List<Account> accounts { get; set; }

    public Person person { get; set; }

    public string username { get; set; }

    public bool isAdmin { get; set; }

    public bool isActive { get; set; }

    public bool isDisabled { get; set; }

    public bool isDeleted { get; set; }
  }
}
