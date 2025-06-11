namespace postit.Models;

public class Watcher
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string AccountId { get; set; }
  public int AlbumId { get; set; }
}

public class WatcherProfile : Account
{
  public int WatcherId { get; set; }
  public int AlbumId { get; set; }
  public string AccountId { get; set; }
}

public class WatcherAlbum : Album
{
  public int WatcherId { get; set; }
  public string AccountId { get; set; }
}