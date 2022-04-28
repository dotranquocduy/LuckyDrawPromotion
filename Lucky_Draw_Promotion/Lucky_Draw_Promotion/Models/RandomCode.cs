using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Lucky_Draw_Promotion.Models
{
    public class RandomCode
    {

        private static Random random = new Random();

        public static string RandomGifCode(/*int length*/)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[11];

            //return new string(Enumerable.Repeat(chars, length)
            //    .Select(s => s[random.Next(s.Length)]).ToArray());


            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new string(stringChars);

            var giftcode = "GIF" + finalString;


            return giftcode;
        }

        public List<string> CountRandomGifCode(int count)
        {
            List<string> coderand = new List<string>();
            string str;
            for(int i=0;i< count; i++)
            {
               str  =RandomCode.RandomGifCode();
                coderand.Add(str);
            }

            return coderand;
        }


        // length tiền tố 
        public static string RandomGifCodeLength(string prefix,string postfix,int codeLength)
        {
            if (prefix == null)
            {
                prefix = "GIF";
            }
            if(postfix == null)
            {
                postfix = "";
            }

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[codeLength];

            //return new string(Enumerable.Repeat(chars, length)
            //    .Select(s => s[random.Next(s.Length)]).ToArray());


            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new string(stringChars);

            var giftcode = prefix + finalString;


            return giftcode;
        }



        public List<string> CountRandomGifCodeLength(int count, string prefix, string postfix, int codeLength)
        {
            List<string> coderand = new List<string>();
            string str;
            for (int i = 0; i < count; i++)
            {
                str = RandomCode.RandomGifCodeLength(prefix, postfix,codeLength);
                coderand.Add(str);
            }

            return coderand;
        }


    }
}