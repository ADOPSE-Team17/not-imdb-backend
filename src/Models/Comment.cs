using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src
{
  public class Comment
  {
    [Key]
    public int Id { get; set; }

    public User creator { get; set; }

    [ForeignKey("Movie")]
    public int about { get; set; }

    public string commentText { get; set; }

    [Column(TypeName = "Date")]
    public DateTime dateCreated { get; set; }


    [Column(TypeName = "Date")]
    public DateTime dateModified { get; set; }
  }
}
