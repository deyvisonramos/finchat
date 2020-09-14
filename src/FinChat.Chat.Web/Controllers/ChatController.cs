using System.Collections.Generic;
using System.Threading.Tasks;
using FinChat.Chat.Application.Interfaces;
using FinChat.Chat.Domain.Entities;
using FinChat.Chat.Web.Models;
using FinChat.Chat.Web.Transformers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinChat.Chat.Web.Controllers
{
    public class ChatController : Controller
    {
        private readonly IChatService _chatService;
        private readonly ITransformer<ChatRoom, ChatRoomViewModel> _chatRoomTransformer;

        public ChatController(IChatService chatService, ITransformer<ChatRoom, ChatRoomViewModel> chatRoomTransformer)
        {
            _chatService = chatService;
            _chatRoomTransformer = chatRoomTransformer;
        }

        public IActionResult Index()
        {
            var result = _chatService.GetChatRooms();
            var viewResult = _chatRoomTransformer.Transform(result.Output);
            return View(viewResult);
        }

        public IActionResult CreateChatRoom()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateChatRoom(ChatRoomViewModel viewModel)
        {
            var result = await _chatService.CreateChatRoom(viewModel.Name);
            return RedirectToAction("JoinChatRoom", new { chatRoomId = result.Output.Id });
        }

        public async Task<IActionResult> JoinChatRoom([FromQuery] string chatRoomId)
        {
            var result = await _chatService.GetChatRoom(chatRoomId);
            var viewResult = _chatRoomTransformer.Transform(result.Output);
            return View("ChatRoom",  viewResult);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(ChatMessageViewModel model)
        {
            var result = await _chatService.SendMessage(model.ChatRoomId, model.AuthorId, model.AuthorName, model.Message);
            return Ok(result);
        }
    }
}