using System;
using NLog;
namespace DAL
{
  public  class clsLogger
    {
        private static readonly Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static void ErrorLog(string Message , Exception ex)
        {
            logger.Error(ex,Message + " - ");
        }


        public static void Info(string Message)
        {
            logger.Info(Message);
        }
    }
}
