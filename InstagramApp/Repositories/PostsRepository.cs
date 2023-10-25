public class PostsRepository
{
    private List<Posts> postList;

    public PostsRepository()
    {
        postList = new List<Posts>();
        postList.Add(new Posts()
        {
            Id = 1,
            Title = "ASP.NET Core",
            PostDate = DateTime.Now,
            Location = "Samsun",
            Tag = new Tags()
            {
                Id = 1,
                TagName = "Programming"
            }
        });
        postList.Add(new Posts()
        {
            Id = 2,
            Title = "Samsun University",
            PostDate = DateTime.Now.AddDays(1),
            Location = "Samsun",
            Tag = new Tags()
            {
                Id = 2,
                TagName = "University"
            }
        });
    }

    public List<Posts> GetAllPosts()
    {
        return postList;
    }

    public Posts GetOnePosts(int id)
    {
        for (int i = 0; i < postList.Count; i++)
        {
            if (postList[i].Id.Equals(id))
            {
                return postList[i];
            }
        }
        return new Posts();
        // throw new Exception("Not Found!");
    }

    public void CreateOnePosts(Posts post)
    {
        postList.Add(post);
    }

    public void UpdateOnePosts(int id, Posts post)
    {
        for (int i = 0; i < postList.Count; i++)
        {
            if (postList[i].Id.Equals(id))
            {
                postList[i] = post;
            }
        }
    }

    public void DeleteOnePost(int id)
    {
        for (int i = 0; i < postList.Count; i++)
        {
            if (postList[i].Id.Equals(id))
            {
                postList.Remove(postList[i]);
            }
        }
    }

    public void DeleteAllPosts()
    {
        // postList = new List<Posts>();
        postList.Clear();
    }

}