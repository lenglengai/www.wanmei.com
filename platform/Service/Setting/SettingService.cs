using System.IO;
using System.Reflection;

namespace platform
{
    public class SettingService
    {
        public bool _checkServerId(uint nServerId) {
            return (mServerId == nServerId);
        }

        public void _setServerId(uint nServerId) {
            mServerId = nServerId;
        }

        public uint _getServerId() {
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
        uint mServerId;
    }
}
