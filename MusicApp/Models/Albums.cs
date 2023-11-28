public class Albums
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public Albums()
    {
    }

    public Albums(int ıd, string title)
    {
        Id = ıd;
        Title = title;
    }
}