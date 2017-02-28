using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebsite.Models
{
    public class Thread
    {
        public int Id { get; set; }        
        public int UsernameId { get; set; }
        [Display(Name = "Thread")]
        public string Name { get; set; }
        [Display(Name = "Comment")]
        public string OpeningComment { get; set; }
        public int Rating { get; set; }
        public DateTime Created { get; set; }
        public int UpvoteCount { get; set; }
        public int DownvoteCount { get; set; }
        
        public Username Username { get; set; }
    }
}