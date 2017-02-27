using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebsite.Data
{
    public static class HelperMethods
    {
        public static string ElapsedTime(DateTime submittedAt)
        {
            TimeSpan elapsedTime = DateTime.Now.Subtract(submittedAt);

            if (elapsedTime.Days >= 1)
            {
                return $"Submitted: {elapsedTime.Days} days and {elapsedTime.Hours} hours ago by ";
            }
            else
            {
                return $"Submitted: {elapsedTime.Hours} hours and {elapsedTime.Minutes} mintues ago by ";
            }
        }
    }
}