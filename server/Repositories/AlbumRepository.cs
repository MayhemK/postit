using System.Security.Cryptography.X509Certificates;

namespace postit.Repositories;

public class AlbumRepository
{
  private readonly IDbConnection _db;
  public AlbumRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<Album> GetAll()
  {
    string sql = @"
    SELECT
    albums.*,
    accounts.*
    FROM albums
    INNER JOIN accounts on accounts.id = albums.creator_id;";
    List<Album> albums = _db.Query(sql, (Album album, Profile account) =>
    {
      album.Creator = account;
      return album;
    }).ToList();

    return albums;
  }

  public Album GetById(int id)
  {
    string sql = @"
    SELECT 
    albums.*,
    accounts.*
    FROM albums
    INNER JOIN accounts ON accounts.id = albums.creator_id
    WHERE albums.id = @id;";
    Album foundAlbum = _db.Query(sql, (Album album, Profile account) =>
    {
      album.Creator = account;
      return album;
    }, new { id }).SingleOrDefault();
    return foundAlbum;
  }

  public Album Create(Album albumData)
  {
    string sql = @"INSERT INTO albums 
    (title, description, cover_img, category, creator_id)
    VALUES 
    (@Title, @Description, @CoverImg, @Category, @CreatorId);
    SELECT albums.*, accounts.* FROM albums INNER JOIN accounts on accounts.id = albums.creator_id WHERE albums.id = LAST_INSERT_ID(); ";
    Album createdAlbum = _db.Query(sql, (Album album, Profile account) =>
    {
      album.Creator = account;
      return album;
    }, albumData).SingleOrDefault();
    return createdAlbum;
  }

  //   public bool Delete(int id)
  //   {
  //     string sql = "DELETE FROM albums WHERE id = @Id LIMIT 1;";
  //     return _db.Execute(sql, new { id }) > 0;
  //   }

  //   public Album Update(Album updateData)
  //   {
  //     string sql = "UPDATE albums SET id = @Id WHERE id = @Id;";
  //     _db.Execute(sql, updateData);
  //     return updateData;
  //   }
  // }

  public void ArchiveAlbum(Album album)
  {
    string sql = "UPDATE albums SET archived = @Archived WHERE id = @id LIMIT 1;";
    int rowsAffected = _db.Execute(sql, album);
    switch (rowsAffected)
    {
      case 1:
        return;
      case 0:
        throw new Exception("Update failed!");
    }
  }

  public List<Album> GetAlbumsByCategory(string category)
  {
    string sql = @"
    SELECT
    albums.*,
    accounts.*
    FROM albums
    INNER JOIN accounts ON accounts.id = albums.creator_id
    WHERE albums.category LIKE @Category;";
    List<Album> albums = _db.Query(sql, (Album album, Profile account) =>
    {
      album.Creator = account;
      return album;
    }, new { category = $"%{category}%" }).ToList();
    return albums;
  }

}