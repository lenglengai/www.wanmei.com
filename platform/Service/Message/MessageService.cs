using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace platform
{
    public class MessageService
    {
        public void _msgFatal(string nType, string nValue) {
            StringService stringService =
                __singleton<StringService>._instance();
            string strings = 
                stringService.getString(nType, nValue);
            mMessage._msgFatal(strings);
        }

        public void _msgError(string nType, string nValue) {
            StringService stringService =
                __singleton<StringService>._instance();
            string strings =
                stringService.getString(nType, nValue);
            mMessage._msgError(strings);
        }

        public void _msgWarn(string nType, string nValue) {
            StringService stringService =
                __singleton<StringService>._instance();
            string strings =
                stringService.getString(nType, nValue);
            mMessage._msgWarn(strings);
        }

        public void _msgInfo(string nType, string nValue) {
            StringService stringService =
                __singleton<StringService>._instance();
            string strings =
                stringService.getString(nType, nValue);
            mMessage._msgInfo(strings);
        }

        public void _setRun(RunType_ nRunType) {
            mRunType = nRunType;
        }

        public bool _isRunning() {
            if (mRunType == RunType_.mRunning_) {
                return true;
            }
            return false;
        }

        public void _runPreinit() {
            mMessage = new MobileMessage();
        }

        public MessageService() {
            mMessage = null;
            mRunType = RunType_.mStop_;
        }

        IMessage mMessage;
        RunType_ mRunType;
    }
}
