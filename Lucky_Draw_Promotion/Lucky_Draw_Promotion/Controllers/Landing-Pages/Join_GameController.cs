using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Web;
using System.Web.Mvc;
using Lucky_Draw_Promotion.Models;
namespace Lucky_Draw_Promotion.Controllers.Landing_Pages
{
    public class Join_GameController : Controller
    {
        // GET: Join_Game
        public ActionResult JoinGamePage(int ? id)
        {
            ViewBag.id = id;
            return View();
        }

        //[HttpGet]
        //public ActionResult CallSpin()
        //{
        //    var LstspinFilterText = new List<SpinFilterText>()
        //    {
        //        new SpinFilterText(){fillStyle = "blue",text ="Cá sống"},
        //        new SpinFilterText(){fillStyle = "green",text ="thịt gà"}
        //    };
        //    var opt = new JsonSerializerOptions() { WriteIndented = true };
        //    string strJson = JsonSerializer.Serialize<IList<SpinFilterText>>(LstspinFilterText, opt);
        //    Console.WriteLine(strJson);

        //    return Json(strJson,JsonRequestBehavior.AllowGet);
        //    //return new JsonResult { Data = new { str =strJson.ToString() } };
        //}


    }
}