using System;
using System.IO;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace Translate.Controllers
{
    public class OrderController : BaseController
    {
        public ActionResult Index()
        {
            ViewData["CurrentPage"] = "Order";
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string useremail, string usercoment, HttpPostedFileBase userFile)
        {
            string filepath = "";
            if ((userFile != null) && (userFile.ContentLength != 0))
            {
                string guid = Guid.NewGuid().ToString().Substring(0, 6);
                string path = Path.Combine(base.Server.MapPath("~/Docs"), guid);
                string filename = Path.GetFileName(userFile.FileName);
                if (userFile.ContentLength >= 100 * 1024 * 1024)
                {
                    return View("Error");// Json(new { result = false, message = "Максимальный размер файла 100 Мб" });
                }
                try
                {
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    userFile.SaveAs(path + "/" + filename);
                    filepath = guid + "/" + filename;
                }
                catch (Exception)
                {
                    return Json(new { result = false, message = "Ошибка при загрузке файла" });
                }
            }
            string body = string.Format("<h2>Поступил новый заказ:</h2> Имя: {0}<br/> E-mail: {1}<br />Комментарий: {2}<br /> Файл: {3}", new object[] { username, useremail, usercoment, string.IsNullOrWhiteSpace(filepath) ? "нет" : ("<a href='http://www.ulrespect.ru/docs/" + filepath + "'>скачать...</a>") });
            try
            {
                SmtpClient client = new SmtpClient("smtp.yandex.ru")
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("zakaz@ulrespect.ru", "zakaz123"),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Port = 0x19,
                    EnableSsl = true
                };

                using (SmtpClient emailClient = client)
                {
                    using (MailMessage message = new MailMessage("zakaz@ulrespect.ru", "info@ulrespect.ru", "Заказ перевода", body))
                    {
                        message.IsBodyHtml = true;
                        emailClient.Send(message);
                    }
                }
            }
            catch (Exception)
            {
                return Json(false);
            }
            return Json(true);
        }
    }
}
