using Microsoft.AspNetCore.Mvc;
using YoutubeApp.Data;
using YoutubeApp.Models;

namespace YoutubeApp.Controllers;

[ApiController]
[Route("api/videos")]
public class VideosController : ControllerBase
{
    private readonly VideoRepository _videoRepository;

    public VideosController(VideoRepository videoRepository)
    {
        _videoRepository = videoRepository;
    }

    [HttpGet] // localhost/api/videos
    public List<Video> GetAllVideos()
    {
        return _videoRepository.GetAllVideo();
    }

    [HttpGet("{id:int}")] // localhost/api/videos/:id
    public Video GetOneVideo(int id)
    {
        return _videoRepository.GetOneVideo(id);
    }

    [HttpPut("{id:int}")] // localhost/api/videos/:id
    public void UpdateOneVideo(int id, Video video)
    {
        _videoRepository.UpdateOneVideo(id, video);
    }

    [HttpPost] // localhost/api/videos
    public void CreateOneVideo(Video video)
    {
        _videoRepository.CreateOneVideo(video);
    }

    [HttpDelete("{id:int}")] // localhost/api/videos/:id
    public void DeleteOneVideo(int id)
    {
        _videoRepository.Delete(id);
    }


}