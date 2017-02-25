using System;

namespace MyWebsite.Models
{
    public class Thread
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public DateTime Created { get; set; }
        public int UpvoteCount { get; set; }
        public int DownvoteCount { get; set; }
    }
}