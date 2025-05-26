namespace postit.Repositories;

public class ImageRepository : IRepository<Image>
{
  private readonly IDbConnection _db;
  public ImageRepository(IDbConnection db)
  {
    _db = db;
  }

  public IEnumerable<Image> GetAll()
  {
    return _db.Query<Image>("SELECT * FROM images;");
  }

  public Image GetById(int id)
  {
    return _db.QueryFirstOrDefault<Image>("SELECT * FROM images WHERE id = @Id;", new { id });
  }

  public Image Create(Image imageData)
  {
    string sql = @"INSERT INTO
    images (creator_id, album_id, img_url)
    VALUES (@CreatorId, @AlbumId, @ImgUrl); 
    
    SELECT images.*,
    accounts.*
    FROM images
    INNER JOIN accounts on accounts.id = images.creator_id
    WHERE images.id = LAST_INSERT_ID();";

    Image createdImage = _db.Query(sql, (Image image, Account account) =>
    {
      image.Creator = account;
      return image;
    }, imageData).SingleOrDefault();
    return createdImage;
  }

  public bool Delete(int id)
  {
    string sql = "DELETE FROM images WHERE id = @Id LIMIT 1;";
    return _db.Execute(sql, new { id }) > 0;
  }

  public Image Update(Image updateData)
  {
    string sql = "UPDATE images SET id = @Id;";
    _db.Execute(sql, updateData);
    return updateData;
  }
}