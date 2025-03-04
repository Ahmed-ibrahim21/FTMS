namespace FTMS.RepositoriesContracts
{
    public interface IRepositoryManager
    {
        IPostRepository Post { get; }
        IUserRepository User { get; }
        Task SaveAsync();
    }
}
