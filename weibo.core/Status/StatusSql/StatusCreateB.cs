using System;

using platform;
using account.core;

namespace weibo.core
{
    public class StatusCreateB : ISqlHeadstream
    {
        public void _runSelect(ISqlCommand nSqlCommand)
        {
            nSqlCommand._serialize(ref mStatusId, @"statusId");
            nSqlCommand._serialize(ref mAccountId, @"accountId");
            nSqlCommand._serialize(ref mText, @"text");
            nSqlCommand._serialize(ref mType, @"type");
            nSqlCommand._serialize(ref mTicks, @"createTime");
            nSqlCommand._serialize(ref mAttachments, @"attachments");
        }

        public void _runWhere(ISqlCommand nSqlCommand)
        {
        }

        public string _tableName()
        {
            return string.Format(@"status_{0}_{1}", mAccountMgrId, mTableId);
        }

        public SqlType_ _sqlType()
        {
            return SqlType_.mInsert_;
        }

        public long _getTicks()
        {
            return mTicks;
        }

        public long _statusId()
        {
            return mStatusId;
        }

        public uint _tableId()
        {
            return mTableId;
        }

        public StatusCreateB(Account nAccount, uint nTableId, uint nAccountMgrId, StatusCreateS nStatusCreateS)
        {
            mAccountMgrId = nAccountMgrId;
            mTableId = nTableId;
            mAccountId = nAccount._getId();
            mText = nStatusCreateS.m_tText;
            mType = (uint)nStatusCreateS.m_tStatusType;
            mAttachments = nStatusCreateS.m_tAttachments;
            mTicks = DateTime.Now.Ticks;
            mStatusId = GenerateId._runId(mAccountId);
        }

        uint mAccountMgrId;
        uint mTableId;
        long mTicks;
        long mStatusId;
        uint mAccountId;
        string mText;
        uint mType;
        string mAttachments;
    }
}
