using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLySinhVien.Models
{
    [Table("BangDiem")]
    public class Diem
    {
        [Key]
        public int MaBangDiem { get; set; }
        [Required]
        public int MaSinhVien { get; set; }
        [ForeignKey("MaSinhVien")]
        public virtual SinhVien SinhVienS { get; set; }
        [Required]
        public int MaMon { get; set; }
        [ForeignKey("MaMon")]
        public virtual MonHoc MonHocs { get; set; }
        public double DiemHeA { get; set; }
        public double DiemHeB { get; set; }
        public double DiemHeC { get; set; }
    }
}