namespace postit.Repositories;

public class WatcherRepository(IDbConnection db)
{
  private readonly IDbConnection _db = db;

  internal WatcherProfile CreateWatcher(Watcher watcherData)
  {
    string sql = @"
    INSERT INTO
    watchers(album_id, account_id)
    VALUES (@AlbumId, @AccountId);
    
    SELECT
    watcher.*,
    accounts.*
    FROM watchers
    INNER JOIN accounts ON accounts.id = watchers.account_id
    WHERE watchers.id = LAST_INSERT_ID();";

    WatcherProfile watcherProfile = _db.Query(sql, (Watcher watcher, WatcherProfile profile) =>
    {
      profile.AlbumId = watcher.AlbumId;
      profile.WatcherId = watcher.Id;
      return profile;
    }, watcherData).SingleOrDefault();
    return watcherProfile;
  }
}