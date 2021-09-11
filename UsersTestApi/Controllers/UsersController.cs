using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UsersTest.Models;

namespace UsersTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private static List<UserModel> users = new List<UserModel>();

        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<UserModel> Get()
        {
            return users;
        }

        [HttpPost]
        public object Post([FromBody] UserModel user)
        {
            if (user != null)
            {
                user.ID = Guid.NewGuid().ToString();
                users.Add(user);

                return new { id = user.ID };
            }
            return null;
        }

        [HttpDelete("{id}")]
        public object Delete(string id)
        {
            if (users.Any(user => user.ID == id))
            {
                users.RemoveAll(user => user.ID == id);
                return new { success = true };
            }
            return new { success = true };
        }
    }
}