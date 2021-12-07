using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLySinhVien.Models
{
    [Table("Khoa")]
    public class Khoa
    {
        [Key]
        public int MaKhoa { get; set; }
        [Required]
        public string TenKhoa { get; set; }
        [Required]
        public DateTime ngaythanhlapkhoa { get; set; }
        public int? MaNganh { get; set; }
        [ForeignKey("MaNganh")]
        public virtual ChuyenNganh ChuyenNganhs { get; set; }
    }
}