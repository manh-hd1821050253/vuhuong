using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLySinhVien.Models
{
    public partial class Account
    {
        [Key]
        public int IdAccount { get; set; }
        [Required(ErrorMessage = "Tài khoản không được để trống")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password không được để trống ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
    }
}