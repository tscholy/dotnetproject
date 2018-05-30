using DatabaseService;
using DatabaseService.Repos;
using Models;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    public class UserController : ApiController
    {
        private UserService userService;
        public UserController ()
        {
            userService = new UserService();
        }

        [HttpPost]
        [ActionName("Login")]
        public IHttpActionResult Login([FromBody]User user)
        {
            return Ok(userService.Login(user.Username, user.Password));
        }
        
        [HttpPost]
        [ActionName("Register")]
        public IHttpActionResult Register([FromBody]User user)
        {
            return Ok(userService.Register(user));
        }


        [HttpGet]
        [ActionName("allcontacts")]
        public IHttpActionResult GetAllContacts(int user)
        {
            return Ok(userService.GetAllContacts(user));
        }
    }
}