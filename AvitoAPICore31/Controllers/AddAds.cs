using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AvitoAPICore31.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvitoAPICore31.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddAds : ControllerBase
    {
        AvitoContext db = new AvitoContext();

        [HttpPost]
        public ActionResult Post([FromForm] AdsModel std)
        {
            var images = std.Images;


            int nextAdId = db.Ad.Max(a => a.Id) + 1;

            Ad ad = new Ad();
            ad.Name = std.name;
            ad.CategoryId = std.categoryId;
            ad.Price = std.price;
            ad.UserId = std.userId;
            ad.Description = std.description;
            ad.ConditionId = std.conditionId;
            ad.TypeId = std.typeId;
            ad.Communication = std.communication;
            db.Add(ad);

            foreach (var image in images)
            {
                String imageName = image.FileName;

                if (imageName.Length > 0)
                {
                    using (var fileStream = new FileStream(imageName, FileMode.Create))
                    {
                        image.CopyTo(fileStream);
                        var ms = new MemoryStream();
                        fileStream.CopyTo(ms);

                        AdPhotos adPhotos = new AdPhotos();
                        adPhotos.Photo = imageName;
                        adPhotos.AdId = nextAdId;

                        db.AdPhotos.Add(adPhotos);
                        db.SaveChanges();                       
                    }
                }                

            }

            return Ok(new { status = true, message = "Ad posted successfully!" });
        }
    }
}
