using platform;

namespace weibo.core
{
    public class StatusOption : Property
    {
        public bool _createTable()
        {
            return ((mTableId % 10000) == 0);
        }

        public uint _tableId()
        {
            return (mTableId / 10000);
        }

        public void _setTableId(uint nTableId)
        {
            mTableId = nTableId;
        }

        public uint _generateTableId()
        {
            mTableId++;
            return mTableId;
        }

        public uint _getTableId()
        {
            return mTableId;
        }

        public StatusOption()
        {
            mTableId = 0;
        }

        uint mTableId;
    }
}
