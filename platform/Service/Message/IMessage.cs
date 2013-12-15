using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace platform
{
    public interface IMessage
    {
        void _msgFatal(string nType, string nValue);

        void _msgError(string nType, string nValue);

        void _msgWarn(string nType, string nValue);

        void _msgInfo(string nType, string nValue);
    }
}
