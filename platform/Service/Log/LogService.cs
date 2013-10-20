using log4net;

namespace platform
{
    public class LogService
    {
        public void _logFatal(string nValue)
        {
            mLog.Fatal(nValue);
        }

        public void _logError(string nValue)
        {
            mLog.Error(nValue);
        }

        public void _logWarn(string nValue)
        {
            mLog.Warn(nValue);
        }

        public LogService()
        {
            mLog = LogManager.GetLogger("log");
        }

        ILog mLog = null;
    }
}
