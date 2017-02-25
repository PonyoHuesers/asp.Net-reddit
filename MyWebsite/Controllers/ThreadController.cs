using System;
using System.Linq;
using System.Web.Mvc;
using MyWebsite.Models;
using MyWebsite.ViewModels;

namespace MyWebsite.Controllers
{
    public class ThreadController : Controller
    {
        //Declaring _context as ADO.Net Entity Data Model that allows CRUD operations to Azure database.
        private Context _context;
        public ThreadController()
        {
            _context = new Context();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        //This action is where the Form view in HomeController submits to.
        //The information from the new thread is passed here where the homepage is loaded
        //with the new thread in the list of threads.
        public ActionResult CreateThread(Thread thread)
        {
            var creator = ControllerContext.HttpContext.User.Identity.Name;
            //put back in: thread.Username.Name = creator;
            thread.Created = DateTime.Now;
            var user = _context.Usernames.SingleOrDefault(c => c.Name == creator);
            if (user == null)
            {
                var newUser = new Username {Name = creator};
                _context.Usernames.Add(newUser);
            }

            _context.Threads.Add(thread);
            _context.SaveChanges();

            var threadList = _context.Threads.ToList();
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
            var thread = _context.Threads.SingleOrDefault(c => c.Id == id);
            var replyList = _context.Comments.Where(c => c.ThreadId == id);
            var replyActualList = _context.Comments.Where(c => c.ThreadId == id).ToList();
            
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
            var thread = _context.Threads.Single(c => c.Id == id);

            if (arrow == "up")
            {
                thread.Rating++;
                thread.UpvoteCount++;
            }

            if ((arrow == "down") && (thread.Rating > 0))
            {
                thread.Rating--;
                thread.DownvoteCount++;
            }

            var threadList = _context.Threads.ToList();
            var view = new NewThreadViewModel
            {
                ThreadList = threadList
            };


            _context.SaveChanges();

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