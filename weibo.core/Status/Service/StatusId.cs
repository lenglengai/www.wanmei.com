using platform;

namespace weibo.core
{
    public class StatusId : IStream
    {
        public void _serialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mTableId, @"tableId");
            nSerialize._serialize(ref mStatusId, @"statusId");
            nSerialize._serialize(ref mTicks, @"ticks");
        }

        public long _getStatusId()
        {
            return mStatusId;
        }

        public long _getTicks()
        {
            return mTicks;
        }

        public uint _getTableId()
        {
            return mTableId;
        }

        public StatusId(uint nTableId, long nStatusId, long nTicks)
        {
            mStatusId = nStatusId;
            mTableId = nTableId;
            mTicks = nTicks;
        }

        public StatusId()
        {
            mTableId = 0;
            mStatusId = 0;
            mTicks = 0;
        }

        uint mTableId;
        long mStatusId;
        long mTicks;
    }
}
