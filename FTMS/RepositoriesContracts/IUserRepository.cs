using FTMS.models;

namespace FTMS.RepositoriesContracts
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers(bool trackchanges);

        Task<User> GetUser(string id ,bool trackChanges);

        Task<User> GetUserByEmail(string email,bool trackChanges);

        Task<User> GetUserByUserName(string userName, bool trackChanges);

        void CreateUser(User user);

        void UpdateUser(User user);

        void DeleteUser(User user);

        Task<User> Authenticate(string userName, string password);
    }
}
