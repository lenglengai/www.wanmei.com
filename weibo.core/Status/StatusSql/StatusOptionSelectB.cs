using System;
using System.Collections.Generic;

using platform;
using account.core;

namespace weibo.core
{
    public class StatusOptionSelectB : ISqlHeadstream
    {
        public void _runSelect(ISqlCommand nSqlCommand)
        {
            nSqlCommand._serialize(ref mStatusOptionBs, @"statusOptionBs");
        }

        public void _runWhere(ISqlCommand nSqlCommand)
        {
        }

        public string _tableName()
        {
            return @"statusOption";
        }

        public SqlType_ _sqlType()
        {
            return SqlType_.mSelect_;
        }

        public void _runInit()
        {
            StatusService statusService_ = __singleton<StatusService>._instance();
            AccountService accountService_ = __singleton<AccountService>._instance();
            IDictionary<uint, AccountMgr> accountMgrs_ = accountService_._getAccountMgrs();
            foreach (StatusOptionB i in mStatusOptionBs)
            {
                uint accountMgrId_ = i._getAccountMgrId();
                if (accountMgrs_.ContainsKey(accountMgrId_))
                {
                    AccountMgr accountMgr_ = accountMgrs_[accountMgrId_];
                    StatusOption statusOption_ = accountMgr_._getProperty<StatusOption>(statusService_._getId());
                    statusOption_._setTableId(i._getTableId());
                }
                else
                {
                    LogSingleton logSingleton_ = __singleton<LogSingleton>._instance();
                    logSingleton_._logError(string.Format(@"StatusOptionSelectB _initStatusOption:{0}", accountMgrId_));
                }
            }
        }

        public StatusOptionSelectB()
        {
            mStatusOptionBs = new List<StatusOptionB>();
        }

        List<StatusOptionB> mStatusOptionBs;
    }
}
