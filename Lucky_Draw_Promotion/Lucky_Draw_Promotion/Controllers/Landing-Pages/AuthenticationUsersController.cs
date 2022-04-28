using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Lucky_Draw_Promotion.Models;
using Firebase.Auth;
using System.Data.Entity;

namespace Lucky_Draw_Promotion.Controllers.Landing_Pages
{
    public class AuthenticationUsersController : Controller
    {
        LucKyDrawPromotionDBEntities DBcontext = new LucKyDrawPromotionDBEntities();

        // Đăng nhập tài khoản
        // GET: Authentication
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(FormCollection f, string url)
        {
            string sTaiKhoan = f["email"].ToString();
            string sMatKhau = f.Get("pass").ToString();
            string urlString = f.Get("urlString").ToString();

            if (url != null)
                urlString = url;

            var usr = (from u in DBcontext.userAccounts
                       where u.email == sTaiKhoan && u.pass == sMatKhau
                       select u).FirstOrDefault();
            //TempData["UserName"] = usr.TaiKhoan;
            if (usr != null)
            {
                //create seession/ token for loged in user
                // FormsAuthentication.SetAuthCookie(usr.TaiKhoan, false);
                Session["TaiKhoan"] = usr;
                //lay gio hang cua khach hang 
                if (urlString.Trim() != "")
                {
                    string[] urlLogin = urlString.Split('/');
                    if (urlLogin[urlLogin.Length - 1] == "Login")
                        return RedirectToAction("ListCampaign", "LandingPage");
                    if (urlLogin[urlLogin.Length - 1] == "Register")
                        return RedirectToAction("ListCampaign", "LandingPage");
                    //else
                    //    return Redirect(urlString);
                }
                else
                    return RedirectToAction("ListCampaign", "LandingPage");
            }

            TempData["Message"] = "Username or password is wrong";
            ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng!";

            return View();
        }

    
        public ActionResult RecoverPass( string number)
        {
            //var check = DBcontext.userAccounts.Where(s => s.sdt == value).FirstOrDefault();

            //if (check.TenUser != null)
            //{
            //    check.pass = "";
            //    check.repass = "";
            //    DBcontext.SaveChanges();
            //}
            //number = "0903085608";
            return View(number);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult RecoverPass(FormCollection f,string number)
        {
          
            string sMatKhau = f["pass"].ToString();
            string sReMatKhau = f.Get("repass").ToString();
            var check = DBcontext.userAccounts.Where(s => s.sdt == number).FirstOrDefault();
            
            if (check.TenUser!=null)
            {
                //check.pass = "";
                //check.repass = "";
                //DBcontext.SaveChanges();
                if(sMatKhau == sReMatKhau)
                {
                    check.pass = sMatKhau;
                    check.repass = sReMatKhau;

                    DBcontext.SaveChanges();
                    RedirectToAction("Login", "AuthenticationUsers");
                }
                else
                {
                    return View();
                }

            }         
            return View();
    
        }

        [AllowAnonymous]
        public ActionResult ForgotPass_OTP()
        {            
            
            return View();
        }

        //[HttpPost]
        //public ActionResult ForgotPass_OTP(string number)
        //{
        //   // number = "0903085608";
        //    return RedirectToAction("RecoverPass", "AuthenticationUsers", new {number});
        //}


        // Đăng kí tài khoản
        [AllowAnonymous]
        public ActionResult Register()
        {
        
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(userAccount userAccount, FormCollection f , bool ? IsChecked)
        {
            
            string url = f.Get("urlString").ToString();

            userAccount.email = f["email"].ToString();
            userAccount.TenUser = f["TenUser"].ToString();
            userAccount.pass = f["pass"].ToString();
            userAccount.sdt = f["sdt"].ToString();
         

            if(userAccount.TenUser =="" || userAccount.email =="" || userAccount.pass=="" || userAccount.sdt=="")
            {
                return View();
            }

            if (ModelState.IsValid)
            {
        
                var check = DBcontext.userAccounts.Where(s => s.email != userAccount.email && s.sdt != userAccount.sdt).FirstOrDefault();
               if(check.TenUser == null)
                {
                    var age = DateTime.Now.Year - check.ngaysinh.Value.Year;
                    if (check.pass.Length < 6)
                    {
                        // viewbag
                        return View();
                    }
                    else if (age < 16)
                    {
                        // viewbag
                        return View();

                    }
                    //userAccount.IsActiveBox = IsChecked.Value;

                }

            }
            //if(userAccount.IsActiveBox == true)
            //{
            //    userAccount.MaPQ = 2; // mã phân quyền dành khách hàng
            //    userAccount.repass = userAccount.pass;
            //    DBcontext.userAccounts.Add(userAccount);
            //    DBcontext.SaveChanges();
            //    return RedirectToAction("LandingPageHome", "LandingPage", new { url });
                
            //}
            //else if(userAccount.IsActiveBox == false)
            //{
            //    return View();
            //}

            userAccount.MaPQ = 2; // mã phân quyền dành khách hàng
            userAccount.repass = userAccount.pass;
            DBcontext.userAccounts.Add(userAccount);
            DBcontext.SaveChanges();
            return RedirectToAction("ListCampaign", "LandingPage", new { url });
            
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
            if (submit == "lg")
            {
                return RedirectToAction("Dashboard", "Dashboard");
            }
            else if (submit == "forgotpass")
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
