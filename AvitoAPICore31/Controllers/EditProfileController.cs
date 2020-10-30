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
    public class EditProfileController : ControllerBase
    {
        AvitoContext db = new AvitoContext();

        [HttpPut]
        public ActionResult Put([FromForm] ProfileModel std)
        {
            User u = db.User.FirstOrDefault(u => u.Id == std.Id);
            if (u != null)
            {
                String imageName = std.Image.FileName;
                var image = std.Image;

                if (imageName.Length > 0)
                {
                    using (var fileStream = new FileStream(imageName, FileMode.Create))
                    {
                        image.CopyTo(fileStream);
                        var ms = new MemoryStream();
                        fileStream.CopyTo(ms);
                        u.Email = std.Name;
                        u.Adress = std.Metro;
                        u.Photo = imageName;
                        db.SaveChanges();
                        return Ok(new { status = true, message = "Profile edited successfully!" });
                    }
                }
            }            
            
            return BadRequest(new { status = false, message = "Error! profile wasn't edited" });
        }
    }
}
