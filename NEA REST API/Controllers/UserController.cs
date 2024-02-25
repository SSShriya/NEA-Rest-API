using Microsoft.AspNetCore.Mvc;
using NEA_Rest_API.Models;

namespace NEA_Rest_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly NeaContext _context;
        public UserController(NeaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user.Username);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(string uname)
        {
            var user = new User { Username= uname };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(int uid, string uname)
        {
            var user = new User { UserId = uid, Username=uname };
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(user);
        }


    }
}
