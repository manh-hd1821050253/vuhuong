using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLySinhVien.Models
{
    [Table("ChuyenNganh")]
    public class ChuyenNganh
    {
        [Key]
        public int MaNganh { get; set; }
        [Required]
        public string TenNganh { get; set; }
        [Required]
        public DateTime NgayThanhLapChuyenNganh { get; set; }

    }
}