using log4net;
using System;

namespace SpindleSoft
{
    //todo : add to utility namespace
    
    public static class Logger
    {
        private static readonly ILog log = null;

        static Logger()
        {
            log4net.Config.XmlConfigurator.Configure();
            log = LogManager.GetLogger(typeof(Logger));
        }

        static Logger(Type type)
        {
            log = LogManager.GetLogger(type);
        }

        //public static void Error(object msg)
        //{
        //    log.Error(msg);
        //}

        //public static void Error(object msg, Exception ex)
        //{
        //    log.Error(msg, ex);
        //}

        //public static void Error(Exception ex)
        //{
        //    log.Error(ex.Message, ex);
        //}

        //public void Info(object msg)
        //{
        //    log.Info(msg);
        //}
    }
}
