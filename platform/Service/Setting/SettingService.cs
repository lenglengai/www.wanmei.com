using System.IO;
using System.Reflection;

namespace platform
{
    public class SettingService
    {
        public bool _checkServerId(int nServerId) {
            return (mServerId == nServerId);
        }

        public void _setServerId(int nServerId) {
            mServerId = nServerId;
        }

        public int _getServerId() {
            return mServerId;
        }

        public void _runPreinit(string nPath = null) {
            mSystemPath = Path.Combine(nPath, @"bin");
        }

        public string _systemPath() {
            return mSystemPath;
        }

        public SettingService() {
            mSystemPath = null;
            mServerId = 0;
        }

        string mSystemPath;
        int mServerId;
    }
}
