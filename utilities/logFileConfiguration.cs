using log4net.Appender;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCargoUIAutomation.utilities
{
    public class LogFileConfiguration
    {
        public void ConfigureLog4Net()
        {
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();

            PatternLayout patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = "%date [%thread] %-5level %logger - %message%newline";
            patternLayout.ActivateOptions();
           
            //string projectDirectory = System.IO.Path.GetFullPath(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "..\\..\\..\\"));
            string logFilePath = @"\\seavvfile1\projectmgmt_pmo\iCargoAutomationReports\Logs\Log"+DateTime.Now.ToString("yyyyMMdd_HHmmss")+@"logfile.log";
            Console.WriteLine("Log file path: " + logFilePath);
            FileAppender appender = new FileAppender();
            appender.AppendToFile = true;
            appender.File = logFilePath;
            appender.Layout = patternLayout;            
            appender.ActivateOptions();
            hierarchy.Root.AddAppender(appender);

            hierarchy.Root.Level = log4net.Core.Level.All;
            hierarchy.Configured = true;
        }

    }
}
