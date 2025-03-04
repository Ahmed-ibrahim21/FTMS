using FTMS.RepositoriesContracts;

namespace FTMS.Services
{
    public class PostsService
    {
        private readonly IRepositoryManager _repository;

        public PostsService(IRepositoryManager repository)
        {
            _repository = repository;
        }
    }
}
