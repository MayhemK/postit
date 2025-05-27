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


}