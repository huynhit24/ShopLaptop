namespace ShopLaptop.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinTuc")]
    public partial class TinTuc
    {
        [Key]
        public int matin { get; set; }

        [Required]
        [StringLength(255)]
        public string tieude { get; set; }

        [StringLength(70)]
        public string hinhnen { get; set; }

        [StringLength(255)]
        public string tomtat { get; set; }

        [Required]
        [StringLength(100)]
        public string slug { get; set; }

        [Column(TypeName = "ntext")]
        public string noidung { get; set; }

        public int? luotxem { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ngaycapnhat { get; set; }

        public bool? xuatban { get; set; }

        public int? machude { get; set; }

        public virtual ChuDe ChuDe { get; set; }
    }
}
