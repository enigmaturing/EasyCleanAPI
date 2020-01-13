using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EasyClean.Helpers;
using EasyClean.Models;

namespace EasyClean.Controllers
{
    public class EndClientsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IHttpActionResult Post([FromBody] EndClient user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Create a name for the photo
            var guid = Guid.NewGuid().ToString();
            var fileName = String.Format("{0}.jpg", guid);
            var folder = "~/Content/Users";                // Folder where the photos will be locally saved
            var fullPath = Path.Combine(folder, fileName).Replace("\\", "/");
            // upload the photo 
            var stream = new MemoryStream(user.ImageArray); // MemoryStream accepts an array of bytes (user.Image Array is an array of bytes)
            var response = FileHelper.UploadPhoto(stream, folder, fileName);

            if (response)
            {
                user.ImagePath = fullPath;
            }

            db.EndClients.Add(user);
            db.SaveChanges();
            return StatusCode(HttpStatusCode.Created);
        }
    }
}