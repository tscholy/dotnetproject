using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    public class ChatController : ApiController
    {
        private ChatService chatService = new ChatService();

        [HttpGet]
        [ActionName("allchats")]
        public IHttpActionResult Login(int user)
        {
            return Ok(chatService.GetAllChats(user));
        }

        [HttpGet]
        [ActionName("memberstochat")]
        public IHttpActionResult GetMembersToChat(int chatid)
        {
            return Ok(chatService.GetMembersToChat(chatid));
        }
    }
}