using YoutubeApp.Models;

namespace YoutubeApp.Data;

public class VideoRepository
{
    // CRUD
    // Create
    // Read - Retrieve
    // UPDATE
    // Delete

    private List<Video> playList;
    public VideoRepository()
    {
        playList = new List<Video>()
        {
            new Video
            {
                Id=201,
                Title = "Yazılım Gereksinimi ve Modelleme",
                Duration = 60,
                Category = new Category(){CategoryId=2, CategoryName="Yazılım"}
            }
        };
        playList.Add(new Video
        {
            Id = 101,
            Title = "Nesne Yönelimli Programlama",
            Duration = 60,
            Category = new Category() { CategoryId = 1, CategoryName = "Eğitim" }
        });
    }

    public List<Video> GetAllVideo()
    {
       return playList;
    }

    public Video GetOneVideo(int id)
    {
        foreach (var item in playList)
        {
            if (item.Id==id)
            {
                return item;
            }
        }
        throw new Exception();
    }
    public void CreateOneVideo(Video video)
    {
        throw new NotImplementedException();
    }
    public void UpdateOneVideo(int id, Video video)
    {
        throw new NotImplementedException();
    }
    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}