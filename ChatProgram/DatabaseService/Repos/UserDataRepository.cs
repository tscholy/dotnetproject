using Dapper;
using Models;
using MySql.Data.MySqlClient;
using System;
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

        public User GetUser(IDbConnection connection, string username, string password)
        {
           return connection.Query<User>("SELECT * FROM useraccount WHERE useraccount_username = @username AND useraccount_password = @password", new { username = username, password = password }).FirstOrDefault();
        }
    }
}
