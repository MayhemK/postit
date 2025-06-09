

namespace postit.Repositories;

public class ImagesRepository
{
  private readonly IDbConnection _db;
  public ImagesRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<Image> GetAll()
  {
    string sql = @"
    SELECT
    images.*,
    accounts.*
    FROM images
    INNER JOIN accounts ON accounts.id = images.creator_id;";

    List<Image> images = _db.Query(sql, (Image image, Account account) =>
    {
      image.Creator = account;
      return image;
    }).ToList();
    return images;
  }

  internal List<Image> GetByAlbumId(int albumId)
  {
    string sql = @"
    SELECT
    images.*,
    accounts.*
    FROM images
    INNER JOIN accounts ON accounts.id = images.creator_id
    WHERE images.album_id = @albumId;";

    List<Image> images = _db.Query(sql, (Image image, Account account) =>
    {
      image.Creator = account;
      return image;
    }, new { albumId }).ToList();
    return images;
  }

  internal Image Create(Image imageData)
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

  internal Image GetImageById(int imageId)
  {
    string sql = "SELECT * FROM images WHERE id = @imageId;";
    Image foundImage = _db.Query<Image>(sql, new { imageId }).SingleOrDefault();
    return foundImage;
  }

  internal bool Delete(int id)
  {
    string sql = "DELETE FROM images WHERE id = @Id LIMIT 1;";
    return _db.Execute(sql, new { id }) > 0;
  }

  internal void IncreaseViews(Image image)
  {
    string sql = @"
    UPDATE images
    SET views = @Views
    WHERE id = @Id LIMIT 1;";
    int rowsAffected = _db.Execute(sql, image);

    if (rowsAffected != 1)
    {
      throw new Exception(rowsAffected + " rows were affected and that is bad");
    }
  }

}