public class Artists
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Artists()
    {

    }

    public Artists(int id, string name)
    {
        Id = id;
        Name = name;
    }
}