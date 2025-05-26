namespace postit.Repositories;

public class ImageRepository
{
  private readonly IDbConnection _db;
  public ImageRepository(IDbConnection db)
  {
    _db = db;
  }

  // public List<Image> GetAll()
  // {
  //   return _db.Query<Image>("SELECT * FROM images;");
  // }

  public List<Image> GetByAlbumId(int albumId)
  {
    string sql = @"
    SELECT
    images.*,
    accounts.*
    FROM images
    INNER JOIN accounts ON accounts.id = images.creator_id
    WHERE images.album_id = @albumId;";

    List<Image> images = _db.Query(sql, (Image image, Profile account) =>
    {
      image.Creator = account;
      return image;
    }, new { albumId }).ToList();
    return images;
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

  public Image GetPictureById(int imageId)
  {
    string sql = "SELECT * FROM images WHERE id = @imageId;";
    Image foundImage = _db.Query<Image>(sql, new { imageId }).SingleOrDefault();
    return foundImage;
  }

  public bool Delete(int id)
  {
    string sql = "DELETE FROM images WHERE id = @Id LIMIT 1;";
    return _db.Execute(sql, new { id }) > 0;
  }

  // public Image Update(Image updateData)
  // {
  //   string sql = "UPDATE images SET id = @Id;";
  //   _db.Execute(sql, updateData);
  //   return updateData;
  // }
}