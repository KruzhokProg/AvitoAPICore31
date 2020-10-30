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
    public class AddCardController : ControllerBase
    {
        AvitoContext db = new AvitoContext();

        [HttpPost]
        public ActionResult Post([FromBody] CardModel std)
        {
            User user = db.User.FirstOrDefault(a => a.Id == std.userId);
            if (user != null)
            {
                CreditCard cm = new CreditCard();
                cm.Balance = std.balance;
                cm.BankLogo = std.bankLogo;
                cm.BankName = std.bankName;
                cm.CardNumber = std.cardNumber;
                cm.UserId = std.userId;
                db.CreditCard.Add(cm);
                db.SaveChanges();

                return Ok(new { status = true, message = "карта успешно добавлена!" });
            }
            else
            {
                return BadRequest(new { status = false, message = "Пользователь не найден" });
            }
        }
    }
}
