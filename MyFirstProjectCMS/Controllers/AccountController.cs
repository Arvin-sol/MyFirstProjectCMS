using DataLayer.Context;
using DataLayer.Models.ViewModels;
using DataLayer.Repositories;
using DataLayer.Services;
using MyFirstProjectCMS.Areas.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyFirstProjectCMS.Controllers
{
    public class AccountController : Controller
    {
        MyProjectContext db =  new MyProjectContext();
        IAdminLoginRepository adminLoginRepository;
        public AccountController()
        {
            adminLoginRepository = new AdminLoginRepository(db);
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AdminLoginViewModel login, string ReturnUrl = "/")
        {
            if (ModelState.IsValid)
            {
                if (adminLoginRepository.IsExistUser(login.Email, login.Password))
                {
                    FormsAuthentication.SetAuthCookie(login.Email, login.RememberMe);
                    return Redirect(ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("Email", "کاربری با این مشخصات یافت نشد");
                }
            }
            return View(login);
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}