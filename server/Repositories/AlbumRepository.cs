using System.Security.Cryptography.X509Certificates;

namespace postit.Repositories;

public class AlbumRepository : IRepository<Album>
{
  private readonly IDbConnection _db;
  public AlbumRepository(IDbConnection db)
  {
    _db = db;
  }
}