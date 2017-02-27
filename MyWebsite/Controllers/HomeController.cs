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
        //Used for testing.
        public ActionResult Refactor()
        {
            return View();
        }

        //This action displays a Form, where the threads are created and submitted at.
        public ActionResult Form()
        {
            return View();
        }
        

        [AllowAnonymous]
        public ActionResult Hot()
        {
            return View(new ThreadViewModel("Hot"));
        }

       
        [AllowAnonymous]
        public ActionResult Newest()
        {
            //Used for seeding the database.
            Thread t1 = new Thread()
            {
                Username = new Username() { Name = "INactiveJoe" },
                Name = "No rating here",
                Created = DateTime.Now
            };

            //_context.Threads.Add(t1);
            //_context.SaveChanges();

            return View(new ThreadViewModel("Newest"));
        }

        
        [AllowAnonymous]
        public ActionResult Rising()
        {
            return View(new ThreadViewModel("Rising"));
        }

        
        [AllowAnonymous]
        public ActionResult Controversial()
        {
            return View(new ThreadViewModel("Controversial"));
        }
    }
}