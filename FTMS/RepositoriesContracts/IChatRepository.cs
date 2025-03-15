using FTMS.models;

namespace FTMS.RepositoriesContracts
{
    public interface IChatRepository
    {
        Task<IEnumerable<Chat>> GetGroupChats(string userId);
        Task<Chat> GetChat(int id);
        void CreateChat(Chat chat);
        void UpdateChat(Chat chat);
        void DeleteChat(int id);
    }
}
