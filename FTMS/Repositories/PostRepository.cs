using FTMS.models;
using Microsoft.EntityFrameworkCore;

namespace FTMS.Repositories
{
    public class PostRepository :RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(FTMSContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreatePostForUser(Post post, string UserId)
        {
            post.UserId = UserId;
            Create(post);
        }

        public void DeletePost(Post post) => Delete(post);

        public async Task<Post> GetPost(int postId, string userId, bool trackChanges) => await FindByCondition(post => post.PostId.Equals(postId) && post.UserId.Equals(userId), trackChanges).SingleOrDefaultAsync();

        public async Task<IEnumerable<Post>> GetPosts(string userId, bool trackChanges) => await FindByCondition(post => post.UserId.Equals(userId), trackChanges).ToListAsync();

        public void UpdatePost(Post post) => Update(post);
    }
}
