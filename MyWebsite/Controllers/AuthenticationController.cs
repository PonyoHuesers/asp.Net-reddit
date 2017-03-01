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
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return View("~/Views/Home/Hot.cshtml", new ThreadViewModel("Hot"));
        }

        public ActionResult Register()
        {
            return View();
        }

        
    }    
}