namespace postit.Services;

public class ImagesService(ImagesRepository repo)
{
  private readonly ImagesRepository _repo = repo;
}