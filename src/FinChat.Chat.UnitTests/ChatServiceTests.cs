using System.Linq;
using System.Threading.Tasks;
using FinChat.Chat.Application.Enums;
using FinChat.Chat.Application.Services;
using FinChat.Chat.Domain.Interfaces.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FinChat.Chat.UnitTests
{
    [TestClass]
    public class ChatServiceTests
    {
        private ChatService _chatService;

        [TestInitialize]
        public void Initialize()
        {
            var chatRoomMockRepository = new Mock<IChatRoomRepository>();
            _chatService = new ChatService(chatRoomMockRepository.Object);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(null)]
        public async Task ShouldNotSendEmptyOrNullMessages(string message)
        {
            var result = await _chatService.SendMessage("fakeChatId", "fakeAuthorId", "Fake Author", message);
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Messages.Any(x => x.Type == EOutputNotificationType.Error && x.Subject == "message"));
        }
    }
}
