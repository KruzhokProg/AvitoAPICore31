using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvitoAPICore31.Controllers
{
    public class UserDTO
    {
        public int id { get; set; }
        public String email { get; set; }
        public String adress { get; set; }
        public double balance_avito { get; set; }
        public String phone_number { get; set; }
        public String role { get; set; }
        public String photo { get; set; }
        public double? rating { get; set; }
        public String companyName { get; set; }
        public IEnumerable<CreditCardDTO> creditCards { get; set; }
        public IEnumerable<UserAdDTO> ads { get; set; }
        public IEnumerable<CommentDTO> comments { get; set; }
    }

    public class CreditCardDTO
    {
        public int id { get; set; }
        public String cardNumber { get; set; }
        public String bankName { get; set; }
        public String bankLogo { get; set; }
        public double balance { get; set; }
    }

    public class UserAdDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public int categoryId { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public DateTime dateOfPublication { get; set; }
        public bool active { get; set; }
        public int conditionId { get; set; }
        public int typeId { get; set; }
        public string communication { get; set; }        
    }

    public class CommentDTO
    {
        public int id { get; set; }
        public int UserIdSender { get; set; }
        public int AdId { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        AvitoContext db = new AvitoContext();

        [HttpGet]
        public List<UserDTO> Get(int? userId)
        {

            var res = db.User.Select(u => new UserDTO
            {
                id = u.Id,
                email = u.Email,
                adress = u.Adress,
                balance_avito = (double)u.Balance,
                phone_number = u.Phone,
                role = u.Role.Name,
                photo = u.Photo,
                rating = u.Rating,
                companyName = u.CompanyName,
                ads = u.Ad.Select(ad => new UserAdDTO
                {
                    id = ad.Id,
                    name = ad.Name,
                    categoryId = ad.CategoryId,
                    price = ad.Price,
                    description = ad.Description,
                    dateOfPublication = ad.DateOfPublication,
                    active = ad.Active,
                    conditionId = ad.ConditionId,
                    typeId = ad.TypeId,
                    communication = ad.Communication,                   
                }),
                comments = u.CommentUserIdReceiverNavigation.Select(c => new CommentDTO
                {
                    id = c.Id,
                    UserIdSender = c.UserIdSender,
                    AdId = c.AdId,
                    Rating = c.Rating,
                    Description = c.Description,
                    Date = c.Date
                }),
                creditCards = u.CreditCard.Select(c => new CreditCardDTO
                {
                    id = c.Id,
                    cardNumber = c.CardNumber,
                    bankName = c.BankName,
                    bankLogo = c.BankLogo,
                    balance = c.Balance
                })

            }).ToList();

            if (userId != null)
                res = res.Where(u => u.id == userId).ToList();

            return res;

        }
    }
}
