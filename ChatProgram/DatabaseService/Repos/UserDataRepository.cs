using Dapper;
using Models;
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
    }
}
