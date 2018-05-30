
using Dapper.FluentMap.Mapping;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseService.Mapper
{
    public class ChatMessageMapper : EntityMap<ChatMessage>
    {
        public ChatMessageMapper()
        {
            Map(x => x.Id).ToColumn("chat_messages_id");
            Map(x => x.Message).ToColumn("chat_messages_message");
            Map(x => x.SenderID).ToColumn("chat_messages_sender_id");
            Map(x => x.SendDate).ToColumn("chat_messages_timestamp");
            Map(x => x.ChatID).ToColumn("chat_messages_chat_id");
        }
    }
}
