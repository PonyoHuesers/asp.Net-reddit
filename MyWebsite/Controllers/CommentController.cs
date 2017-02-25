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
        //Declaring _context as ADO.Net Entity Data Model that allows CRUD operations to Azure database.
        private Context _context;
        public CommentController()
        {
            _context = new Context();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //This action records ratings on the specified reply, determined by if the up or down arrow was clicked.
        public ActionResult ReplyRating(int id, string arrow)
        {
            var reply = _context.Comments.Single(c => c.Id == id);
            var thread = _context.Threads.Single(c => c.Id == reply.ThreadId);
            var replyList = _context.Comments.Where(c => c.ThreadId == thread.Id);
            var replyActualList = _context.Comments.Where(c => c.ThreadId == thread.Id).ToList();

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

        
        [HttpPost]
        //This action saves a comment when clicking the reply link on-side each comment in the thread.
        public ActionResult SaveReplyOnComment(NewThreadViewModel reply, int submit)
        {
            var parentOfReply = _context.Comments.Single(c => c.Id == submit); 
            var tierAfterParent = parentOfReply.Tier + 1;
            reply.Comments.Tier = reply.Comments.Tier + tierAfterParent;

            reply.Comments.Created = DateTime.Now;
            //put back in: reply.Comments.Username.Name = ControllerContext.HttpContext.User.Identity.Name;
            reply.Comments.ThreadId = reply.Threads.Id;

            var user = _context.Usernames.SingleOrDefault(c => c.Name == ControllerContext.HttpContext.User.Identity.Name);
            if (user == null)
            {
                var newUser = new Username {Name = ControllerContext.HttpContext.User.Identity.Name};
                _context.Usernames.Add(newUser);
            }
            
            _context.Comments.Add(reply.Comments);
            _context.SaveChanges();

            _context.Comments.AddOrUpdate(parentOfReply);
            _context.SaveChanges();

            var currentPKey = reply.Comments.Id;
            int digitsOfPKey = (currentPKey == 0) ? 1 : (int)Math.Log10(currentPKey) + 1;
            string length = new string('0', digitsOfPKey);

            //Where length = "0", "00", "000", etc. based on digitsofPKey value.

            var var1 = submit.ToString(length); 
            var var2 = reply.Comments.Id;
            var var3 = parentOfReply.Key;
            var format = "";
            if (reply.Comments.Tier == 1) //This implies that you just concatenate the root comment id
                format = var1 + var2;    //with the current reply's id to form the key.

            if (reply.Comments.Tier > 1)  //Any deeper than the first reply on the base comment and you
                format = var3 + var2;    //concatenate the path of the key to the current id being used.

            reply.Comments.Key = format;
            _context.Comments.AddOrUpdate(reply.Comments);
            _context.SaveChanges();

            ModelState.Clear();          //This clears the comment and reply text boxes after submittals.

            var thread = _context.Threads.Single(c => c.Id == reply.Threads.Id);
            var replyList = _context.Comments.Where(c => c.ThreadId == reply.Threads.Id);
            var replyActualList = _context.Comments.Where(c => c.ThreadId == reply.Threads.Id).ToList();

            var view = new NewThreadViewModel
            {
                Threads = thread,
                RepliesList = replyList,
                RepliesActualList = replyActualList
            };


            return View("~/Views/Thread/ViewThread.cshtml", view);
        }

        
        [HttpPost]
        //This action saves the root comment in each thread view.
        public ActionResult SaveComment(NewThreadViewModel comment)
        {
            //put back in: comment.Comments.Username.Name = ControllerContext.HttpContext.User.Identity.Name;
            comment.Comments.ThreadId = comment.Threads.Id;
            comment.Comments.Tier = 0;
            comment.Comments.Created = DateTime.Now;
            _context.Comments.Add(comment.Comments);
            _context.SaveChanges();

            var user = _context.Usernames.SingleOrDefault(c => c.Name == ControllerContext.HttpContext.User.Identity.Name);
            if (user == null)
            {
                var newUser = new Username {Name = ControllerContext.HttpContext.User.Identity.Name};
                _context.Usernames.Add(newUser);
            }
            
            comment.Comments.Key = comment.Comments.Id.ToString();
            _context.Comments.AddOrUpdate(comment.Comments);
            _context.SaveChanges();

            ModelState.Clear();          //This clears the comment and reply text boxes after submittals.

            var thread = _context.Threads.Single(c => c.Id == comment.Comments.ThreadId);
            var replyList = _context.Comments.Where(c => c.ThreadId == thread.Id);
            var replyActualList = _context.Comments.Where(c => c.ThreadId == thread.Id).ToList();

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