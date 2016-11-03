using System.Linq;
using System.Web.Mvc;
using MyWebsite.Models;
using MyWebsite.ViewModels;

namespace MyWebsite.Controllers
{
    public class UserController : Controller
    {
        private RedditEntities redditDB;
        public UserController()
        {
            redditDB = new RedditEntities();
        }

        protected override void Dispose(bool disposing)
        {
            redditDB.Dispose();
        }

        [AllowAnonymous]
        public ActionResult ViewUserPage(string creatorId)
        {
            var threadList = redditDB.Threads.Where(c => c.Creator == creatorId).OrderByDescending(c => c.Created);
            var replyList = redditDB.Replies.Where(c => c.Creator == creatorId).OrderByDescending(c => c.Created);
            var threadActualList = redditDB.Threads.ToList();
            var user = redditDB.Users.SingleOrDefault(c => c.Name == creatorId);

            var view = new NewThreadViewModel
            {
                ThreadList = threadList,
                ThreadsActualList = threadActualList,
                RepliesList = replyList,
                UserObject = user,
                PlaceHolder = creatorId
            };

            return View(view);
        }
    }
}