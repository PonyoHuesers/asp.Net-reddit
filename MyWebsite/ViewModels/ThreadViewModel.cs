using MyWebsite.Data;
using MyWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebsite.ViewModels
{
    public class ThreadViewModel
    {
        public string ThreadLocation { get; set; }

        public ThreadViewModel(string threadLocation)
        {
            ThreadLocation = threadLocation;
        }

        public IEnumerable<Thread> ThreadList
        {
            get
            {
                return ThreadRepository.LoadThreadList(ThreadLocation);                      
            }
        }        
    }
}