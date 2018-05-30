using DatabaseService.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using System.Data;

namespace WebService.Models
{
    public class ChatService : BaseService
    {
        private ChatDataRepository chatDataRepo = new ChatDataRepository(provider);

        public List<Chat> GetAllChats(int currentUser)
        {
            List<Chat> allChats = new List<Chat>();
            using (IDbConnection connection = provider.GetConnection())
            {
                allChats = chatDataRepo.GetAllChats(connection, currentUser);
            }
            return allChats;
        }

        internal List<BaseUser> GetMembersToChat(int chatid)
        {
            List<BaseUser> allChats = new List<BaseUser>();
            using (IDbConnection connection = provider.GetConnection())
            {
                allChats = chatDataRepo.GetAllMembersToChat(connection, chatid);
            }
            return allChats;
        }

        internal object GetMessagesToChat(int chatid)
        {
            List<ChatMessage> allMessages = new List<ChatMessage>();
            using (IDbConnection connection = provider.GetConnection())
            {
                allMessages = chatDataRepo.GetAllMessagesToChat(connection, chatid);
            }
            return allMessages;
        }
    }
}