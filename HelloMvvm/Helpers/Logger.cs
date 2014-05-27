using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using log4net.Config;

namespace HelloMvvm.Helpers
{
    public static class Logger
    {
        private static ILog logger = null;
        private static ILog Instance {
            get
            {
                if (logger == null)
                {
                    logger = LogManager.GetLogger(typeof(App));
                    XmlConfigurator.Configure();
                }
                return logger;
            } 
        }

        public static void Info(string message)
        {
            if (Instance.IsInfoEnabled)
                Instance.Info(message);
        }

        public static void Warn(string message)
        {
            if (Instance.IsWarnEnabled)
                Instance.Warn(message);
        }

        public static void Error(string message)
        {
            if (Instance.IsErrorEnabled)
                Instance.Error(message);
        }

        public static void Fatal(string message)
        {
            if (Instance.IsFatalEnabled)
                Instance.Fatal(message);
        }

        public static void Debug(string message)
        {
            if (Instance.IsDebugEnabled)
                Instance.Debug(message);
        }

        public static void Trace(string message)
        {
            System.Diagnostics.Trace.Write(message);
        }

    }
}
