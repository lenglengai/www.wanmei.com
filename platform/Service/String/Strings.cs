using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace platform
{
    public class Strings : IStream
    {
        public void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mNo, @"No");
            nSerialize._serialize(ref mValue, @"value");
        }

        public uint getNo() {
            return mNo;
        }

        public string getValue() {
            return mValue;
        }

        public Strings() {
            mNo = 0;
            mValue = "";
        }

        uint mNo;
        string mValue;
    }
}
