using FTMS.models;

namespace FTMS.RepositoriesContracts
    
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPosts(string userId,bool trackChanges);
        Task<Post> GetPost(int postId,string userId,bool trackChanges);
        void CreatePostForUser(Post post,string UserId);
        void UpdatePost(Post post);
        void DeletePost(Post post);
    }
}
