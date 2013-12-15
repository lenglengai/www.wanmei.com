using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace platform
{
    public class MessageService
    {
        public void _msgFatal(string nType, string nValue) {
            mMessage._msgFatal(nType, nValue);
        }

        public void _msgError(string nType, string nValue) {
            mMessage._msgError(nType, nValue);
        }

        public void _msgWarn(string nType, string nValue) {
            mMessage._msgWarn(nType, nValue);
        }

        public void _msgInfo(string nType, string nValue) {
            mMessage._msgInfo(nType, nValue);
        }

        public void _runInit() {
            mMessage = new WebMessage();
        }

        public MessageService() {
            mMessage = null;
        }

        IMessage mMessage;
    }
}
