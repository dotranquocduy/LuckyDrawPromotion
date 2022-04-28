using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lucky_Draw_Promotion.Models
{
    public class CampaignGiftFullModelClass
    {
        public Campaign Campaign { get; set; }
        public Gift Gift { get; set; }
        public string Prefix { get; set; }
        public string Postfix { get; set; }
        public int CodeLength { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public CampaignGiftFullModelClass() { }
        public CampaignGiftFullModelClass(Campaign Campaign,Gift Gift, string Prefix,string Postfix, int CodeLength)
        {
            this.Campaign = Campaign;
            this.Gift = Gift;
            this.Prefix = Prefix;
            this.Postfix = Postfix;
            this.CodeLength = CodeLength;
        }

    }
}