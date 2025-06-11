namespace postit.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WatchersController(WatchersService watchersService, Auth0Provider auth0Provider) : ControllerBase
{
  private readonly WatchersService _watchersService = watchersService;
  private readonly Auth0Provider _auth = auth0Provider;

  [Authorize]
  [HttpPost]
  public async Task<ActionResult<WatcherProfile>> CreateWatcher([FromBody] Watcher watcherData)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      watcherData.AccountId = userInfo.Id;
      WatcherProfile watcher = _watchersService.CreateWatcher(watcherData);
      return Ok(watcher);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [Authorize]
  [HttpDelete("{watcherId}")]
  public async Task<ActionResult<string>> DeleteWatcher(int watcherId)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      _watchersService.DeleteWatcher(watcherId, userInfo);
      return Ok("Deleted Watcher");
    }
    catch (Exception exception)
    {
      Console.WriteLine($"Error deleting watcher: {exception.Message}");
      return BadRequest(exception.Message);
    }
  }
}