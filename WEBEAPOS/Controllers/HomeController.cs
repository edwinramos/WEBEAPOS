using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBEAPOS.DataAccess.BusinessLayer;
using WEBEAPOS.DataAccess.DataModels;

namespace WEBEAPOS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();

        }

        public ActionResult LogIn()
        {
            return View(new TBL_USERS());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(TBL_USERS user)
        {
            UserHelper userHelper = new UserHelper();
            if (ModelState.IsValid)
            {
                var dbUser = userHelper.GetAll().Where(a => a.UserName.Equals(user.UserName) && a.Password.Equals(userHelper.Encrypt(user.Password))).FirstOrDefault();
                if (dbUser != null)
                {
                    Session["UserId"] = dbUser.UserId.ToString();
                    Session["UserName"] = dbUser.UserName.ToString();
                    return RedirectToAction("Index");
                }
            }
            return View(user);
        }

        public ActionResult NewUser()
        {
            return View(new TBL_USERS());
        }

        [HttpPost]
        public ActionResult NewUser(TBL_USERS user)
        {
            UserHelper userHelper = new UserHelper();
            userHelper.Save(user);
            return RedirectToAction("LogIn");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}