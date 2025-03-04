using FTMS.models;
using FTMS.RepositoriesContracts;

namespace FTMS.Repositories
{
    public class ChatRepository : IChatRepository
    {
        public Task<Chat> CreateChat(Chat chat)
        {
            throw new NotImplementedException();
        }

        public Task<Chat> DeleteChat(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Chat> GetChat(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Chat>> GetChats()
        {
            throw new NotImplementedException();
        }

        public Task<Chat> UpdateChat(Chat chat)
        {
            throw new NotImplementedException();
        }
    }
}
