using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace QuanLySinhVien.Models
{
    public class MaHoaPassword
    {
        public string MaHoaMD5(string Pass)
        {
            var Encrycode = FormsAuthentication.HashPasswordForStoringInConfigFile(Pass.Trim(), "MD5");
            return Encrycode;
        }
    }
}