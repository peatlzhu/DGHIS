using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NLog;

namespace DGHIS.Core.Helpers.LogHelper
{
     public class Logger
    { 
        NLog.Logger logger;

        private Logger(NLog.Logger log)
        {
            logger = log;
        }

        public Logger(string name) : this(LogManager.GetLogger(name))
        {

        }

        public static Logger Default { get; private set; }
        static Logger()
        {
            Default = new Logger(NLog.LogManager.LoadConfiguration("Nlog.config").GetCurrentClassLogger());
        }

        #region Debug

        public  void Debug(string msg, params object[] args)
        {
            logger.Debug(msg, args);
        }

        public  void Debug(string msg, Exception err)
        {
            logger.Debug(err, msg);
        }

        #endregion

        #region Info

        public  void Info(string msg, params object[] args)
        {
            logger.Info(msg, args);
        }

        public  void Info(string msg, Exception err)
        {
            logger.Info(err, msg);
        }

        #endregion

        #region Warn

        public  void Warn(string msg, params object[] args)
        {
            logger.Warn(msg, args);
        }

        public  void Warn(string msg, Exception err)
        {
            logger.Warn(err, msg);
        }

        #endregion

        #region Trace

        public  void Trace(string msg, params object[] args)
        {
            logger.Trace(msg, args);
        }

        public  void Trace(string msg, Exception err)
        {
            logger.Trace(err, msg);
        }

        #endregion

        #region Error

        public  void Error(string msg, params object[] args)
        {
            logger.Error(msg, args);
        }

        public  void Error(string msg, Exception err)
        {
            logger.Error(err, msg);
        }

        #endregion

        #region Fatal

        public  void Fatal(string msg, params object[] args)
        {
            logger.Fatal(msg, args);
        }

        public  void Fatal(string msg, Exception err)
        {
            logger.Fatal(err, msg);
        }

        #endregion


    }

}
