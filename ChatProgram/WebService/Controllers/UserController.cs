using DatabaseService;
using DatabaseService.Repos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebService.Controllers
{
    public class UserController : BaseController
    {
        UserDataRepository userDataRepo = new UserDataRepository(provider);

        [HttpGet]
        [ActionName("GetUser")]
        public IHttpActionResult GetUser(string username, string password)
        {
            using (IDbConnection connection = provider.GetConnection())
            {
                return Ok(userDataRepo.GetUser(connection, username, password));
            }
        }
    }
}