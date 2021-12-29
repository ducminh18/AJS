namespace AJS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class Product
    {
        [Key]
        [StringLength(10)]
        public string MaSP { get; set; }

        [StringLength(50)]
        public string TenSP { get; set; }

        public string MoTa { get; set; }

        public int? SoLuong { get; set; }

        public int? DonGia { get; set; }

        [Required]
        [StringLength(10)]
        public string MaLoai { get; set; }

        public string Anh { get; set; }
    }
}
