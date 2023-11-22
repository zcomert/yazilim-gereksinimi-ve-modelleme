public class AlbumRepository : AbstractRepository<Albums>
{
    public override void DeleteOne(int id)
    {
        var music = list.Where(music => music.Id.Equals(id)).SingleOrDefault();
        list.Remove(music);
    }

    public override Albums GetOne(int id)
    {
        return list.Where(music => music.Id.Equals(id)).SingleOrDefault();
    }

    public override void Update(int id, Albums item)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].Id.Equals(id))
            {
                list[i] = item;
            }
        }
    }
}