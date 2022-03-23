using System.Net;
using System.Web.Mvc;
using Newtonsoft.Json;
namespace Lucky_Draw_Promotion.Controllers.CMS
{
    public class AuthenticationCMSController : Controller
    {
        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult ForgotPass()
        {
            return View();
        }
        public ActionResult RecoverPass()
        {
            return View();
        }

        // recaptcha
        [HttpPost]
        public ActionResult FormSubmit(string submit)
        {
            //Validate Google recaptcha below

            var response = Request["g-recaptcha-response"];
            string secretKey = "6Lf2RvMeAAAAABi-_VMVL4s8Yrwv9SLEU9JxMKJm";
            var client = new WebClient();

            var GoogleReply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));

            //var captchaResponse = (bool)JsonConvert.DeserializeObject(GoogleReply);

            // ViewData["Message"] = captchaResponse? "Google reCaptcha validation success" : "Google reCaptcha validation failed";

            //Here I am returning to Index view:
            if (submit== "lg")
            {
                return RedirectToAction("Dashboard_Home","Dashboard");
            }
            else if(submit == "forgotpass")
            {
                return View("RecoverPass");
            }
            else if (submit == "rePass")
            {
                return View("Login");
            }
            return View();
        }

    }
}