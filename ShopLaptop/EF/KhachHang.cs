namespace ShopLaptop.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            DonHangs = new HashSet<DonHang>();
        }

        [Key]
        public int makh { get; set; }

        [Required]
        [StringLength(50)]
        public string hoten { get; set; }

        [StringLength(50)]
        public string tendangnhap { get; set; }

        [Required]
        [StringLength(32)]
        public string matkhau { get; set; }

        [StringLength(254)]
        public string email { get; set; }

        [StringLength(200)]
        public string diachi { get; set; }

        [StringLength(50)]
        public string dienthoai { get; set; }

        public DateTime? ngaysinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
