//------------------------------------------------------------------------------
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
    
    public partial class userAccount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public userAccount()
        {
            this.CodeQRs = new HashSet<CodeQR>();
        }
    
        public int UserId { get; set; }
        public string TenUser { get; set; }
        public string email { get; set; }
        public string sdt { get; set; }
        public Nullable<System.DateTime> ngaysinh { get; set; }
        public string pass { get; set; }
        public string repass { get; set; }
        public string LoaiHinhKD { get; set; }
        public bool IsActiveBox { get; set; }
        public string MaCV { get; set; }
        public int MaPQ { get; set; }
    
        public virtual ChucVu ChucVu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CodeQR> CodeQRs { get; set; }
        public virtual PhanQuyen PhanQuyen { get; set; }
    }
}
