using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWebsite.Controllers;
using MyWebsite.Models;

namespace MyWebsite.ViewModels
{
    public class NewThreadViewModel
    {
        public Thread Threads { get; set; }
        public Reply Replies { get; set; }
        public User UserObject { get; set; }
        public IEnumerable<Thread> ThreadList { get; set; }
        public IEnumerable<Reply> RepliesList { get; set; }
        public List<Reply> RepliesActualList { get; set; }
        public List<Thread> ThreadsActualList { get; set; }
        public string PlaceHolder { get; set; }
    }
}