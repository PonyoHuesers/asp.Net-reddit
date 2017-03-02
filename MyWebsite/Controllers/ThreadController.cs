using System;
using System.Linq;
using System.Web.Mvc;
using MyWebsite.Models;
using MyWebsite.ViewModels;
using MyWebsite.Data;

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
        public ActionResult ThreadCreation(Thread thread)
        {
            ThreadRepository.CreateThread(User.Identity.Name, thread);
                        
            return View("~/Views/Home/Hot.cshtml", new ThreadViewModel("Hot"));
        }

        [AllowAnonymous]
        public ActionResult ViewThread(int id)
        {
            var thread = _context.Threads.Include("Username").SingleOrDefault(c => c.Id == id);
            var replyList = _context.Comments.Where(c => c.ThreadId == id);
            
            if (thread == null)
                return HttpNotFound();

            var viewModel = new NewThreadViewModel
            {
                Threads = thread,
                RepliesList = replyList
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