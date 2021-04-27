using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace src
{
  public class User
  {
    [Key]
    public int Id { get; set; }

    [ForeignKey("Person")]
    public int personId { get; set; }

    public virtual List<Account> accounts { get; set; }

    public virtual Person person { get; set; }

    [Required]
    public string username { get; set; }

    public bool isAdmin { get; set; }

    public bool isActive { get; set; }

    public bool isDisabled { get; set; }

    public bool isDeleted { get; set; }
  }

  public class UserDto
  {
    public int Id { get; set; }
    public Person person { get; set; }
    public string username { get; set; }
    public bool isAdmin { get; set; }
    public bool isActive { get; set; }
    public bool isDisabled { get; set; }

    public bool isDeleted { get; set; }

    public UserDto() { }

    public UserDto(User user)
    {
      Id = user.Id;
      username = user.username;
      person = user.person;
      isActive = user.isActive;
      isAdmin = user.isAdmin;
      isDeleted = user.isDeleted;
      isDisabled = user.isDisabled;
    }
  }
}
