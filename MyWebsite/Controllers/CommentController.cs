using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
using MyWebsite.Models;
using MyWebsite.ViewModels;

namespace MyWebsite.Controllers
{
    public class CommentController : Controller
    {
        //Declaring variable for use with and access to DBSets
        private readonly ApplicationDbContext _context;

        public CommentController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //This action records ratings on the specified reply, determined by if the up or down arrow was clicked.
        public ActionResult ReplyRating(int id, string arrow)
        {
            var reply = _context.Replies.Single(c => c.Id == id);
            var thread = _context.Threads.Single(c => c.Id == reply.ThreadId);
            var replyList = _context.Replies.Where(c => c.ThreadId == thread.Id);
            var replyActualList = _context.Replies.Where(c => c.ThreadId == thread.Id).ToList();

            if (arrow == "up")
                reply.Rating++;
            if ((arrow == "down") && (reply.Rating > 0))
                reply.Rating--;

            _context.SaveChanges();

            var view = new NewThreadViewModel
            {
                Threads = thread,
                RepliesList = replyList,
                RepliesActualList = replyActualList
            };

            return View("~/Views/Thread/ViewThread.cshtml", view);
        }

        //This action saves a comment when clicking the reply link on-side each comment in the thread.
        [HttpPost]
        public ActionResult SaveReplyOnComment(NewThreadViewModel reply, int submit)
        {
            var test = _context.Replies.Single(c => c.Id == submit); //parent of comment
            var i = test.Tier + 1;
            reply.Replies.Tier = reply.Replies.Tier + i;

            reply.Replies.Created = DateTime.Now;
            reply.Replies.Creator = ControllerContext.HttpContext.User.Identity.Name;
            reply.Replies.ThreadId = reply.Threads.Id;

            var user = _context.DbUsers.SingleOrDefault(c => c.Name == ControllerContext.HttpContext.User.Identity.Name);
            if (user == null)
            {
                var newUser = new User {Name = ControllerContext.HttpContext.User.Identity.Name};
                _context.DbUsers.Add(newUser);
            }


            _context.Replies.Add(reply.Replies);
            _context.SaveChanges();

            _context.Replies.AddOrUpdate(test);
            _context.SaveChanges();

            var var1 = submit.ToString("000");
            var var2 = reply.Replies.Id;
            var var3 = test.Key;
            var format = "";
            if (reply.Replies.Tier == 1)
                format = var1 + var2;

            if (reply.Replies.Tier > 1)
                format = var3 + var2;

            reply.Replies.Key = format;
            _context.Replies.AddOrUpdate(reply.Replies);
            _context.SaveChanges();

            ModelState.Clear();

            var thread = _context.Threads.Single(c => c.Id == reply.Threads.Id);
            var replyList = _context.Replies.Where(c => c.ThreadId == reply.Threads.Id);
            var replyActualList = _context.Replies.Where(c => c.ThreadId == reply.Threads.Id).ToList();

            var view = new NewThreadViewModel
            {
                Threads = thread,
                RepliesList = replyList,
                RepliesActualList = replyActualList
            };


            return View("~/Views/Thread/ViewThread.cshtml", view);
        }

        //This action saves the root comment in each thread view
        [HttpPost]
        public ActionResult SaveComment(NewThreadViewModel comment)
        {
            comment.Replies.Creator = ControllerContext.HttpContext.User.Identity.Name;
            comment.Replies.ThreadId = comment.Threads.Id;
            comment.Replies.Tier = 0;
            comment.Replies.Created = DateTime.Now;
            _context.Replies.Add(comment.Replies);
            _context.SaveChanges();

            var user = _context.DbUsers.SingleOrDefault(c => c.Name == ControllerContext.HttpContext.User.Identity.Name);
            if (user == null)
            {
                var newUser = new User {Name = ControllerContext.HttpContext.User.Identity.Name};
                _context.DbUsers.Add(newUser);
            }

            //previously: comment.Replies.Key = comment.Replies.Id
            comment.Replies.Key = comment.Replies.Id.ToString();
            _context.Replies.AddOrUpdate(comment.Replies);
            _context.SaveChanges();

            ModelState.Clear();

            var thread = _context.Threads.Single(c => c.Id == comment.Replies.ThreadId);
            var replyList = _context.Replies.Where(c => c.ThreadId == thread.Id);
            var replyActualList = _context.Replies.Where(c => c.ThreadId == thread.Id).ToList();

            var view = new NewThreadViewModel
            {
                Threads = thread,
                RepliesList = replyList,
                RepliesActualList = replyActualList
            };

            return View("~/Views/Thread/ViewThread.cshtml", view);
        }
    }
}