using System;
using System.ComponentModel.DataAnnotations;

namespace MyWebsite.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int ThreadId { get; set; }
        public int UsernameId { get; set; }
        [Display(Name = "Comment")]
        public string Name { get; set; }        
        public int Rating { get; set; }
        public int Tier { get; set; }
        public DateTime Created { get; set; }
        public string Key { get; set; }

        public Thread Thread { get; set; }
        public Username Username { get; set; }
    }
}