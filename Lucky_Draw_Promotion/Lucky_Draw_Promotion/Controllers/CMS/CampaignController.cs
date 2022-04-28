using Lucky_Draw_Promotion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lucky_Draw_Promotion.Controllers.CMS
{
    public class CampaignController : Controller
    {

        LucKyDrawPromotionDBEntities DBcontext = new LucKyDrawPromotionDBEntities();

        CampaignGiftFullModelClass cn = new CampaignGiftFullModelClass();
        Campaign campaign = new Campaign();
        Gift gift = new Gift();



        // GET: Campaign_Management
        public ActionResult Campaign()
        {
            var lst = DBcontext.Campaigns.ToList();
            return View(lst);
        }

    
        public ActionResult CreateCampaigns(string title)
        {
            // show list gift mà mình tạo trên view rule name gift
            ViewBag.lstGiftRulesName = DBcontext.Gifts.ToList();
           // ViewBag.lstGiftRulesName = "";
            ViewBag.lstProducts = DBcontext.Products.ToList();
           

            ViewBag.Title = "Campaign";
            return View();
        }




        [HttpPost]
        public ActionResult CreateCampaigns(FormCollection f)
        {
            userAccount userAccount = (userAccount)Session["TaiKhoan"];

            if(userAccount.MaPQ == 1)
            {
                // check account
                if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
                {
                    return RedirectToAction("Login", "AuthenticationCMS");
                }




                // campaigns
                foreach (var item in (List<Campaign>)Session["lstCampaigns"])
                {
                    Session["id"] = item.MaCampaign;

                    DBcontext.Campaigns.Add(item);

                }

                // gifts
                foreach (var item in DBcontext.Gifts.Where(s => s.MaCampaign == null))
                {
                    // id campaign
                    item.MaCampaign = Convert.ToInt32(Session["id"]);

                }



                // thêm id product vào trong gift 
                foreach (var item in (List<Product>)Session["lstProduct"])
                {
                    TempData["ProductId"] = item.ProductId;
                }
                foreach (var item in DBcontext.Gifts.Where(s => s.ProductId == null))
                {
                    item.ProductId = Convert.ToInt32(TempData["ProductId"]);
                }


                //Rule Name Gift


                DBcontext.SaveChanges();
            }
            else
            {
                return RedirectToAction("Login", "AuthenticationCMS");
            }
           

            //Rule of Gift 
            //string sRuleName = f.Get("RuleName").ToString();
            //double Probability = double.Parse(f.Get("Probability"));

            //gift.RuleName = sRuleName;
            //gift.Probability = Probability;



            return RedirectToAction("Campaign", "Campaign");
         
        }


        public ActionResult Detail(string title)
        {
            ViewBag.Title = title;
            return View();
        }

        [HttpPost]
        public ActionResult CallProgramSizeTimeFrame(Campaign campaign)
        {

            List<Campaign> lstCampaigns = new List<Campaign>();
            // random code 
            RandomCode rd = new RandomCode();

            //timeframe
            var Start = campaign.StartDay.Split(',')[0].Split(' ');
            var End = campaign.EndDay.Split(',')[0].Split(' ');

            var startDateTime = DateTime.Parse(Start[0] + " " + campaign.StartTime);
            var EndDateTime = DateTime.Parse(End[0] + " " + campaign.EndTime);

            campaign.StartDate = startDateTime;
            campaign.EndDate = EndDateTime;




            var lstRd = rd.CountRandomGifCodeLength(campaign.CodeCount, campaign.Prefix, campaign.Postfix, campaign.CodeLength);
            foreach (var item in lstRd)
            {
                campaign.CampaignCode = item;
                //DBcontext.Campaigns.Add(campaign);
                //DBcontext.SaveChanges();
                lstCampaigns.Add(campaign);
            }

            //Session["MaCampaign"] = campaign.MaCampaign;
            Session["lstCampaigns"] = lstCampaigns;

            return Json(campaign);
        }

        

        [HttpPost]
        public ActionResult CallGiftList(Gift gift)
        {
            RandomCode rd = new RandomCode();

            List<Gift> lstGifts = new List<Gift>();

            gift.CreatedDate = DateTime.Now;

            //tạo danh sách sản phẩm
            List<Product> lstproduct = new List<Product>();


            // tạo sản phẩm thêm 
            Product product = new Product();

            //gift.MaCampaign = Convert.ToInt32(Session["MaCampaign"]);

            //gift.MaCampaign = 15;

            var lstGiftCodeCount = rd.CountRandomGifCode(gift.GiftCount);

            foreach (var item in lstGiftCodeCount)
            {
                // tạo mã gift
                gift.GiftCode = item;
                DBcontext.Gifts.Add(gift);
                DBcontext.SaveChanges();
                lstGifts.Add(gift);

                // thêm sản phẩm 
                product.ProductName = gift.NameGift;
                product.details = gift.description;
                lstproduct.Add(product);

                var check = DBcontext.Products.Where(s => s.ProductName == product.ProductName).FirstOrDefault();
                if (check != null)
                {
                    product.ProductId = check.ProductId;
                    Session["lstproduct"] = DBcontext.Products.Where(s => s.ProductName == product.ProductName).ToList();
                    DBcontext.SaveChanges();
                    continue;
                }
                else
                {
                    DBcontext.Products.Add(product);
                    DBcontext.SaveChanges();
                    //Session["productId"]=product.ProductId;

                }

              
            }

                //Session["lstRuleName"] = lstproduct;
                Session["lstproduct"] = lstproduct;
                Session["lstGifts"] = lstGifts;

          

            return Json(lstGifts);

        }


        [HttpPost]
        public ActionResult CallRulesForGifts(Gift gift)
        {
            
            var check = DBcontext.Gifts.Where(s=>s.NameGift == null).FirstOrDefault();
            check.RuleName = gift.RuleName;
            check.Probability = gift.Probability;
            DBcontext.SaveChanges();
            
         
            return Json(gift);
        }





    }
}