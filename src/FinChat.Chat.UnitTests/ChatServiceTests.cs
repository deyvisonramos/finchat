using System.Linq;
using System.Threading.Tasks;
using FinChat.Chat.Application.Interfaces;
using FinChat.Chat.Application.Services;
using FinChat.Chat.Data.Transactions;
using FinChat.Chat.Domain.Entities;
using FinChat.Chat.Domain.Interfaces.Repositories;
using FinChat.Chat.Domain.Notification;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FinChat.Chat.UnitTests
{
    [TestClass]
    public class ChatServiceTests
    {
        private ChatService _chatService;
        private Mock<IChatRoomRepository> _chatRoomMockRepository;
        private Mock<IWebSocketService> _webSocketMock;

        [TestInitialize]
        public void Initialize()
        {
            _chatRoomMockRepository = new Mock<IChatRoomRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            _webSocketMock = new Mock<IWebSocketService>();

            _chatService = new ChatService(
                unitOfWorkMock.Object,
                _chatRoomMockRepository.Object,
                _webSocketMock.Object);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(null)]
        public async Task ShouldNotSendEmptyOrNullMessages(string message)
        {
            _chatRoomMockRepository
                .Setup(x =>
                    x.GetChatRoomById(It.IsAny<string>(), It.IsAny<bool>()))
                .Returns(Task.FromResult(new ChatRoom("test chat room")));

            var result = await _chatService.SendMessage("fakeChatId", "fakeAuthorId", "Fake Author", message);
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Notifications.Any(x => x.Type == ENotificationType.Error));
        }
    }
}
