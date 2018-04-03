using DatabaseService.Repos;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class UserService : BaseService
    {
        UserDataRepository userDataRepo = new UserDataRepository(provider);

        public User Register(string firstname, string lastname, string username, string password, string email)
        {
            return null;
        }

        public User Login(string username, string password)
        {
            User newUser;
            using (IDbConnection connection = provider.GetConnection())
            {
                newUser = userDataRepo.Login(connection, username, password);
            }
            if (newUser != null)
            {
                return newUser;
            }
            else
            {
                throw new Exception("User does not exist");
            }
        }

        public void Logout(string username)
        {

        }
    }
}