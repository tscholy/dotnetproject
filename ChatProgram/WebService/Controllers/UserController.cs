﻿using DatabaseService;
using DatabaseService.Repos;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    public class UserController : BaseController
    {
        private UserService userService;
        public UserController ()
        {
            userService = new UserService();
        }

        [HttpPost]
        [ActionName("Login")]
        public User Login([FromBody]User user)
        {
            return userService.Login(user.Username, user.Password);
        }
    }
}