using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLySinhVien.Models
{
    [Table("LopHoc")]
    public class LopHoc
    {
        [Key]
        public int MaLop { get; set; }
        [Required]
        public string TenLop { get; set; }
        public int? MaKhoa { get; set; }
        [ForeignKey("MaKhoa")]
        public virtual Khoa Khoas { get; set; }
    }
}