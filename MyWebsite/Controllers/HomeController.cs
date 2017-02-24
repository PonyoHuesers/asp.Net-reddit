using System.Linq;
using System.Web.Mvc;
using MyWebsite.Models;
using MyWebsite.ViewModels;

//Project created by: Joshua Landreneau
//Finished and deployed to Azure: 10/5/2016

    //reminder to remove custom error messages in web.config
    //test 2

namespace MyWebsite.Controllers
{
    public class HomeController : Controller
    {
        //Declaring redditDB as ADO.Net Entity Data Model that allows CRUD operations to Azure database.
        private RedditEntities redditDB;
        public HomeController()
        {
            redditDB = new RedditEntities();
        }

        protected override void Dispose(bool disposing)
        {
            redditDB.Dispose();
        }

        //This action displays a Form, where the threads are created and submitted at.
        public ActionResult Form()
        {
            return View();
        }

        //Displays all threads order in descending order based on their rating.
        [AllowAnonymous]
        public ActionResult Hot()
        {
            var threads = redditDB.Threads.ToList();

            var view = new NewThreadViewModel
            {
                ThreadList = threads
            };

            return View(view);
        }

       
        [AllowAnonymous]
        //This page displays all threads made within 48 hours, ordered in descending order based on their rating.
        public ActionResult New()
        {
            var threads = redditDB.Threads.ToList();

            var view = new NewThreadViewModel
            {
                ThreadList = threads
            };

            return View(view);
        }

        
        [AllowAnonymous]
        //This page displays threads made within 24 hours that have risen in popularity with a net rating greater than 0.
        public ActionResult Rising()
        {
            var threads = redditDB.Threads.ToList();

            var view = new NewThreadViewModel
            {
                ThreadList = threads
            };

            return View(view);
        }

        
        [AllowAnonymous]
        //This page displays threads with ratings of greater than 2 in both positive and negative votes.
        public ActionResult Controversial()
        {
            var threads = redditDB.Threads.ToList();

            var view = new NewThreadViewModel
            {
                ThreadList = threads
            };

            return View(view);
        }
    }
}