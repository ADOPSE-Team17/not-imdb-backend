using System.ComponentModel.DataAnnotations;

namespace src
{
  public class Product
  {
    [Key]
    public int Id { get; set; }

    public string headline { get; set; }

    public string description { get; set; }

    public string image { get; set; }

    public string url { get; set; }
  }
}
