using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace Project
{
    class MyLogger
    {
        private const string FILE_EXT = ".txt";
        private readonly string datetimeFormat;
        private readonly string logFilename;
        private readonly string path;
        private static int counter;
        private readonly string getMethod;
        private readonly string getAssembley;
        private readonly string threadName;

        public MyLogger()
        {
            getAssembley = System.Reflection.Assembly.GetExecutingAssembly().GetName().FullName;
            getMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Thread thread = Thread.CurrentThread;
            threadName = thread.Name;
            datetimeFormat = "yyyyMMddHH";
            logFilename = $"log{DateTime.Now.ToString(datetimeFormat)}[{counter}]{FILE_EXT}";
            path = @$"C:\Users\timos\source\Project\Solution\Project\logs\{logFilename}";
            if (File.Exists(path))
            {
                WriteLine(DateTime.Now.ToString(datetimeFormat) + " ", false);
                if (logFilename.Length > 30000)
                {
                    counter++;
                    logFilename = $"{DateTime.Now.ToString(datetimeFormat)}[{counter}]{FILE_EXT}";
                    WriteLine(DateTime.Now.ToString(path) + " ", false);
                }
            }
        }
        public void Debug(string text)
        {
            WriteFormattedLog(LogLevel.DEBUG, text);
        }
        public void Error(string text)
        {
            WriteFormattedLog(LogLevel.ERROR, text);
        }
        public void Info(string text)
        {
            WriteFormattedLog(LogLevel.INFO, text);
        }
        private void WriteLine(string text, bool append = true)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path, append, System.Text.Encoding.UTF8))
                {
                    if (!string.IsNullOrEmpty(text))
                    {
                        writer.WriteLine(text);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void WriteFormattedLog(LogLevel level, string text)
        {
            string pretext;
            switch (level)
            {
                case LogLevel.INFO:
                    pretext = $"{DateTime.Now.ToString(datetimeFormat)} [{getAssembley}][{getMethod}][{threadName}][INFO] ";
                    break;
                case LogLevel.DEBUG:
                    pretext = $"{DateTime.Now.ToString(datetimeFormat)} [{getAssembley}][{getMethod}][{threadName}][DEBUG] ";
                    break;
                case LogLevel.ERROR:
                    pretext = $"{DateTime.Now.ToString(datetimeFormat)} [{getAssembley}][{getMethod}][{threadName}][ERROR] ";
                    break;
                default:
                    pretext = "";
                    break;
            }
            WriteLine(pretext + text);
        }
        private enum LogLevel
        {
            INFO,
            DEBUG,
            ERROR
        }
    }
}
