namespace postit.Repositories;

public class ImageRepository : IRepository<Image>
{
  private readonly IDbConnection _db;
  public ImageRepository(IDbConnection db)
  {
    _db = db;
  }
}