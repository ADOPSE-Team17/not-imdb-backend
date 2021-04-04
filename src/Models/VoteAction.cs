using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src
{
  public class VoteAction
  {
    [Key]
    public int Id { get; set; }

    public User agent { get; set; }

    public int answer { get; set; }

    [Column(TypeName = "Date")]
    public DateTime dateCreated { get; set; }


    [Column(TypeName = "Date")]
    public DateTime dateModified { get; set; }

  }
}
