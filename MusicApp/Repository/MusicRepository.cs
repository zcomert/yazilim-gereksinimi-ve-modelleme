using System.Collections;

public class MusicRepository : IRepositoryMethods<Musics>
{
    private List<Musics> _musics;

    public MusicRepository()
    {
        _musics = new List<Musics>();
        _musics.Add(new Musics(0, "Music 1",
            new Albums(1, "Album 1"),
            new Artists(1, "Name 1"),
            "Genre 1", DateTime.Now, 10));
        _musics.Add(new Musics(1, "Music 2",
            new Albums(2, "Album 2"),
            new Artists(2, "Name 2"),
            "Genre 2", DateTime.Now, 20));
    }

    public void Create(Musics item)
    {
        _musics.Add(item);
    }

    public void DeleteAll()
    {
        _musics.Clear();
    }

    public void DeleteOne(int id)
    {
        var item = GetOne(id);
        _musics.Remove(item);
    }

    public List<Musics> GetAll()
    {
        return _musics;
    }

    public Musics GetOne(int id)
    {
        return _musics.Where(item => item.Id.Equals(id)).SingleOrDefault();
    }

    public void Update(int id, Musics item)
    {
        for (int i = 0; i < _musics.Count; i++)
        {
            if (_musics[i].Id.Equals(id))
            {
                _musics[i] = item;
                return;
            }
        }
    }

    public IEnumerator<Musics> GetEnumerator()
    {
        return _musics.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}