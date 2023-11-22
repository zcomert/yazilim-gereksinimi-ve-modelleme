using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("musics")]
public class MusicsController : ControllerBase
{
    private MusicRepository musics;

    public MusicsController()
    {
        musics = new MusicRepository();
    }

    [HttpGet]
    public List<Musics> GetAll()
    {
        return musics.GetAll();
    }

    [HttpGet("id")]
    public Musics GetOne(int id)
    {
        return musics.GetOne(id);
    }

}