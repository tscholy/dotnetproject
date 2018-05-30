using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DatabaseService.Repos
{
    public class UserDataRepository
    {

        public UserDataRepository(ConnectionProvider provider)
        {
            this.provider = provider;
        }

        private ConnectionProvider provider;

        public User Login(IDbConnection connection, string username, string password)
        {
           return connection.Query<User>("SELECT * FROM useraccount WHERE useraccount_username = @username AND useraccount_password = @password", new { username = username, password = password }).FirstOrDefault();
        }

        public List<BaseUser> GetAllContacts(IDbConnection connection, int currentUser)
        {
            return connection.Query<BaseUser>("SELECT * FROM contact_lists a JOIN useraccount b ON a.contact_lists_useraccount_id = b.useraccount_id WHERE contact_lists_useraccount_owner = @currentUser", new { currentUser = currentUser }).ToList();
        }

        public User Register(IDbConnection connection, User user)
        {
            List<BaseUser> userList = connection.Query<BaseUser>("SELECT * FROM useraccount").ToList();

            foreach(BaseUser baseuser in userList)
            {
                if(baseuser.Username == user.Username)
                {
                    return null;
                }
            }
            connection.Query("INSERT INTO useraccount(useraccount_firstname, useraccount_lastname, useraccount_username, useraccount_password, useraccount_usericon, useraccount_statusmessage) VALUES(@firstname, @lastname, @username, @password, @usericon, @statusmessage)", new { firstname = user.Firstname, lastname = user.Lastname, username = user.Username, password = user.Password, usericon = user.UserIcon, statusmessage = user.StatusMessage });
            return Login(connection, user.Username, user.Password);
        }
    }
}
