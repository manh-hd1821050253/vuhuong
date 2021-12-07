using QuanLySinhVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QuanLySinhVien.Controllers
{
    public class AccountController : Controller
    {
        MaHoaPassword Encrycode = new MaHoaPassword();
        private QLSVcontext db = new QLSVcontext();
        // GET: Account
        [HttpGet]
        public ActionResult DangKiTaiKhoan()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult DangKiTaiKhoan(Account acc)
        {
            var CheckUser = db.Accounts.Where(ac => ac.UserName == acc.UserName).Count();
            if (CheckUser == 0)
            {
                if (ModelState.IsValid)
                {
                    acc.Password = Encrycode.MaHoaMD5(acc.Password);
                    db.Accounts.Add(acc);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Account");
                }
            }
            else
            {
                ModelState.AddModelError("", "Tài khoản này đã tồn tại");
            }
            return View(acc);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Login(Account acc)
        {
            if (ModelState.IsValid)
            {
                string Userpass = Encrycode.MaHoaMD5(acc.Password);
                var Rel = db.Accounts.Where(c => c.UserName == acc.UserName && c.Password == Userpass).Count();
                if (Rel == 1)
                {
                    FormsAuthentication.SetAuthCookie(acc.UserName, true);
                    return RedirectToAction("Index", "Monhocs");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không chính xác");
                }
            }
            return View(acc);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}