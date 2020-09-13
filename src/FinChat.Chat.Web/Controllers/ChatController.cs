using System.Collections.Generic;
using FinChat.Chat.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinChat.Chat.Web.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            var chatRooms = new List<ChatRoomViewModel>();
            return View(chatRooms);
        }

        public IActionResult CreateChatRoom()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateChatRoom(ChatRoomViewModel viewModel)
        {
            return RedirectToAction("JoinChatRoom", new { chatRoomId = viewModel.Id });
        }

        public IActionResult JoinChatRoom([FromQuery] string chatRoomId)
        {
            var model = new ChatRoomViewModel();
            return View("ChatRoom",  model);
        }

        [HttpPost]
        public IActionResult SendMessage(ChatMessageViewModel model)
        {
            //save the message and send to socket;
            return Ok(model);
        }
    }
}