using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Lucky_Draw_Promotion.Models;
namespace Lucky_Draw_Promotion.Controllers.CMS
{
    public class DashboardController : Controller
    {

        LucKyDrawPromotionDBEntities DBcontext = new LucKyDrawPromotionDBEntities();
        // GET: Dashboard
        public ActionResult Dashboard()
        {

            var lst=DBcontext.Campaigns.ToList();
            return View(lst);
        }

        
    }
}