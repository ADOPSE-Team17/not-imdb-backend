using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src
{
  public class Question
  {

    public static readonly string POLL = "poll";
    public static readonly string GAME = "game";

    [Key]
    public int Id { get; set; }

    public virtual List<VoteAction> answers { get; set; }

    public string additionalType { get; set; }

    public string alternateName { get; set; }

    public string title { get; set; }

    public string description { get; set; }

    public string optionSet { get; set; }

    public int correctAnswer { get; set; }

    [Column(TypeName = "Date")]
    public DateTime startDate { get; set; }

    [Column(TypeName = "Date")]
    public DateTime endDate { get; set; }

    [Column(TypeName = "Date")]
    public DateTime datePublished { get; set; }

    [Column(TypeName = "Date")]
    public DateTime dateCreated { get; set; }


    [Column(TypeName = "Date")]
    public DateTime dateModified { get; set; }
  }

  public class QuestionUpdateDto
  {
    public int Id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public int correctAnswer { get; set; }
    public DateTime startDate { get; set; }

    public DateTime endDate { get; set; }

    public DateTime datePublished { get; set; }
  }
}
