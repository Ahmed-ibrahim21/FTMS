using FTMS.models;
using Microsoft.EntityFrameworkCore;

namespace FTMS.Repositories
{
    public class UserRepository : RepositoryBase<User> , IUserRepository
    {
        public UserRepository(FTMSContext repositoryContext) : base(repositoryContext)
        {
        }

        public Task<User> Authenticate(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public void CreateUser(User user) =>  Create(user);

        public void DeleteUser(User user) => Delete(user);

        public async Task<User> GetUser(string id, bool trackChanges) => await FindByCondition(user => user.Id.Equals(id),trackChanges).SingleOrDefaultAsync();

        public async Task<User> GetUserByEmail(string email, bool trackChanges) => await FindByCondition(user => user.Email.Equals(email), trackChanges).SingleOrDefaultAsync();

        public async Task<User> GetUserByUserName(string userName, bool trackChanges) => await FindByCondition(user => user.UserName.Equals(userName), trackChanges).SingleOrDefaultAsync();

        public async Task<IEnumerable<User>> GetUsers(bool trackchanges) => await FindAll(trackchanges).ToListAsync();

        public void UpdateUser(User user) => Update(user);
    }
}
