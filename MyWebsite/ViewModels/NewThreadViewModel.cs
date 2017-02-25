using System.Collections.Generic;
using MyWebsite.Models;

namespace MyWebsite.ViewModels
{
    public class NewThreadViewModel
    {
        public Thread Threads { get; set; }
        public Comment Comments { get; set; }
        public Username UserObject { get; set; }
        public IEnumerable<Thread> ThreadList { get; set; }
        public IEnumerable<Comment> RepliesList { get; set; }
        public List<Comment> RepliesActualList { get; set; }
        public List<Thread> ThreadsActualList { get; set; }
        public string PlaceHolder { get; set; }
    }
}