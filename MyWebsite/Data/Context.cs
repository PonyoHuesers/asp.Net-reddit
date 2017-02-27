using Microsoft.AspNet.Identity.EntityFramework;
using MyWebsite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MyWebsite
{
    public class Context : DbContext //DBContext is basically code representation of my database
    {
        public Context()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
        }

        public static void AddComment()
        {
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                
            }
        }

        public static IEnumerable<Thread> LoadThreadList(string threadLocation)
        {
            using (Context _context = new Context())
            {
                if(threadLocation == "Newest")
                {
                    return _context.Threads.Include("Username")
                                           .ToList()
                                           .OrderByDescending(t => t.Created)
                                           .Take(5);
                }

                if (threadLocation == "Hot")
                {
                    return _context.Threads.Include("Username")
                                           .ToList()
                                           .OrderByDescending(t => t.Rating)
                                           .Take(10);
                }

                if (threadLocation == "Controversial")
                {
                    return _context.Threads.Include("Username")
                                           .ToList()
                                           .Where(t => t.UpvoteCount > 0 && t.DownvoteCount > 0)
                                           .Take(5);
                }

                if (threadLocation == "Rising")
                {
                    return _context.Threads.Include("Username")
                                           .ToList()
                                           .OrderByDescending(t => t.Rating)
                                           .Take(5);
                }

                return null;                
            }
        }

        public static string ElapsedTime(DateTime submittedAt)
        {
            TimeSpan elapsedTime = DateTime.Now.Subtract(submittedAt);

            if(elapsedTime.Days >= 1)
            {
                return $"Submitted: {elapsedTime.Days} days and {elapsedTime.Hours} hours ago by ";
            }
            else
            {
                return $"Submitted: {elapsedTime.Hours} hours and {elapsedTime.Minutes} mintues ago by ";
            }
        }

        
        public DbSet<Username> Usernames { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}