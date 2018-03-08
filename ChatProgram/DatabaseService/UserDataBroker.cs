using Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DatabaseService
{
    public class UserDataBroker
    {

        public UserDataBroker(ConnectionProvider provider)
        {
            this.provider = provider;
        }

        private ConnectionProvider provider;

        public User GetUser(string username, string password)
        {
            using(IDbConnection connection = provider.GetConnection())
            {
                using(IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM useraccount WHERE useraccount_username = ?username AND useraccount_password = ?password";
                    command.AddParameter("?username", DbType.String, username);
                    command.AddParameter("?password", DbType.String, password);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            User user = new User();
                            user.Id = (int)reader["useraccount_id"];
                            user.Firstname = (string)reader["useraccount_firstname"];
                            user.Lastname = (string)reader["useraccount_lastname"];
                            user.Password = (string)reader["useraccount_password"];
                            user.Username = (string)reader["useraccount_username"];
                            return user;
                        }
                        else
                        {
                            throw new Exception("Username and Password did not match");
                        }

                    }
                }
            }
        }
    }
}
