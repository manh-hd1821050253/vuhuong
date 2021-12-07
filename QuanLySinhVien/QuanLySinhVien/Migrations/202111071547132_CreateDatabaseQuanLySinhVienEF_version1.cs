namespace QuanLySinhVien.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabaseQuanLySinhVienEF_version1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BangDiem",
                c => new
                    {
                        MaBangDiem = c.Int(nullable: false, identity: true),
                        MaSinhVien = c.Int(nullable: false),
                        MaMon = c.Int(nullable: false),
                        DiemHeA = c.Double(nullable: false),
                        DiemHeB = c.Double(nullable: false),
                        DiemHeC = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.MaBangDiem)
                .ForeignKey("dbo.MonHoc", t => t.MaMon, cascadeDelete: true)
                .ForeignKey("dbo.SINHVIEN", t => t.MaSinhVien, cascadeDelete: true)
                .Index(t => t.MaSinhVien)
                .Index(t => t.MaMon);
            
            CreateTable(
                "dbo.MonHoc",
                c => new
                    {
                        MaMonHoc = c.Int(nullable: false, identity: true),
                        TenMonHoc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaMonHoc);
            
            CreateTable(
                "dbo.SINHVIEN",
                c => new
                    {
                        MaSinhVien = c.Int(nullable: false, identity: true),
                        TenSinhVien = c.String(nullable: false, maxLength: 70),
                        NgaySinh = c.DateTime(nullable: false),
                        QueQuan = c.String(nullable: false),
                        MaLop = c.Int(nullable: false),
                        MaKhoa = c.Int(nullable: false),
                        MaNganh = c.Int(nullable: false),
                        MaBangDiem = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaSinhVien)
                .ForeignKey("dbo.ChuyenNganh", t => t.MaNganh, cascadeDelete: true)
                .ForeignKey("dbo.Khoa", t => t.MaKhoa, cascadeDelete: true)
                .ForeignKey("dbo.LopHoc", t => t.MaLop, cascadeDelete: true)
                .Index(t => t.MaLop)
                .Index(t => t.MaKhoa)
                .Index(t => t.MaNganh);
            
            CreateTable(
                "dbo.ChuyenNganh",
                c => new
                    {
                        MaNganh = c.Int(nullable: false, identity: true),
                        TenNganh = c.String(nullable: false),
                        NgayThanhLapChuyenNganh = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaNganh);
            
            CreateTable(
                "dbo.Khoa",
                c => new
                    {
                        MaKhoa = c.Int(nullable: false, identity: true),
                        TenKhoa = c.String(nullable: false),
                        ngaythanhlapkhoa = c.DateTime(nullable: false),
                        MaNganh = c.Int(),
                    })
                .PrimaryKey(t => t.MaKhoa)
                .ForeignKey("dbo.ChuyenNganh", t => t.MaNganh)
                .Index(t => t.MaNganh);
            
            CreateTable(
                "dbo.LopHoc",
                c => new
                    {
                        MaLop = c.Int(nullable: false, identity: true),
                        TenLop = c.String(nullable: false),
                        MaKhoa = c.Int(),
                    })
                .PrimaryKey(t => t.MaLop)
                .ForeignKey("dbo.Khoa", t => t.MaKhoa)
                .Index(t => t.MaKhoa);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BangDiem", "MaSinhVien", "dbo.SINHVIEN");
            DropForeignKey("dbo.SINHVIEN", "MaLop", "dbo.LopHoc");
            DropForeignKey("dbo.LopHoc", "MaKhoa", "dbo.Khoa");
            DropForeignKey("dbo.SINHVIEN", "MaKhoa", "dbo.Khoa");
            DropForeignKey("dbo.Khoa", "MaNganh", "dbo.ChuyenNganh");
            DropForeignKey("dbo.SINHVIEN", "MaNganh", "dbo.ChuyenNganh");
            DropForeignKey("dbo.BangDiem", "MaMon", "dbo.MonHoc");
            DropIndex("dbo.LopHoc", new[] { "MaKhoa" });
            DropIndex("dbo.Khoa", new[] { "MaNganh" });
            DropIndex("dbo.SINHVIEN", new[] { "MaNganh" });
            DropIndex("dbo.SINHVIEN", new[] { "MaKhoa" });
            DropIndex("dbo.SINHVIEN", new[] { "MaLop" });
            DropIndex("dbo.BangDiem", new[] { "MaMon" });
            DropIndex("dbo.BangDiem", new[] { "MaSinhVien" });
            DropTable("dbo.LopHoc");
            DropTable("dbo.Khoa");
            DropTable("dbo.ChuyenNganh");
            DropTable("dbo.SINHVIEN");
            DropTable("dbo.MonHoc");
            DropTable("dbo.BangDiem");
        }
    }
}
