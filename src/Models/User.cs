using System.Collections.Generic;
// using System.Data.Entity.Core;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace src
{
  public class User
  {
    [Key]
    public string id { get; set; }

    public List<UserAccount> accounts { get; set; }

    public int personId { get; set; }

    public string username { get; set; }

    public bool isAdmin { get; set; }
  }
}
