using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src
{
  public class Question
  {
    [Key]
    public int Id { get; set; }

    public List<VoteAction> answers { get; set; }

    public string additionalType { get; set; }

    public string alternateName { get; set; }

    public string title { get; set; }

    public string description { get; set; }

    public string optionSet { get; set; }

    [Column(TypeName = "Date")]
    public DateTime dateCreated { get; set; }


    [Column(TypeName = "Date")]
    public DateTime dateModified { get; set; }
  }
}
