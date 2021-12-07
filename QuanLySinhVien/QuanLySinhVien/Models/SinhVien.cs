using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLySinhVien.Models
{
    [Table("SINHVIEN")]
    public class SinhVien
    {
        [Key]
        public int MaSinhVien { get; set; }
        [Required]
        [StringLength(70)]
        public string TenSinhVien { get; set; }
        [Required]
        public DateTime NgaySinh { get; set; }
        [Required]
        public string QueQuan { get; set; }
        [Required]
        public int MaLop { get; set; }
        [ForeignKey("MaLop")]
        public virtual LopHoc LopHocs { get; set; }
        [Required]
        public int MaKhoa { get; set; }
        [ForeignKey("MaKhoa")]
        public virtual Khoa Khoas { get; set; }
        [Required]
        public int MaNganh { get; set; }
        [ForeignKey("MaNganh")]
        public virtual ChuyenNganh ChuyenNganhs { get; set; }
        [Required]
        public int MaBangDiem { get; set; }

    }
}