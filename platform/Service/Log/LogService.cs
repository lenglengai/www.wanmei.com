using log4net;
using log4net.Config;

namespace platform
{
    public class LogService
    {
        public void _logFatal(string nValue) {
            mLog.Fatal(nValue);
        }

        public void _logError(string nValue) {
            mLog.Error(nValue);
        }

        public void _logWarn(string nValue) {
            mLog.Warn(nValue);
        }

        public void _runPreinit() {
            mLog = LogManager.GetLogger("log");
        }

        public LogService() {
            mLog = null;
        }

        ILog mLog;
    }
}
