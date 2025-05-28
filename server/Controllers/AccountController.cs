namespace postit.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AccountController(AccountService accountService, Auth0Provider auth0Provider, WatchersService watchersService) : ControllerBase
{
  private readonly AccountService _accountService = accountService;
  private readonly Auth0Provider _auth0Provider = auth0Provider;
  private readonly WatchersService _watchersService = watchersService;

  [HttpGet]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateAccount(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("watchers")]
  public async Task<ActionResult<List<WatcherAlbum>>> GetMyWatcherAlbums()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<WatcherAlbum> watcherAlbums = _watchersService.GWABAI(userInfo.Id);
      return Ok(watcherAlbums);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}
