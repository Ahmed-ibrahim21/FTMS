using FTMS.models;

namespace FTMS.Repositories
{
    public interface IChatRepository
    {
        Task<IEnumerable<Chat>> GetChats();
        Task<Chat> GetChat(int id);
        Task<Chat> CreateChat(Chat chat);
        Task<Chat> UpdateChat(Chat chat);
        Task<Chat> DeleteChat(int id);
    }
}
