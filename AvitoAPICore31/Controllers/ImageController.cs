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
    public class ImageController : ControllerBase
    {
        [HttpGet("{imageName}")]
        public IActionResult Get(String imageName)
        {
            return PhysicalFile(@"h:\root\home\vongu3-001\www\madsell\" + imageName, "image/png");
            //return PhysicalFile("C:\\Users\\user\\source\\repos\\WebApiCore3Remote\\WebApiCore3Remote\\" + imageName, "image/jpeg");
        }
    }
}
