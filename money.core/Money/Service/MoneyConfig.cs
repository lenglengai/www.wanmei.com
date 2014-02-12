using System.Collections.Generic;

using platform;

namespace money.core
{
    public class MoneyConfig : IStream
    {
        public void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mId, @"id");
        }

        public uint _getId()
        {
            return mId;
        }

        public MoneyConfig()
        {
            mId = 0;
        }

        uint mId;
    }
}
