using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Web;
using Lucky_Draw_Promotion.Models;
using Newtonsoft.Json;

namespace Lucky_Draw_Promotion.Models
{
    public class SpinFilterText
    {
        Product product = new Product();

        public string fillStyle { get; set; }

        public string text { get; set; }


     

        public static string NameGif()
        {
            Product product = new Product();
            return product.ProductName ="Duy";
        }


        // random colors
        //public static string[] RandomColors()
        //{
        //    List<string> chars = new List<string> { "DarkKhaki", "red", "green", "Yellow", "BlueViolet", "Orange", "brown", "pink" };

        //    //String[] array = chars.ToArray();

        //    string[] array = chars.ToArray();

        //    Random rd = new Random();


        //    for (int i = 0; i < chars.Count; i++)
        //    {

        //        //array[i] = chars[rd.Next(chars.Count)];
        //        int randomnumber = rd.Next(0, chars.Count - 1);
        //        array[i] = chars[randomnumber];
        //        chars.RemoveAt(randomnumber);
             
        //    }


        //    return array;
        //}



        public static string CallSpin(int ? id)
        {
            
            LucKyDrawPromotionDBEntities db =new LucKyDrawPromotionDBEntities();

            List<string> chars = new List<string> { "DarkKhaki", "red", "green", "Yellow", "BlueViolet", "Orange", "brown", "pink" };


            List<SpinFilterText> LstspinFilterText = new List<SpinFilterText>();

            var campaignLstProducts = db.Gifts.Where(s => s.MaCampaign == id).ToList();

            List<Product> lstNameproduct = new List<Product>();

            foreach (var item in campaignLstProducts)
            {
                lstNameproduct.Add(db.Products.Where(s => s.ProductId == item.ProductId).FirstOrDefault());
            }


                for (int i = 0; i < chars.Count; i++)
                {
                    for (int j = 0; j < lstNameproduct.Count; j++)
                    {
                        LstspinFilterText.Add(new SpinFilterText { fillStyle = chars.ElementAt(j), text = lstNameproduct.ElementAt(j).ProductName });
                   
                    }

                }
            



            //LstspinFilterText.Add(

            //     new SpinFilterText { fillStyle = "blue", text = "Cá Sống" }
            //    );

            //LstspinFilterText.Add(

            //     new SpinFilterText { fillStyle = "red", text = "thịt Sống" }
            //    );
            //LstspinFilterText.Add(

            //     new SpinFilterText { fillStyle = "green", text = "gà quay" }
            //    );
            //LstspinFilterText.Add(

            //    new SpinFilterText { fillStyle = "Yellow", text = "Heo" }
            //   );

            //LstspinFilterText.Add(

            //     new SpinFilterText { fillStyle = "BlueViolet", text = "Bò" }
            //    );
            //LstspinFilterText.Add(

            //     new SpinFilterText { fillStyle = "Orange", text = "Tôm" }
            //    );
            //LstspinFilterText.Add(

            //    new SpinFilterText { fillStyle = "brown", text = "Mực" }
            //   );

            //LstspinFilterText.Add(

            //     new SpinFilterText { fillStyle = "pink", text = "Cua" }
            //    );
         


           
            var Json = JsonConvert.SerializeObject(LstspinFilterText);

            return Json;







        }

    }
}