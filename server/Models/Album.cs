using System.ComponentModel.DataAnnotations;

public class Album
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  [MinLength(3), MaxLength(25)] public string Title { get; set; }
  [MinLength(15), MaxLength(250)] public string Description { get; set; }
  [Url, MaxLength(2000)] public string CoverImg { get; set; }
  public bool Archived { get; set; }
  public string Category { get; set; }
  public Account Creator { get; set; }
  public string CreatorId { get; set; }
  public int WatcherCount { get; set; }

}

public enum Category
{
  Aesthetics,
  Food,
  Games,
  Animals,
  Vibes,
  Misc
}