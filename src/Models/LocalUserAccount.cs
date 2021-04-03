using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace src {
  public class LocalUserAccount {
    [Key]
    public string id {get; set;}

    public string password { get; set; }
  }
}
