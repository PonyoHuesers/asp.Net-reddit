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
        //Declaring redditDB as ADO.Net Entity Data Model that allows CRUD operations to Azure database.
        private RedditEntities redditDB;
        public CommentController()
        {
            redditDB = new RedditEntities();
        }

        protected override void Dispose(bool disposing)
        {
            redditDB.Dispose();
        }

        //This action records ratings on the specified reply, determined by if the up or down arrow was clicked.
        public ActionResult ReplyRating(int id, string arrow)
        {
            var reply = redditDB.Replies.Single(c => c.Id == id);
            var thread = redditDB.Threads.Single(c => c.Id == reply.ThreadId);
            var replyList = redditDB.Replies.Where(c => c.ThreadId == thread.Id);
            var replyActualList = redditDB.Replies.Where(c => c.ThreadId == thread.Id).ToList();

            if (arrow == "up")
                reply.Rating++;
            if ((arrow == "down") && (reply.Rating > 0))
                reply.Rating--;

            redditDB.SaveChanges();

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
            var parentOfReply = redditDB.Replies.Single(c => c.Id == submit); 
            var tierAfterParent = parentOfReply.Tier + 1;
            reply.Replies.Tier = reply.Replies.Tier + tierAfterParent;

            reply.Replies.Created = DateTime.Now;
            reply.Replies.Creator = ControllerContext.HttpContext.User.Identity.Name;
            reply.Replies.ThreadId = reply.Threads.Id;

            var user = redditDB.Users.SingleOrDefault(c => c.Name == ControllerContext.HttpContext.User.Identity.Name);
            if (user == null)
            {
                var newUser = new User {Name = ControllerContext.HttpContext.User.Identity.Name};
                redditDB.Users.Add(newUser);
            }
            
            redditDB.Replies.Add(reply.Replies);
            redditDB.SaveChanges();

            redditDB.Replies.AddOrUpdate(parentOfReply);
            redditDB.SaveChanges();

            var currentPKey = reply.Replies.Id;
            int digitsOfPKey = (currentPKey == 0) ? 1 : (int)Math.Log10(currentPKey) + 1;
            string length = new string('0', digitsOfPKey);

            //Where length = "0", "00", "000", etc. based on digitsofPKey value.

            var var1 = submit.ToString(length); 
            var var2 = reply.Replies.Id;
            var var3 = parentOfReply.Key;
            var format = "";
            if (reply.Replies.Tier == 1) //This implies that you just concatenate the root comment id
                format = var1 + var2;    //with the current reply's id to form the key.

            if (reply.Replies.Tier > 1)  //Any deeper than the first reply on the base comment and you
                format = var3 + var2;    //concatenate the path of the key to the current id being used.

            reply.Replies.Key = format;
            redditDB.Replies.AddOrUpdate(reply.Replies);
            redditDB.SaveChanges();

            ModelState.Clear();          //This clears the comment and reply text boxes after submittals.

            var thread = redditDB.Threads.Single(c => c.Id == reply.Threads.Id);
            var replyList = redditDB.Replies.Where(c => c.ThreadId == reply.Threads.Id);
            var replyActualList = redditDB.Replies.Where(c => c.ThreadId == reply.Threads.Id).ToList();

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
            comment.Replies.Creator = ControllerContext.HttpContext.User.Identity.Name;
            comment.Replies.ThreadId = comment.Threads.Id;
            comment.Replies.Tier = 0;
            comment.Replies.Created = DateTime.Now;
            redditDB.Replies.Add(comment.Replies);
            redditDB.SaveChanges();

            var user = redditDB.Users.SingleOrDefault(c => c.Name == ControllerContext.HttpContext.User.Identity.Name);
            if (user == null)
            {
                var newUser = new User {Name = ControllerContext.HttpContext.User.Identity.Name};
                redditDB.Users.Add(newUser);
            }
            
            comment.Replies.Key = comment.Replies.Id.ToString();
            redditDB.Replies.AddOrUpdate(comment.Replies);
            redditDB.SaveChanges();

            ModelState.Clear();          //This clears the comment and reply text boxes after submittals.

            var thread = redditDB.Threads.Single(c => c.Id == comment.Replies.ThreadId);
            var replyList = redditDB.Replies.Where(c => c.ThreadId == thread.Id);
            var replyActualList = redditDB.Replies.Where(c => c.ThreadId == thread.Id).ToList();

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