using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace platform
{
    public struct PlatformError_ : StringError
    {
        public override string getNamespace()
        {
            return "platform";
        }
    }
}
