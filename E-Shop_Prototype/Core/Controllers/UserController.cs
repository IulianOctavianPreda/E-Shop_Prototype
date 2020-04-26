using System;
using System.Linq;
using Core.Database;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly SqlServerContext _context;

        public UserController(SqlServerContext context)
        {
            _context = context;
        }

        private static string EncryptPassword(string password)
        {
            var data = System.Text.Encoding.ASCII.GetBytes(password);
            var hash = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            return System.Text.Encoding.ASCII.GetString(hash);
        }

        public class LoginData
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        [HttpPost]
        [Route("login")]
        public string Login([FromBody] LoginData data)
        {
            // TODO implement actually secure login
            var user = _context.User.FirstOrDefault(x => x.UserName == data.Username && x.Password == EncryptPassword(data.Password));
            return user?.Id.ToString();
        }


        [HttpPost]
        [Route("signup")]
        public bool SignUp([FromBody] LoginData data)
        {
            // TODO throw error on existing sign-up
            var user = _context.User.FirstOrDefault(x => x.UserName == data.Username && x.Password == EncryptPassword(data.Password));
            if (user == null)
            {
                _context.User.Add(new User
                { UserName = data.Username, Password = EncryptPassword(data.Password) });
                _context.SaveChanges();
                return true;
            }
            return false;

        }
    }
}
