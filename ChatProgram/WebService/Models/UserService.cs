using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class UserService
    {

        public User Register(string firstname, string lastname, string username, string password, string email)
        {
            return null;
        }

        public bool Login(string username, string password)
        {
            return true;
        }

        public void Logout(string username)
        {

        }
    }
}