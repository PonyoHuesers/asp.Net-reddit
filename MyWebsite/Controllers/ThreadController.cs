using System;
using System.Linq;
using System.Web.Mvc;
using MyWebsite.Models;
using MyWebsite.ViewModels;

namespace MyWebsite.Controllers
{
    public class ThreadController : Controller
    {
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
        [AllowAnonymous]
        public ActionResult CreateThread(Thread thread)
        {
            var creator = ControllerContext.HttpContext.User.Identity.Name;
            thread.Username.Name = creator;
            thread.Created = DateTime.Now;
            var user = _context.Usernames.SingleOrDefault(c => c.Name == creator);
            if (user == null)
            {
                var newUser = new Username {Name = creator};
                _context.Usernames.Add(newUser);
            }

            _context.Threads.Add(thread);
            _context.SaveChanges();
            
            return View("~/Views/Home/Hot.cshtml", new ThreadViewModel("Hot"));
        }

        [AllowAnonymous]
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
        [AllowAnonymous]
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

            var threadList = _context.Threads.Include("Username").ToList();
            _context.SaveChanges();

            if (location == "Newest")
                return View("~/Views/Home/Newest.cshtml", new ThreadViewModel("Newest"));

            if (location == "Rising")
                return View("~/Views/Home/Rising.cshtml", new ThreadViewModel("Rising"));

            if (location == "Controversial")
                return View("~/Views/Home/Controversial.cshtml", new ThreadViewModel("Controversial"));

            return View("~/Views/Home/Hot.cshtml", new ThreadViewModel("Hot"));
        }
    }
}