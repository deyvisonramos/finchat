namespace FinChat.Chat.Web.Models
{
    public class ChatMessageViewModel
    {
        public string ChatRoomId { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Message { get; set; }
    }
}