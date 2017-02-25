using Microsoft.AspNet.Identity.EntityFramework;
using MyWebsite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public DbSet<Username> Usernames { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}