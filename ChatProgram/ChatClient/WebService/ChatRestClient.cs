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
            try
            {
                var request = new RestRequest("chat/allchats", Method.GET);
                request.AddParameter("user", currentUser);
                var response = client.Execute<List<Chat>>(request);
                var content = response.Content;
                List<Chat> allContacts = new List<Chat>();
                allContacts = response.Data;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return allContacts;
                }

            }
            catch (Exception e)
            {

            }
            return new List<Chat>();
        }

        internal List<ChatMessage> GetMessegesToChat(int id)
        {
            return Get<ChatMessage>("chat/messagestochat", "chatid", id).ToList(); ;
        }

        internal List<BaseUser> GetAllMembersToChat(int id)
        {
            var request = new RestRequest("chat/memberstochat", Method.GET);
            request.AddParameter("chatid", id);
            IRestResponse<List<BaseUser>> response = client.Execute<List<BaseUser>>(request);
            List<BaseUser> objects = response.Data;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return objects;
            }
            else
            {
                return null;
            }
        }
    }
}
