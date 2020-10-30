using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvitoAPICore31.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckUserController : ControllerBase
    {
        AvitoContext db = new AvitoContext();

        [HttpGet]
        public int Get(String email, String password)
        {

            var user = db.User.FirstOrDefault(a => a.Email == email && a.Password == password);

            if (user != null)
                return user.Id;
            else
                return -1;
        }
    }
}
