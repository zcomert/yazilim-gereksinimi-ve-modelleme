using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("musics")]
public class MusicsController : ControllerBase
{
    private IRepositoryMethods<Musics> musicRepository;

    public MusicsController(MusicRepository musicRepository)
    {
        this.musicRepository = musicRepository;
    }

    [HttpGet]
    public ActionResult<List<Musics>> GetAll()
    {
        return Ok(musicRepository.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Musics> GetOne(int id)
    {
        var result = musicRepository.GetOne(id);
        if (result != null)
            return Ok(result);
        return NotFound("Music not found!");
    }

    [HttpPost]
    public ActionResult CreateMusic(Musics music)
    {
        musicRepository.Create(music);
        return Ok("New music created!");
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, Musics music)
    {
        musicRepository.Update(id, music);
        return Ok("Music updated!");
    }

    [HttpDelete]
    public ActionResult DeleteAll()
    {
        musicRepository.DeleteAll();
        return Ok("All music list deleted!");
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteOne(int id)
    {
        musicRepository.DeleteOne(id);
        return Ok("Music is deleted!");
    }
}