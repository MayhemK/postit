namespace postit.Repositories;

public class WatchersRepository(IDbConnection db)
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

  internal List<WatcherProfile> GetWatcherProfilesByAlbumId(int albumId)
  {
    string sql = @"
    SELECT
    watchers.*,
    accounts.*
    FROM watchers
    INNER JOIN accounts ON account.id = watchers.account_id
    WHERE watchers.album_id = @albumId;";
    List<WatcherProfile> watcherProfiles = _db.Query(sql, (Watcher watcher, WatcherProfile account) =>
    {
      account.AlbumId = watcher.AlbumId;
      account.WatcherId = watcher.Id;
      return account;
    }, new { albumId }).ToList();
    return watcherProfiles;
  }

  internal List<WatcherAlbum> GWABAI(string accountId)
  {
    string sql = @"
    SELECT
    watchers.*,
    albums.*,
    accounts.*
    FROM watchers
    INNER JOIN albums ON albums.id = watcher.album_id
    INNER JOIN accounts ON accounts.id = albums.creator_id
    WHERE watchers.account_id = @accountId;";
    List<WatcherAlbum> watcherAlbums = _db.Query(sql, (Watcher watcher, WatcherAlbum album, Account account) =>
    {
      album.AccountId = watcher.AccountId;
      album.WatcherId = watcher.Id;
      album.Creator = account;
      return album;
    }, new { accountId }).ToList();
    return watcherAlbums;
  }

  internal Watcher GWBI(int watcherId)
  {
    string sql = "SELECT * FROM watchers WHERE id = @watcherId;";
    Watcher watcher = _db.Query<Watcher>(sql, new { watcherId }).SingleOrDefault();
    return watcher;
  }

  internal void DeleteWatcher(int watcherId)
  {
    string sql = "DELETE FROM watchers WHERE id = @watcherId LIMIT 1;";
    int rowsAffected = _db.Execute(sql, new { watcherId });
    if (rowsAffected == 1) return;
    throw new Exception(rowsAffected + " Rows were affected, fix yo stuff buddy boi");
  }
}