using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace platform
{
    public interface IMessage
    {
        void _msgFatal(string nValue);

        void _msgError(string nValue);

        void _msgWarn(string nValue);

        void _msgInfo(string nValue);
    }
}
