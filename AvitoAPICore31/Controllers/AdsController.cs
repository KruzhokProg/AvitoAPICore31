using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvitoAPICore31.Controllers
{
    public class AdDTOAll
    {
        public int id { get; set; }
        public String name { get; set; }
        public double price { get; set; }
        public String description { get; set; }
        public bool active { get; set; }
        public IEnumerable<AdPhotosDTO> adPhotos { get; set; }
    }

    public class AdPhotosDTOAll
    {
        public int id { get; set; }
        public String photo { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : ControllerBase
    {
        AvitoContext db = new AvitoContext();

        [HttpGet]
        public List<AdDTO> Get(int? userId)
        {
            List<AdDTO> res;

            if (userId == null)
            {
                res = db.Ad.Select(a => new AdDTO
                {
                    id = a.Id,
                    name = a.Name,
                    price = a.Price,
                    description = a.Description,
                    active = a.Active,
                    adPhotos = a.AdPhotos.Select(adp => new AdPhotosDTO
                    {
                        id = adp.Id,
                        photo = adp.Photo
                    })
                }).ToList();
            }
            else
            {
                res = db.Ad.Where(ad => ad.UserId != userId).Select(a => new AdDTO
                {
                    id = a.Id,
                    name = a.Name,
                    price = a.Price,
                    description = a.Description,
                    active = a.Active,
                    adPhotos = a.AdPhotos.Select(adp => new AdPhotosDTO
                    {
                        id = adp.Id,
                        photo = adp.Photo
                    })
                }).ToList();
            }
            
            return res;
        }
    }
}
