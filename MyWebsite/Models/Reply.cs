using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebsite.Models
{
    public class Reply
    {
        public Reply()
        {
            Rating = 0;
            Tier = 0;
            Used = 0;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ThreadId { get; set; }
        public int Rating { get; set; }
        public string Creator { get; set; }
        public int Tier { get; set; }
        public string Key { get; set; }
        public DateTime Created { get; set; }
        public int Used { get; set; }
    }
}