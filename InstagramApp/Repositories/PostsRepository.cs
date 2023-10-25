class PostsRepository
{
    private List<Posts> postList;

    public PostsRepository()
    {
        postList = new List<Posts>();
    }

    public List<Posts> GetAllPosts()
    {
        return postList;
    }

    public Posts GetOnePosts(int id)
    {
        for (int i = 0; i < postList.Count; i++)
        {
            if(postList[i].Id.Equals(id)){
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

    public void DleteAllPosts()
    {
        // postList = new List<Posts>();
        postList.Clear();
    }

}