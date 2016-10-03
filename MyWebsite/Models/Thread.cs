using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebsite.Models
{
    public class Thread
    {
        public Thread()
        {
            Rating = 0;
            Used = 0;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime Created { get; set; }
        public string Creator { get; set; }
        public int upvoteCount { get; set; }
        public int downvoteCount { get; set; }
        public int Used { get; set; }
    }
    
    
}