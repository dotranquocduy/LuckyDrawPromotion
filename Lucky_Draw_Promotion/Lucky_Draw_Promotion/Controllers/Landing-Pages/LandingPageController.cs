using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lucky_Draw_Promotion.Models;
namespace Lucky_Draw_Promotion.Controllers.Landing_Pages
{
    public class LandingPageController : Controller
    {
        LucKyDrawPromotionDBEntities db = new LucKyDrawPromotionDBEntities();


        //ListCampaign
        public ActionResult ListCampaign()
        {
            var lst = db.Campaigns.ToList();
            //ViewBag.show = RandomCode.RandomGifCode();
            //RandomCode rd = new RandomCode();
            //ViewBag.show = rd.CountRandomGifCode(5);
            return View(lst);
        }

      


        // GET: LandingPage
        public ActionResult LandingPageHome(int ? id)
        {
            
            var check = db.Campaigns.Where(s => s.MaCampaign == id).FirstOrDefault();
            TimerLuckyDraw model = new TimerLuckyDraw();

            Campaign campaign = new Campaign();
          

            TempData["EndTime"] = Session["EndTime"];
            // ViewBag.index = check;
            if(check != null)
            {
                campaign.MaCampaign = check.MaCampaign;
                campaign.CampaignName = check.CampaignName;
                campaign.StartDate = check.StartDate;
                campaign.EndDate = check.EndDate;
                campaign.Scanned = check.Scanned;
                campaign.UsedForSpin = check.UsedForSpin;
                campaign.Winner = check.Winner;
          

                
                model.campaign = campaign;

                ViewBag.index = campaign;
                Session["index"] = campaign;
            }
            
            return View(campaign);
        }


        [HttpPost]
        public void PostCountdownTimer(TimerLuckyDraw model)
        {
            if (Session["EndTime"] == null)
            {
                Session["EndTime"] = DateTime.Now.AddDays(model.timerViewModel.Day).AddHours(model.timerViewModel.Hour).AddMinutes(model.timerViewModel.Minute).AddSeconds(model.timerViewModel.Second).ToString("dd-MM-yyyy h:mm:ss tt");
            }
            TempData["EndTime"] = Session["EndTime"];
            Response.Redirect("/LandingPage/LandingPageHome");
        }

        [HttpPost]
        public ActionResult LandingPageHome()
        {
            Campaign campaign = (Campaign)Session["index"];

     

            return RedirectToAction("JoinGamePage", "Join_Game", new {@id = campaign.MaCampaign  });
        }


        // Destroys EndTime Session object
        public void StopTimer()
        {
            Session.Abandon();
        }

        [HttpPost]
        public JsonResult CallDateTime(int ? id )
        {
           
            var check = db.Campaigns.Where(s => s.MaCampaign == id).FirstOrDefault();
            Campaign cn = new Campaign();
            cn.StartDate = check.StartDate;
            cn.EndDate = check.EndDate;

            return new JsonResult { Data=new { Start = cn.StartDate.ToString(), End = cn.EndDate.ToString() } };
          //  return Json(new { Name = "UrlResponse", Response = "Response from Get", Date = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") }, JsonRequestBehavior.AllowGet);
        }

    }
}