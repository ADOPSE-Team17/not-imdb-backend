using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src
{
  public class Event
  {
    [Key]
    public int Id { get; set; }

    public string additionalType { get; set; }

    public string alternateName { get; set; }

    public string headline { get; set; }

    public string alternativeHeadline { get; set; }

    public string description { get; set; }

    public string image { get; set; }

    public string url { get; set; }

    public string organizer { get; set; }

    [Column(TypeName = "Date")]
    public DateTime doorTime { get; set; }

    [Column(TypeName = "Date")]
    public DateTime startDate { get; set; }

    [Column(TypeName = "Date")]
    public DateTime endDate { get; set; }

    public double duration { get; set; }

    public string eventAttendanceMode { get; set; }

    public string eventStatus { get; set; }

    public string inLanguage { get; set; }

    public bool isAccessibleForFree { get; set; }

    public string location { get; set; }

    public int maximumAttendeeCapacity { get; set; }
  }
}
