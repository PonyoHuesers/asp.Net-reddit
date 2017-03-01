using System;
using System.Collections.Generic;

namespace MyWebsite.Models
{
    public class Username
    {
        public Username()
        {
            Threads = new List<Thread>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public byte[] EncodedPassword { get; set; }

        //Because a Username can belong to many Threads.
        public ICollection<Thread> Threads { get; set; }
    }
}