﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lucky_Draw_Promotion.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Gift
    {
        public int MaGift { get; set; }
        public string NameGift { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string description { get; set; }
        public double Probability { get; set; }
        public string RuleName { get; set; }
        public string GiftCode { get; set; }
        public string scheldule { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool usage { get; set; }
        public int GiftCount { get; set; }
        public Nullable<int> MaCampaign { get; set; }
        public Nullable<int> ProductId { get; set; }
    
        public virtual Campaign Campaign { get; set; }
        public virtual Product Product { get; set; }



       
    }
}
