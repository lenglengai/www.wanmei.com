using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace platform
{
    public class MessageService
    {
        public void _msgFatal(string nValue)
        {
            mMessage._msgFatal(nValue);
        }

        public void _msgError(string nValue)
        {
            mMessage._msgError(nValue);
        }

        public void _msgWarn(string nValue)
        {
            mMessage._msgWarn(nValue);
        }

        public void _msgInfo(string nValue)
        {
            mMessage._msgInfo(nValue);
        }

        public void _runInit()
        {
            mMessage = new WebMessage();
        }

        public MessageService()
        {
            mMessage = null;
        }

        IMessage mMessage;
    }
}
