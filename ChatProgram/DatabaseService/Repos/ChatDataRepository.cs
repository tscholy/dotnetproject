using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;

namespace DatabaseService.Repos
{
    public class ChatDataRepository
    {
        public ChatDataRepository(ConnectionProvider provider)
        {
            this.provider = provider;
        }
        private ConnectionProvider provider;

        public List<Chat> GetAllChats(IDbConnection connection, int currentUser)
        {
            return connection.Query<Chat>("SELECT a.chat_member_user_id, a.chat_member_user_is_admin, b.chat_id, b.chat_title FROM fhv_chat.chat_member a" +
                " JOIN chat b ON a.chat_member_chat_id = b.chat_id" +
                " WHERE chat_member_user_id = @currentUser OR chat_member_user_is_admin = @currentUser" +
                " group by b.chat_id", new { currentUser = currentUser }).AsList();
        }

        public List<BaseUser> GetAllMembersToChat(IDbConnection connection, int chatid)
        {
            return connection.Query<BaseUser>("SELECT b.* FROM fhv_chat.chat_member a" +
                                            " JOIN useraccount b ON a.chat_member_user_id = b.useraccount_id" +
                                            " WHERE a.chat_member_chat_id = @chatid", new { chatid = chatid }).AsList();
        }

        public List<ChatMessage> GetAllMessagesToChat(IDbConnection connection, int chatid)
        {
            return connection.Query<ChatMessage>("SELECT * FROM fhv_chat.chat_messages WHERE chat_messages_chat_id = @chatid", new { chatid = chatid}).AsList();
        }
    }
}
