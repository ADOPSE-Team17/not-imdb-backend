using System.ComponentModel.DataAnnotations;

namespace src {
  public class UserAccount {
    [Key]
    public string id {get; set;}

    public string email {get; set;}
  
    public LocalUserAccount localAccount {get; set;}
  }
}
