namespace postit.Services;

public class AlbumService(AlbumsRepository repo)
{
  private readonly AlbumsRepository _repo = repo;

}