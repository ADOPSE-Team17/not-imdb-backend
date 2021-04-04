using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src
{
  public class Movie
  {
    [Key]
    public int Id { get; set; }

    [ForeignKey("Movie")]
    public int isPartOf { get; set; }

    public virtual Movie parentMovie {get; set;}

    public virtual List<Comment> comments { get; set; }

    public virtual List<Rating> ratings { get; set; }

    public virtual List<Event> events { get; set; }

    public virtual List<Product> products { get; set; }

    public string additionalType { get; set; }

    public string headline { get; set; }

    public string alternativeHeadline { get; set; }

    public string trailerUrl { get; set; }

    public string about { get; set; }

    public string abstractText { get; set; }

    public string musicBy { get; set; }

    public string producer { get; set; }

    public double duration { get; set; }

    [Column(TypeName = "Date")]
    public DateTime datePublished { get; set; }

    public string locationCreated { get; set; }

    public string contentRating { get; set; }

    public string copyrightHolder { get; set; }

    public string copyrightYear { get; set; }

    public string creator { get; set; }

    public string inLanguage { get; set; }

    public bool isFamilyFriendly { get; set; }

    [Column(TypeName = "Date")]
    public DateTime dateCreated { get; set; }


    [Column(TypeName = "Date")]
    public DateTime dateModified { get; set; }
  }
}
