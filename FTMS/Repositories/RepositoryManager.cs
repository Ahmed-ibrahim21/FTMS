using FTMS.RepositoriesContracts;

namespace FTMS.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private FTMSContext _repositoryContext;
        private readonly Lazy<IPostRepository> _postRepository;
        private readonly Lazy<IUserRepository> _userRepository;
        public RepositoryManager(FTMSContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _postRepository = new Lazy<IPostRepository>(() => new PostRepository(_repositoryContext));
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(_repositoryContext));
        }

        public IPostRepository Post => _postRepository.Value;

       public IUserRepository User => _userRepository.Value;
        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
