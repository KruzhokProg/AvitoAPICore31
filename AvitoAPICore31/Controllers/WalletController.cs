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
    public class WalletController : ControllerBase
    {
        AvitoContext db = new AvitoContext();

        [HttpPost]
        public ActionResult Post([FromBody] WalletModel std)
        {
            CreditCard card = db.CreditCard.FirstOrDefault(c => c.CardNumber == std.cardNumber);
            User user = db.User.FirstOrDefault(u => u.Id == std.userId);
            if (card.Balance > std.sum)
            {
                card.Balance -= std.sum;
                user.Balance += (double)std.sum;
                db.SaveChanges();
                return Ok(new { status = true, message = "Success!" });
            }
            else
            {
                return BadRequest(new { status = false, message = "Error! not enough money, select another card" });
            }
        }
    }
}
