﻿using System.Web.Mvc;
using MyWebsite.Models;
using MyWebsite.ViewModels;
using System;
using MyWebsite.Data;

//Project created by: Joshua Landreneau
//Finished and deployed to Azure: 10/5/2016
//Refactoring began: 2/24/2017

namespace MyWebsite.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        //Used for testing.
        public ActionResult Refactor()
        {
            return View();
        }

        //This action displays a Form, where the threads are created and submitted at.
        public ActionResult CreateThread()
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