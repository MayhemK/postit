namespace postit.Services;

public class ImagesService(ImagesRepository repo, AlbumsService aserv)
{
  private readonly ImagesRepository _repo = repo;
  private readonly AlbumsService _aserv = aserv;

  internal Image Create(Image imageData)
  {
    Album album = _aserv.GetAlbumById(imageData.AlbumId);
    if (album.Archived)
    {
      throw new Exception(album.Title + " is archived and not available to submit images!");
    }
    Image image = _repo.Create(imageData);
    return image;
  }

  internal List<Image> GetImageByAlbumId(int albumId)
  {
    List<Image> images = _repo.GetByAlbumId(albumId);
    return images;
  }

  private Image GetImageById(int imageId)
  {
    Image image = _repo.GetImageById(imageId);
    if (image == null)
    {
      throw new Exception("Invalid picture id: " + imageId);
    }
    return image;
  }

  internal void Delete(int imageId, Account userInfo)
  {
    Image image = GetImageById(imageId);
    if (image.CreatorId != userInfo.Id)
    {
      throw new Exception("You can't delete another user's image!");
    }
    _repo.Delete(imageId);
  }

  internal List<Image> GetAll()
  {
    List<Image> images = _repo.GetAll();
    return images;
  }
}