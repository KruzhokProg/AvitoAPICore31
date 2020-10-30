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
    public class AdSeenController : ControllerBase
    {
        AvitoContext db = new AvitoContext();

        [HttpPost]
        public ActionResult Post([FromBody] SeenModel std)
        {
            WatchHistory wh = new WatchHistory();
            wh.AdId = std.adId;
            wh.UserId = std.userId;
            wh.Seen = std.seen;
            wh.Liked = std.liked;
            db.WatchHistory.Add(wh);
            db.SaveChanges();
            return Ok(new { status = true, message = "History Posted Successfully" });
        }
    }
}
