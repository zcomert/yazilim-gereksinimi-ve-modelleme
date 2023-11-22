public class Musics
{
    public int Id { get; set; }
    public string Title { get; set; }
    public Albums Album { get; set; }
    public Artists Artist { get; set; }
    public string Genre { get; set; }
    public DateTime PublishDate { get; set; }
    public decimal View { get; set; }

    public Musics()
    {

    }

    public Musics(int ıd, string title, Albums album, Artists artist, string genre, DateTime publishDate, decimal view)
    {
        Id = ıd;
        Title = title;
        Album = album;
        Artist = artist;
        Genre = genre;
        PublishDate = publishDate;
        View = view;
    }
}