using System.Web;
using System;
using System.IO;
namespace Helpers
{
    static class FileHelper
    {
        public static string SaveFile(HttpPostedFileBase file)
        {
            string filepath = "";
            if ((file != null) && (file.ContentLength != 0))
            {
                string guid = Guid.NewGuid().ToString().Substring(0, 6);
                string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Docs"), guid);
                string filename = Path.GetFileName(file.FileName);
                if (file.ContentLength >= 100 * 1024 * 1024)
                {
                    return null;// Json(new { result = false, message = "Максимальный размер файла 100 Мб" });
                }
                try
                {
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    file.SaveAs(path + "/" + filename);
                    filepath = guid + "/" + filename;
                }
                catch (Exception)
                {
                    return null;
                }
            }

            return "";
        }
    }
}