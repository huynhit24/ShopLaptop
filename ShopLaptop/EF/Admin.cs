namespace ShopLaptop.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [Key]
        [StringLength(30)]
        public string UserAdmin { get; set; }

        [Required]
        [StringLength(32)]
        public string PassAdmin { get; set; }

        [StringLength(50)]
        public string hoten { get; set; }
    }
}
