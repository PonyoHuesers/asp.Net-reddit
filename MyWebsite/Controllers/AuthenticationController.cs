using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MyWebsite.Data;
using MyWebsite.Models;
using MyWebsite.ViewModels;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyWebsite.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : Controller
    {
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return Redirect("~/");
        }

        // GET: /Authentication/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: /Authentication/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            bool result = UserRepository.VerifyPassword(model.Username, model.Password);

            if(result)
            {
                HttpCookie cookie = FormsAuthentication.GetAuthCookie(model.Username, false);
                Response.Cookies.Add(cookie);

                return Redirect("~/");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }            
        } 
                
        // GET: /Authentication/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: /AccountAuthentication/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            UserRepository.AddUsernameToDb(model.Username, model.Password);

            HttpCookie cookie = FormsAuthentication.GetAuthCookie(model.Username, false);
            Response.Cookies.Add(cookie);

            return Redirect("~/");
        }

        //Used on Register page to check if username already exists.
        [HttpPost]
        public JsonResult DoesUsernameExist(string username)
        {
            return Json(UserRepository.GetUser(username) == null);
        }
    }    
}