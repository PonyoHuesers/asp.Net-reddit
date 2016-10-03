using System.Linq;
using System.Web.Mvc;
using MyWebsite.Models;
using MyWebsite.ViewModels;

namespace MyWebsite.Controllers
{
    public class HomeController : Controller
    {
        //Declaring variable for use with and access to DBSets
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //An action redirects to Form which returns its view, where the threads are created and submitted.
        public ActionResult Form()
        {
            return View();
        }

        //Displays all threads order in descending order based on their rating.
        [AllowAnonymous]
        public ActionResult Hot()
        {
            var threads = _context.Threads.ToList();

            var view = new NewThreadViewModel
            {
                ThreadList = threads
            };

            return View(view);
        }

        //This page displays all threads made within 48 hours, ordered in descending order based on their rating.
        [AllowAnonymous]
        public ActionResult New()
        {
            var threads = _context.Threads.ToList();

            var view = new NewThreadViewModel
            {
                ThreadList = threads
            };

            return View(view);
        }

        //This page displays threads made within 24 hours that have risen in popularity with a net rating greater than 0.
        [AllowAnonymous]
        public ActionResult Rising()
        {
            var threads = _context.Threads.ToList();

            var view = new NewThreadViewModel
            {
                ThreadList = threads
            };

            return View(view);
        }

        //This page displays threads with ratings of >2 in both positive and negative votes.
        [AllowAnonymous]
        public ActionResult Controversial()
        {
            var threads = _context.Threads.ToList();

            var view = new NewThreadViewModel
            {
                ThreadList = threads
            };

            return View(view);
        }
    }
}