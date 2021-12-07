using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QuanLySinhVien.Models
{
    public class QLSVcontext : DbContext
    {
        public QLSVcontext() : base("name=DBQuanLySinhVienEF") 
        { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //không đăng kí gì cả 
        }
        public virtual DbSet<ChuyenNganh> Nganhs { get; set; }
        public virtual DbSet<Khoa> Khoas { get; set; }
        public virtual DbSet<LopHoc> Lops { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }
        public virtual DbSet<MonHoc> MonHocs { get; set; }
        public virtual DbSet<Diem> Diems { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }


    }
}