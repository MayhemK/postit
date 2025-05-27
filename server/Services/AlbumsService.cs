namespace postit.Services;

public class AlbumsService(AlbumsRepository repo)
{
  private readonly AlbumsRepository _repo = repo;


  internal Album Create(Album albumData)
  {
    Album album = _repo.Create(albumData);
    return album;
  }

  internal List<Album> GetAlbums()
  {
    List<Album> albums = _repo.GetAll();
    return albums;
  }

  internal List<Album> GetAlbums(string category)
  {
    List<Album> albums = _repo.GetAlbumsByCategory(category);
    return albums;
  }

  internal Album GetAlbumById(int albumId)
  {
    Album album = _repo.GetById(albumId);
    if (album == null)
    {
      throw new Exception("No album found with the id of" + albumId);
    }
    return album;
  }

  internal Album ArchiveAlbum(int albumId, Account userInfo)
  {
    Album album = GetAlbumById(albumId);
    if (album.CreatorId != userInfo.Id)
    {
      throw new Exception("You do not have permission to archive another user's album");
    }
    album.Archived = !album.Archived;

    _repo.ArchiveAlbum(album);
    return album;
  }
}