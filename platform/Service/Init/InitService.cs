namespace platform
{
    public class InitService
    {
        public void _runPreinit() {
            DeviceService deviceService_ =
                __singleton<DeviceService>._instance();
            deviceService_._runPreinit();
            LogService loginService_ =
                __singleton<LogService>._instance();
            loginService_._runPreinit();
            SettingService settingService_ =
                __singleton<SettingService>._instance();
            settingService_._runPreinit();
            SqlService sqlService_ =
                __singleton<SqlService>._instance();
            sqlService_._runPreinit();
            StringService stringService_ =
                __singleton<StringService>._instance();
            stringService_._runPreinit();
        }

        public void _runInit() {

        }

        public _RunSlot m_tRunExit;
        public void _runExit() {
            this._runSave();
            if (null != m_tRunExit) {
                this.m_tRunExit();
            }
        }

        public _RunSlot m_tRunSave;
        public void _runSave() {
            if (null != m_tRunSave) {
                this.m_tRunSave();
            }
        }

        public InitService() {
            m_tRunExit = null;
            m_tRunSave = null;
        }
    }
}
