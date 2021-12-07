using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLySinhVien.Models
{
    [Table("MonHoc")]
    public class MonHoc
    {
        [Key]
        public int MaMonHoc { get; set; }
        [Required]
        public string TenMonHoc { get; set; }
    }
}