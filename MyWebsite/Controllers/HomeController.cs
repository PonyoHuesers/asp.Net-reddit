using System.Linq;
using System.Web.Mvc;
using MyWebsite.Models;
using MyWebsite.ViewModels;
using System.Collections.Generic;
using System;

//Project created by: Joshua Landreneau
//Finished and deployed to Azure: 10/5/2016
//Refactoring began: 2/24/2017

namespace MyWebsite.Controllers
{
    public class HomeController : Controller
    {
        private Context _context;

        public HomeController()
        {
            _context = new Context();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [AllowAnonymous]
        public ActionResult Refactor()
        {
            Username u = new Username()
            {
                Name = "joshy"                
            };
            

            _context.Usernames.Add(u);
            _context.SaveChanges();

            return View(u);
        }

        //This action displays a Form, where the threads are created and submitted at.
        public ActionResult Form()
        {
            return View();
        }

        //Displays all threads order in descending order based on their rating.
        [AllowAnonymous]
        public ActionResult Hot()
        {
            var threads = _context.Threads.ToList();
            
            var view = new NewThreadViewModel
            {
                ThreadList = threads
            };

            return View(view);
        }

       
        [AllowAnonymous]
        //This page displays all threads made within 48 hours, ordered in descending order based on their rating.
        public ActionResult New()
        {
            var threads = _context.Threads.ToList();

            var view = new NewThreadViewModel
            {
                ThreadList = threads
            };

            return View(view);
        }

        
        [AllowAnonymous]
        //This page displays threads made within 24 hours that have risen in popularity with a net rating greater than 0.
        public ActionResult Rising()
        {
            var threads = _context.Threads.ToList();

            var view = new NewThreadViewModel
            {
                ThreadList = threads
            };

            return View(view);
        }

        
        [AllowAnonymous]
        //This page displays threads with ratings of greater than 2 in both positive and negative votes.
        public ActionResult Controversial()
        {
            var threads = _context.Threads.ToList();

            var view = new NewThreadViewModel
            {
                ThreadList = threads
            };

            return View(view);
        }
    }
}