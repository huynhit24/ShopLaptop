//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopLaptop.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Laptop
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Laptop()
        {
            this.ChiTietDonHangs = new HashSet<ChiTietDonHang>();
            this.DanhGias = new HashSet<DanhGia>();
            this.MetaLaptops = new HashSet<MetaLaptop>();
        }
    
        public int malaptop { get; set; }
        public string tenlaptop { get; set; }
        public Nullable<decimal> giaban { get; set; }
        public string mota { get; set; }
        public string hinh { get; set; }
        public Nullable<int> mahang { get; set; }
        public Nullable<int> manhucau { get; set; }
        public string cpu { get; set; }
        public string gpu { get; set; }
        public string ram { get; set; }
        public string hardware { get; set; }
        public string manhinh { get; set; }
        public Nullable<System.DateTime> ngaycapnhat { get; set; }
        public Nullable<int> soluongton { get; set; }
        public string pin { get; set; }
        public Nullable<bool> trangthai { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGia> DanhGias { get; set; }
        public virtual Hang Hang { get; set; }
        public virtual NhuCau NhuCau { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MetaLaptop> MetaLaptops { get; set; }
    }
}
