using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EasyClean.Helpers
{
    public class FileHelper
    {
        public static bool UploadPhoto(MemoryStream memoryStream, string folderName, string fileName)
        {
            try
            {
                memoryStream.Position = 0;
                var path = Path.Combine(HttpContext.Current.Server.MapPath(folderName), fileName).Replace("\\", "/");
                File.WriteAllBytes(path, memoryStream.ToArray());
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}