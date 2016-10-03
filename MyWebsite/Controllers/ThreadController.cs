using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MyWebsite.Models;
using MyWebsite.ViewModels;

namespace MyWebsite.Controllers
{
    public class ThreadController : Controller
    {
        private ApplicationDbContext _context;

        public ThreadController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        public ActionResult CreateThread(Thread thread)
        {
            var creator = ControllerContext.HttpContext.User.Identity.Name;
            thread.Creator = creator;
            thread.Created = DateTime.Now;
            var user = _context.DbUsers.SingleOrDefault(c => c.Name == creator);
            if (user == null)
            {
                var newUser = new User() {Name = creator};
                _context.DbUsers.Add(newUser);
            }
               
           _context.Threads.Add(thread);
           _context.SaveChanges();

            var threadList = _context.Threads.ToList();
            var view = new NewThreadViewModel()
            {
                ThreadList = threadList
            };

           return View("~/Views/Home/Hot.cshtml",view);
        }

        [AllowAnonymous]
        public ActionResult ViewThread(int id)
        {
            var thread = _context.Threads.SingleOrDefault(c => c.Id == id);
           var replyList = _context.Replies.Where(c => c.ThreadId == id);
            var replyActualList = _context.Replies.Where(c => c.ThreadId == id).ToList();

            if (thread == null)
                return HttpNotFound();

            var viewModel = new NewThreadViewModel()
            {
                Threads = thread,
                RepliesList = replyList,
                RepliesActualList = replyActualList
            };
            
            return View(viewModel);
        }

        public ActionResult ThreadRating(int id, string arrow, string location)
        {
            var thread = _context.Threads.Single(c => c.Id == id);

            if (arrow == "up")
            {
                thread.Rating++;
                thread.upvoteCount++;
            }
                
            if (arrow == "down" && thread.Rating > 0)
            {
                thread.Rating--;
                thread.downvoteCount++;
            }

            var threadList = _context.Threads.ToList();
            var view = new NewThreadViewModel()
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

            return View("~/Views/Home/Hot.cshtml",view);
        }
    }
}