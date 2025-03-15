using FTMS.models;
using FTMS.RepositoriesContracts;
using Microsoft.EntityFrameworkCore;

namespace FTMS.Repositories
{
    public class ChatRepository : IChatRepository
    {
    private readonly FTMSContext _context;

       public ChatRepository(FTMSContext context) => _context = context;
        public void CreateChat(Chat chat)
        {
            _context.Chats.Add(chat);
        }

        public void DeleteChat(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Chat> GetChat(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Chat>> GetGroupChats(string userId)
        {
            var chats = await _context.Chats
            .Where(c => c.IsGroupChat && c.userChats.Any(uc => uc.UserId == userId))
            .AsNoTracking()
            .ToListAsync();

            return chats;
        }

        public void UpdateChat(Chat chat)
        {
            throw new NotImplementedException();
        }
    }
}
