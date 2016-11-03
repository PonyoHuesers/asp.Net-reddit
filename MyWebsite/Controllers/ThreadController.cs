using System;
using System.Linq;
using System.Web.Mvc;
using MyWebsite.Models;
using MyWebsite.ViewModels;

namespace MyWebsite.Controllers
{
    public class ThreadController : Controller
    {
        //Declaring redditDB as ADO.Net Entity Data Model that allows CRUD operations to Azure database.
        private RedditEntities redditDB;
        public ThreadController()
        {
            redditDB = new RedditEntities();
        }

        protected override void Dispose(bool disposing)
        {
            redditDB.Dispose();
        }

        [HttpPost]
        //This action is where the Form view in HomeController submits to.
        //The information from the new thread is passed here where the homepage is loaded
        //with the new thread in the list of threads.
        public ActionResult CreateThread(Thread thread)
        {
            var creator = ControllerContext.HttpContext.User.Identity.Name;
            thread.Creator = creator;
            thread.Created = DateTime.Now;
            var user = redditDB.Users.SingleOrDefault(c => c.Name == creator);
            if (user == null)
            {
                var newUser = new User {Name = creator};
                redditDB.Users.Add(newUser);
            }

            redditDB.Threads.Add(thread);
            redditDB.SaveChanges();

            var threadList = redditDB.Threads.ToList();
            var view = new NewThreadViewModel
            {
                ThreadList = threadList
            };

            return View("~/Views/Home/Hot.cshtml", view);
        }

        [AllowAnonymous]
        //This action shows all the comments in any of the selected threads.
        public ActionResult ViewThread(int id)
        {
            var thread = redditDB.Threads.SingleOrDefault(c => c.Id == id);
            var replyList = redditDB.Replies.Where(c => c.ThreadId == id);
            var replyActualList = redditDB.Replies.Where(c => c.ThreadId == id).ToList();
            
            if (thread == null)
                return HttpNotFound();

            var viewModel = new NewThreadViewModel
            {
                Threads = thread,
                RepliesList = replyList,
                RepliesActualList = replyActualList
            };

            return View(viewModel);
        }

        //This action gives the rated thread a higher or lower rating, depending on
        //whether it was upvoted or downvoted. It returns the page it was on when you voted.
        public ActionResult ThreadRating(int id, string arrow, string location)
        {
            var thread = redditDB.Threads.Single(c => c.Id == id);

            if (arrow == "up")
            {
                thread.Rating++;
                thread.upvoteCount++;
            }

            if ((arrow == "down") && (thread.Rating > 0))
            {
                thread.Rating--;
                thread.downvoteCount++;
            }

            var threadList = redditDB.Threads.ToList();
            var view = new NewThreadViewModel
            {
                ThreadList = threadList
            };


            redditDB.SaveChanges();

            if (location == "New")
                return View("~/Views/Home/New.cshtml", view);

            if (location == "Rising")
                return View("~/Views/Home/Rising.cshtml", view);

            if (location == "Controversial")
                return View("~/Views/Home/Controversial.cshtml", view);

            return View("~/Views/Home/Hot.cshtml", view);
        }
    }
}