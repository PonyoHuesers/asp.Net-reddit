using System.Linq;
using System.Web.Mvc;
using MyWebsite.Models;
using MyWebsite.ViewModels;

namespace MyWebsite.Controllers
{
    public class UserController : Controller
    {
        private Context _context;
        public UserController()
        {
            _context = new Context();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [AllowAnonymous]
        public ActionResult ViewUserPage(string creatorName)
        {
           //put back in: var threadList = _context.Threads.Where(c => c.Username.Name == creatorName).OrderByDescending(c => c.Created);
            //put back in: var replyList = _context.Comments.Where(c => c.Username.Name == creatorName).OrderByDescending(c => c.Created);
            var threadActualList = _context.Threads.ToList();
            var user = _context.Usernames.SingleOrDefault(c => c.Name == creatorName);

            var view = new NewThreadViewModel
            {
                //put back in: ThreadList = threadList,
                ThreadsActualList = threadActualList,
                //put back in: RepliesList = replyList,
                UserObject = user,
                PlaceHolder = creatorName
            };

            return View(view);
        }
    }
}