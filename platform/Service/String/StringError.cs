using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace platform
{
    public abstract class StringError
    {
        public abstract string getNamespace();

        public uint getType() {
            return mType;
        }

        public StringError() {
            string namespace_ = getNamespace();
            mType = GenerateId._runCommon(namespace_);
        }
        uint mType;
    }
}
