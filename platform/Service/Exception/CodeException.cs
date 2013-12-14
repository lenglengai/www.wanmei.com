using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace platform
{
    public class CodeException : Exception
    {
        public uint getErrorCode()
        {
            return mErrorCode;
        }

        public string getMessage()
        {
            return mMessage;
        }

        public CodeException(uint nErrorCode,
            string nMessage)
        {
            mErrorCode = nErrorCode;
            mMessage = nMessage;
        }

        uint mErrorCode;
        string mMessage;
    }
}
