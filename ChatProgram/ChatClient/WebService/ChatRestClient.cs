using Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.WebService
{
    public class ChatRestClient : BaseRestClient
    {

        public ChatRestClient() : base()
        {
        }

        public List<Chat> GetAllChatsforUser(int currentUser)
        {
            return Get<Chat>("chat/allchats", "user", currentUser).ToList();
        }

        internal List<ChatMessage> GetMessegesToChat(int id)
        {
            return Get<ChatMessage>("chat/messagestochat", "chatid", id).ToList(); ;
        }

        internal List<BaseUser> GetAllMembersToChat(int id)
        {
            List<BaseUser> list = new List<BaseUser>();
            list =  Get<BaseUser>("chat/memberstochat", "chatid", id).ToList();

            return list;
        }
    }
}
