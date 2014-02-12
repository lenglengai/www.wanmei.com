using System;
using System.Text;

using platform;
using account.core;

namespace weibo.core
{
    public class StatusMgrInsertB : ISqlHeadstream
    {
        public void _runSelect(ISqlCommand nSqlCommand)
        {
            nSqlCommand._serialize(ref mAccountId, @"accountId");
            nSqlCommand._serialize(ref mTicks, @"ticks");
            nSqlCommand._serialize(ref mBytes, @"statusIds");
        }

        public void _runWhere(ISqlCommand nSqlFormat)
        {
        }

        public string _tableName()
        {
            return string.Format(@"statusMgr_{0}", mAccountMgrId);
        }

        public SqlType_ _sqlType()
        {
            return SqlType_.mInsertUpdateEx_;
        }

        public StatusMgrInsertB(StatusMgr nStatusMgr)
        {
            Account account_ = nStatusMgr._getPropertyMgr<Account>();
            AccountMgr accountMgr_ = account_._getAccountMgr();
            mAccountMgrId = accountMgr_._getId();
            mAccountId = account_._getId();
            mTicks = account_._getTicks();
            mBytes = Encoding.UTF8.GetBytes(nStatusMgr._getStrStatusIds());
        }

        uint mAccountMgrId;
        uint mAccountId;
        long mTicks;
        byte[] mBytes;
    }
}
