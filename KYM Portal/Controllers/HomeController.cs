using KYM_Portal.Models;
using KYM_Portal.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KYM_Portal.Controllers
{
    public class HomeController : Controller
    {
        Common common = new Common();
        public ActionResult Index()
        {
            if (Session["empNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model)
        {
            Boolean exists = false;
            try
            {
                var users = common.nav.HRPortalUsers.Where(r => r.employeeNo == model.Username && r.password == model.Password);

                foreach (var item in users)
                {
                    exists = true;
                    Session["empNo"] = item.employeeNo;
                    Session["name"] = item.First_Name + " " + item.Middle_Name + " " + item.Last_Name;

                    return RedirectToAction("Index", "Home");
                }


                if (exists == false)
                {
                    TempData["error"] = "Invalid login credentials";
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(Login model)
        {
            try
            {
                String status = Common.ObjNav.ResetPassword(model.Username);
                String[] info = status.Split('*');
                
                if (info[0] == "success")
                {
                    TempData["success"] = info[1];
                    return RedirectToAction("ForgotPassword", "Home");
                }
                else
                {
                    TempData["error"] = info[1];
                    return RedirectToAction("ForgotPassword", "Home");
                }
            }
            catch (Exception t)
            {
                TempData["error"] = t.Message;
            }

            return View(model);
        }

        public ActionResult Register()
        {

            return View();
        }

        public ActionResult LogOut()
        {
            Session["empNo"] = null;
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");

        }



    }
}