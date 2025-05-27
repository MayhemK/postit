namespace postit.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlbumsController(AlbumsService albumsService, Auth0Provider auth0Provider, ImagesService imagesService) : ControllerBase
{
  private readonly AlbumsService _albumsService = albumsService;
  private readonly Auth0Provider _auth0Provider = auth0Provider;
  private readonly ImagesService _imagesService = imagesService;
  // TODO add watcher service


}