﻿using MyWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebsite.Data
{
    public class ThreadRepository
    {
        public static void CreateThread(string username, Thread thread)
        {
            using (Context _context = new Context())
            {
                Username threadCreator = _context.Usernames.Single(u => u.Name == username);

                thread.Username = threadCreator;
                thread.Created = DateTime.Now;

                _context.Threads.Add(thread);

                _context.SaveChanges();
            }
        }

        public static IEnumerable<Thread> LoadThreadList(string threadLocation)
        {
            using (Context _context = new Context())
            {
                if (threadLocation == "Newest")
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
    }
}