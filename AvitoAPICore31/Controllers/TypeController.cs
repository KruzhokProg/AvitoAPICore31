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
    public class TypeController : ControllerBase
    {
        AvitoContext db = new AvitoContext();

        [HttpGet]
        public List<Type> Get()
        {
            return db.Type.ToList();
        }
    }
}
