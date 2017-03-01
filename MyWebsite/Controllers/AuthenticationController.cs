using MyWebsite.Data;
using MyWebsite.Models;
using MyWebsite.ViewModels;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MyWebsite.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : Controller
    {
        public ActionResult Logout()
        {
            Session.Clear();
            return View("~/Views/Home/Hot.cshtml", new ThreadViewModel("Hot"));
        }

        // GET: /Authentication/Login
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        // POST: /Authentication/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            return View();
        }
        
        // GET: /Authentication/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: /AccountAuthentication/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            UserRepository.AddUsernameToDb(model.Username, model.Password);

            return View("~/Views/Home/Hot.cshtml", new ThreadViewModel("Hot"));
        }

        //Used on Register page to check if username already exists.
        [HttpPost]
        public JsonResult DoesUsernameExist(string username)
        {
            return Json(UserRepository.GetUser(username) == null);
        }


    }    
}