namespace postit.Services;

public class WatchersService(WatchersRepository repository)
{
  private readonly WatchersRepository _repo = repository;

  internal Watcher CreateWatcher(Watcher watcherData)
  {
    Watcher watcher = _repo.CreateWatcher(watcherData);
    return watcher;
  }

  internal List<WatcherProfile> GWPBAI(int albumId)
  {
    List<WatcherProfile> watcherProfiles = _repo.GetWatcherProfilesByAlbumId(albumId);
    return watcherProfiles;
  }

  internal List<WatcherAlbum> GWABAI(string accountId)
  {
    List<WatcherAlbum> watcherAlbums = _repo.GWABAI(accountId);
    return watcherAlbums;
  }

  private Watcher GetWatcherById(int watcherId)
  {
    Watcher watcher = _repo.GWBI(watcherId);
    if (watcher == null)
    {
      Console.WriteLine($"Watcher with ID {watcherId} not found.");
      throw new Exception("Invalid watcher Id");
    }
    return watcher;
  }

  internal void DeleteWatcher(int watcherId, Account userInfo)
  {
    Watcher watcher = GetWatcherById(watcherId);
    if (watcher.AccountId != userInfo.Id)
    {
      throw new Exception("You may not delete another user's watcher");
    }
    _repo.DeleteWatcher(watcherId);
  }
}