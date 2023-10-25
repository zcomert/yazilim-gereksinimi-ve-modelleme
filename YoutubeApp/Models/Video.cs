namespace YoutubeApp.Models;

public class Video {
    public int Id { get; set; }
    public String Title { get; set; }
    public double Duration { get; set; }
    public Category Category {get; set;}
}