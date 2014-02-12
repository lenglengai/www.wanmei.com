using System;
using System.Text;

using platform;
using account.core;

namespace weibo.core
{
    public class StatusMgrSelectB : ISqlHeadstream
    {
        public void _runSelect(ISqlCommand nSqlCommand)
        {
            nSqlCommand._serialize(ref mTicks, @"ticks");
            nSqlCommand._serialize(ref mBytes, @"statusIds");
        }

        public void _runWhere(ISqlCommand nSqlCommand)
        {
            nSqlCommand._serialize(ref mAccountId, @"WHERE accountId=");
        }

        public string _tableName()
        {
            return string.Format(@"statusMgr_{0}", mAccountMgrId);
        }

        public SqlType_ _sqlType()
        {
            return SqlType_.mSelect_;
        }

        public long _getTicks()
        {
            return mTicks;
        }

        public string _getString()
        {
            string result_ = null;
            if (null != mBytes)
            {
                result_ = Encoding.UTF8.GetString(mBytes);
            }
            return result_;
        }

        public StatusMgrSelectB(uint nAccountMgrId, uint nAccountId)
        {
            mAccountMgrId = nAccountMgrId;
            mAccountId = nAccountId;
            mTicks = 0;
            mBytes = null;
        }

        uint mAccountMgrId;
        uint mAccountId;
        long mTicks;
        byte[] mBytes;
    }
}
