using FTMS.models.models_for_M_M;

namespace FTMS.models
{
    public class Chat
    {
        public int id {  get; set; }
        public List<Message> messages { get; set; }

        public List<UserChats> userChats { get; set; }
    }
}
