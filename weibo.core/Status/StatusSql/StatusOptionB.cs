using platform;

namespace weibo.core
{
    public class StatusOptionB : ISqlStream
    {
        public void _runSelect(ISqlCommand nSqlCommand)
        {
            nSqlCommand._serialize(ref mAccountMgrId, @"accountMgrId");
            nSqlCommand._serialize(ref mTableId, @"tableId");
        }

        public void _runWhen(ISqlCommand nSqlCommand)
        {
        }

        public uint _getAccountMgrId()
        {
            return mAccountMgrId;
        }

        public uint _getTableId()
        {
            return mTableId;
        }

        public StatusOptionB(uint nAccountMgrId, StatusOption nStatusOption)
        {
            mTableId = nStatusOption._getTableId();
            mAccountMgrId = nAccountMgrId;
        }

        public StatusOptionB()
        {
            mAccountMgrId = 0;
            mTableId = 0;
        }

        uint mAccountMgrId;
        uint mTableId;
    }
}
