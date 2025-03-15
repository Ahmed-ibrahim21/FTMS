using AutoMapper;
using FTMS.DTOs;
using FTMS.RepositoriesContracts;
using FTMS.ServiceContracts;

namespace FTMS.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        private readonly IMapper _mapper;

        public ChatService(IChatRepository chatRepository, IMapper mapper)
        {
            _chatRepository = chatRepository;
            _mapper = mapper;
        }
        //public Task<ChatDto> CreateChatAsync(ChatDto chatDto)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ChatDto> GetChatAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<IEnumerable<GetGroupChatDto>> GetGroupChatsAsync(string userId)
        //{
        //    var chats = await _chatRepository.GetGroupChats(userId);
        //    if(chats == null)
        //        throw new KeyNotFoundException("No Group chats found for the user.");

        //    var chatsDto = _mapper.Map<IEnumerable<GetGroupChatDto>>(chats);
        //    return chatsDto;

        //}
    }
}
