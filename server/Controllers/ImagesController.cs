namespace postit.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImagesController(ImagesService imagesService, Auth0Provider auth0Provider) : ControllerBase
{
  private readonly ImagesService _imagesService = imagesService;
  private readonly Auth0Provider _auth0Provider = auth0Provider;

  [Authorize]
  [HttpPost]
  public async Task<ActionResult<Image>> Create([FromBody] Image imageData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      imageData.CreatorId = userInfo.Id;
      Image image = _imagesService.Create(imageData);
      return Ok(image);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [Authorize]
  [HttpDelete("{imageId}")]
  public async Task<ActionResult<string>> Delete(int imageId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      _imagesService.Delete(imageId, userInfo);
      return Ok("Picture was deleted!");
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}