using System.Security.Cryptography.X509Certificates;

namespace postit.Repositories;

public class AlbumRepository : IRepository<Album>
{
  private readonly IDbConnection _db;
  public AlbumRepository(IDbConnection db)
  {
    _db = db;
  }

  public IEnumerable<Album> GetAll()
  {
    return _db.Query<Album>("SELECT * FROM albums;");
  }

  public Album GetById(int id)
  {
    return _db.QueryFirstOrDefault<Album>("SELECT * FROM albums WHERE id = @id;", new { id });
  }

  public Album Create(Album album)
  {
    string sql = "INSERT INTO albums (title, description, cover_img, category, creator_id) VALUES (@Title, @Description, @CoverImg, @Category, @CreatorId); SELECT LAST_INSERT_ID();";
    int id = _db.ExecuteScalar<int>(sql, album);
    album.Id = id;
    return album;
  }

  public bool Delete(int id)
  {
    string sql = "DELETE FROM albums WHERE id = @Id LIMIT 1;";
    return _db.Execute(sql, new { id }) > 0;
  }

  public Album Update(Album updateData)
  {
    string sql = "UPDATE albums SET id = @Id WHERE id = @Id;";
    _db.Execute(sql, updateData);
    return updateData;
  }
}