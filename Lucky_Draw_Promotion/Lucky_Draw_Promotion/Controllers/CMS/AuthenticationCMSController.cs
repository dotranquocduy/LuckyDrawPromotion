using System.Net;
using System.Web.Mvc;
using Newtonsoft.Json;
using Lucky_Draw_Promotion.Models;
using System.Linq;

namespace Lucky_Draw_Promotion.Controllers.CMS
{
    public class AuthenticationCMSController : Controller
    {
        LucKyDrawPromotionDBEntities DBcontext = new LucKyDrawPromotionDBEntities();
        // GET: Authentication
        public ActionResult Login()
        {


            return View();
        }


       [HttpPost]
        public ActionResult Login(string submit, FormCollection f, string url)
        {

            string sTaiKhoan = f["email"].ToString();
            string sMatKhau = f.Get("pass").ToString();
            string urlString = f.Get("urlString").ToString();


            var response = Request["g-recaptcha-response"];
            string secretKey = "6Lf2RvMeAAAAABi-_VMVL4s8Yrwv9SLEU9JxMKJm";
            var client = new WebClient();

            var GoogleReply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));

            if (submit == "lg")
            {

                if (url != null)
                    urlString = url;

                var usr = (from u in DBcontext.userAccounts
                           where u.email == sTaiKhoan && u.pass == sMatKhau
                           select u).FirstOrDefault();
                //TempData["UserName"] = usr.TaiKhoan;
                if (usr != null && usr.MaPQ == 1)
                {
                    //create seession/ token for loged in user
                    // FormsAuthentication.SetAuthCookie(usr.TaiKhoan, false);
                    Session["TaiKhoan"] = usr;
                    //lay gio hang cua khach hang 
                    if (urlString.Trim() != "")
                    {
                        string[] urlLogin = urlString.Split('/');
                        if (urlLogin[urlLogin.Length - 1] == "Login")
                            return RedirectToAction("Dashboard", "Dashboard", new { urlLogin });
                        else
                            return Redirect(urlString);
                    }
                    else
                        return RedirectToAction("Dashboard", "Dashboard");
                }
                else if (usr != null && usr.MaPQ == 2 )
                {
                    TempData["Message"] = "Account is missing Error !!";
                    ViewBag.ThongBao = "Tài khoản không hợp lệ!";
                    return View();
                }
                else
                {
                    TempData["Message"] = "Username or password is wrong";
                    ViewBag.ThongBao = "Tài khoản này không tồn tại!";
                    return View();
                }

                
            }


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
        
            if (submit == "forgotpass")
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