﻿using DatabaseService.Repos;
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
        private UserDataRepository userDataRepo = new UserDataRepository(provider);

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
                return null;
            }
        }

        internal User Register(User user)
        {
            User newUser;
            using (IDbConnection connection = provider.GetConnection())
            {
                newUser = userDataRepo.Register(connection, user);
            }
            if (newUser != null)
            {
                return newUser;
            }
            else
            {
                return null;
            }
        }

        public void Logout(string username)
        {

        }

        public List<BaseUser> GetAllContacts(int currentUser)
        {
            List <BaseUser> allContacts = new List<BaseUser>();
            using (IDbConnection connection = provider.GetConnection())
            {
                allContacts = userDataRepo.GetAllContacts(connection, currentUser);
            }
            return allContacts;
        }
    }
}