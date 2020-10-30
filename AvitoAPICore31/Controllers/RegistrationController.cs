using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvitoAPICore31.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvitoAPICore31.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        AvitoContext db = new AvitoContext();

        [HttpPost]
        public ActionResult Post([FromBody] UserModel std)
        {
            User existing_user = db.User.FirstOrDefault(u => u.Email == std.Email);

            if ( !(String.IsNullOrEmpty(std.Email) || String.IsNullOrEmpty(std.Password)
                || (std.RoleId > 0 && std.RoleId <= 3) || String.IsNullOrEmpty(std.Email)
                || String.IsNullOrEmpty(std.PhoneNumber) || String.IsNullOrEmpty(std.CompanyName)
                || existing_user != null) )
            {
                User user = new User();
                user.Email = std.Email;
                user.Password = std.Password;
                user.RoleId = std.RoleId;                
                user.CompanyName = std.CompanyName;
                user.Balance = 0;

                db.User.Add(user);
                db.SaveChanges();

                return Ok(new { status = true, message = "User Posted Successfully" });
            }
            return BadRequest(new { status = false, message = "Error! User wasn't posted" });
        }
    }
}
