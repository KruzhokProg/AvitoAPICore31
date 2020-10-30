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
    public class ConditionController : ControllerBase
    {
        AvitoContext db = new AvitoContext();

        [HttpGet]
        public List<Condition> Get()
        {
            return db.Condition.ToList();
        }
    }
}
