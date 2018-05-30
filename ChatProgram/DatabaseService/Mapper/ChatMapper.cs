using Dapper.FluentMap.Mapping;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseService.Mapper
{
    public class ChatMapper : EntityMap<Chat>
    {
        public ChatMapper()
        {
            Map(x => x.Id).ToColumn("chat_id");
            Map(x => x.AdminID).ToColumn("chat_member_user_is_admin");
            Map(x => x.Title).ToColumn("chat_title");
        }
    }
}
