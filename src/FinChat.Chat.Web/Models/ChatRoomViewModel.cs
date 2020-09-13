using System.Collections.Generic;

namespace FinChat.Chat.Web.Models
{
    public class ChatRoomViewModel
    {
        public ChatRoomViewModel()
        {
            Conversation = new List<ChatMessageViewModel>();
        }
            
        public string Id { get; set; }
        public string Name { get; set; }
        public List<ChatMessageViewModel> Conversation { get; set; }
    }
}