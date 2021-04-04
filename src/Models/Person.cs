using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src
{
  public class Person
  {
    [Key]
    public int Id { get; set; }

    public string alternateName { get; set; }

    public string familyName { get; set; }

    public string givenName { get; set; }

    public string additionalName { get; set; }

    public string address { get; set; }

    [Column(TypeName = "Date")]
    public DateTime birthDate { get; set; }

    public string gender { get; set; }

    public string description { get; set; }

    public string image { get; set; }
  }
}
