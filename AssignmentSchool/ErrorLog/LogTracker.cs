using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentSchool.ErrorLog
{
    public class LogTracker
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void Error(Exception ex, string user)
        {
            logger.Error("Error from {0} --- {1} {2} {3} \r\n --------------------------------------------------", user, ex.Message, ex.Source, ex.StackTrace);
        }

        public static void Error(string message, string user)
        {
            logger.Error(message + " : " + user);
        }
    }
}