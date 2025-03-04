using FTMS.RepositoriesContracts;
using FTMS.ServiceContracts;

namespace FTMS.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IPostsService> _postsService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _postsService = new Lazy<IPostsService>(() => new PostsService(repositoryManager));
        }
        public IPostsService posts => _postsService.Value;
    }
}
