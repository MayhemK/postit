namespace postit.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlbumsController(AlbumsService albumsService, Auth0Provider auth0Provider, ImagesService imagesService) : ControllerBase
{
  private readonly AlbumsService _albumsService = albumsService;
  private readonly Auth0Provider _auth0Provider = auth0Provider;
  private readonly ImagesService _imagesService = imagesService;
  // TODO add watcher service

  [Authorize]
  [HttpPost]
  public async Task<ActionResult<Album>> Create([FromBody] Album albumData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      albumData.CreatorId = userInfo.Id;
      Album album = _albumsService.Create(albumData);
      return Ok(album);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet]
  public ActionResult<List<Album>> GetAlbums([FromQuery] string category)
  {
    try
    {
      List<Album> albums;
      if (category == null)
      {
        albums = _albumsService.GetAlbums();
      }
      else
      {
        albums = _albumsService.GetAlbums(category);
      }
      return Ok(albums);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{albumId}")]
  public ActionResult<Album> GetAlbumById(int albumId)
  {
    try
    {
      Album album = _albumsService.GetAlbumById(albumId);
      return Ok(album);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [Authorize]
  [HttpDelete("{albumId}")]
  public async Task<ActionResult<Album>> ArchiveAlbum(int albumId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Album album = _albumsService.ArchiveAlbum(albumId, userInfo);
      return Ok(album);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{albumId}/pictures")]
  public ActionResult<List<Image>> GetPicturesByAlbumId(int albumId)
  {
    try
    {
      List<Image> images = _imagesService.GetImageByAlbumId(albumId);
      return Ok(images);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  // [HttpGet("{albumId}/watchers")]
  // public ActionResult<List<watcherProfile>> GetWatcherProfileByAlbumId(int albumId)
  // {
  //   try
  //   {
  //     List<WatcherProfile> watcherProfiles = _watcherService.GetWatcherProfilesByAlbumId(albumId);
  //     return Ok(watcherProfiles);
  //   }
  //   catch (Exception exception)
  //   {
  //     return BadRequest(exception.Message);
  //   }
  // }
}