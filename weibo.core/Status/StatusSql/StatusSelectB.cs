using System;
using System.Collections.Generic;

using platform;
using account.core;

namespace weibo.core
{
    public class StatusSelectB : ISqlHeadstream
    {
        public void _runSelect(ISqlCommand nSqlCommand)
        {
            nSqlCommand._serialize(ref mStatusBs, @"statusBs");
        }

        public void _runWhere(ISqlCommand nSqlCommand)
        {
            nSqlCommand._serialize(ref mStatusIds, @"WHERE statusId in ");
            nSqlCommand._serialize(ref mAccountId, @"AND accountId=");
        }

        public string _tableName()
        {
            return string.Format(@"status_{0}_{1}", mAccountMgrId, mTableId);
        }

        public SqlType_ _sqlType()
        {
            return SqlType_.mSelect_;
        }

        public void _addStatusId(long nStatusId)
        {
            mStatusIds.Add(nStatusId);
        }

        public void _initStatusGetC(StatusGetC nStatusGetC)
        {
            foreach (StatusB i in mStatusBs)
            {
                StatusC statusC_ = i._getStatusC();
                nStatusGetC.m_tStatusCs.Add(statusC_);
            }
        }

        public StatusSelectB(uint nAccountMgrId, uint nTableId, uint nAccountId)
        {
            mStatusBs = new List<StatusB>();
            mStatusIds = new List<long>();
            mAccountMgrId = nAccountMgrId;
            mTableId = nTableId;
            mAccountId = nAccountId;
        }

        public StatusSelectB()
        {
            mStatusBs = new List<StatusB>();
            mStatusIds = new List<long>();
            mAccountMgrId = 0;
            mTableId = 0;
            mAccountId = 0;
        }

        List<StatusB> mStatusBs;
        List<long> mStatusIds;
        uint mAccountMgrId;
        uint mTableId;
        uint mAccountId;
    }
}
