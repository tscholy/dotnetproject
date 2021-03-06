﻿using Dapper.FluentMap.Mapping;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseService.Mapper
{
    class UserMapper : EntityMap<User>
    {
        public UserMapper()
        {
            Map(x => x.Id).ToColumn("useraccount_id");
            Map(x => x.Firstname).ToColumn("useraccount_firstname");
            Map(x => x.Lastname).ToColumn("useraccount_lastname");
            Map(x => x.Username).ToColumn("useraccount_username");
            Map(x => x.Password).ToColumn("useraccount_password");
            Map(x => x.UserIcon).ToColumn("useraccount_usericon");
            Map(x => x.StatusMessage).ToColumn("useraccount_statusmessage");
        }
    }
}


