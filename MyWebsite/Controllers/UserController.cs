using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWebsite.Models;
using MyWebsite.ViewModels;

namespace MyWebsite.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext _context;

        public UserController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [AllowAnonymous]
        public ActionResult ViewUserPage(string creatorId)
        {
            var threadList = _context.Threads.Where(c => c.Creator == creatorId).OrderByDescending(c=>c.Created);
            var replyList = _context.Replies.Where(c => c.Creator == creatorId).OrderByDescending(c=>c.Created);
            var threadActualList = _context.Threads.ToList();
            var user = _context.DbUsers.SingleOrDefault(c => c.Name == creatorId);

            var view = new NewThreadViewModel()
            {
                ThreadList = threadList,
                ThreadsActualList = threadActualList,
                RepliesList = replyList,
                UserObject = user
            };

            return View(view);
        }
    }
}