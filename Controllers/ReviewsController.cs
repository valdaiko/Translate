using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;

namespace Translate.Controllers
{
    public class ReviewsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string userName, string userEmail, string userReview)
        {
            string body = string.Format("<h2>Новый отзыв:</h2> Имя: {0}<br/> E-mail: {1}<br />Отзыв: {2}<br />", userName, userEmail, userReview);
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
                    using (MailMessage message = new MailMessage("zakaz@ulrespect.ru", "info@ulrespect.ru", "Новый отзыв", body))
                    {
                        message.IsBodyHtml = true;
                        emailClient.Send(message);
                    }
                }
            }
            catch (Exception)
            {
                return RedirectToAction("thanks", "reviews");
            }
            return RedirectToAction("thanks", "reviews");
        }

        public ActionResult Thanks()
        {
            return View();
        }

    }
}
