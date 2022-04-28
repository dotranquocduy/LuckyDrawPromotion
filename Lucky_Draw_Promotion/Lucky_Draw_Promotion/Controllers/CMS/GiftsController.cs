using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lucky_Draw_Promotion.Controllers.CMS
{
    public class GiftsController : Controller
    {
        // GET: GeneratedGifts_Management
     
        public ActionResult GeneratedGifts()
        {
            return View();
        }
        public ActionResult GiftsCategory()
        {
            return View();
        }
        public ActionResult ImportGifts()
        {
            return View();
        }
    }
}