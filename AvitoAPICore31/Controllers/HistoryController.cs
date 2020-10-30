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
    public class HistoryController : ControllerBase
    {
        AvitoContext db = new AvitoContext();

        [HttpGet]
        public List<WatchHistory> Get(int userId)
        {
            return db.WatchHistory.Where(w => w.UserId == userId).ToList();
        }

        [HttpPost]
        public ActionResult Post([FromBody] HistoryModel std)
        {
            if (std.userId > 0 && std.adId > 0)
            {
                WatchHistory wh = new WatchHistory();
                wh.UserId = std.userId;
                wh.AdId = std.adId;
                wh.Seen = std.seen;
                wh.Liked = std.liked;

                db.WatchHistory.Add(wh);
                db.SaveChanges();

                return Ok(new { status = true, message = "History Posted Successfully" });
            }
            return BadRequest(new { status = false, message = "Error! History wasn't posted" });
        }

        [HttpDelete]
        public ActionResult Delete(int userId)
        {
            if (userId > 0)
            {
                List<WatchHistory> wh_list = db.WatchHistory.Where(wh => wh.UserId == userId).ToList();
                db.WatchHistory.RemoveRange(wh_list);
                db.SaveChanges();
                return Ok(new { status = true, message = "History Deleted Successfully" });
            }
            return BadRequest(new { status = false, message = "Error! History wasn't deleted" });

        }
    }
}

