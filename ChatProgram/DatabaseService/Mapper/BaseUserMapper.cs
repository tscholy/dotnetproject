using Dapper.FluentMap.Mapping;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseService.Mapper
{
    public class BaseUserMapper : EntityMap<BaseUser>
    {
        public BaseUserMapper() { 
            Map(x => x.Id).ToColumn("useraccount_id");
            Map(x => x.Username).ToColumn("useraccount_username");
            Map(x => x.UserIcon).ToColumn("useraccount_usericon");
            Map(x => x.StatusMessage).ToColumn("useraccount_statusmessage");
        }
    }
}
