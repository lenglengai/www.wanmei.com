using System;
using System.Collections.Generic;

using platform;
using account.core;

namespace weibo.core
{
    public class StatusTableCreateB : ISqlHeadstream
    {
        public void _runSelect(ISqlCommand nSqlCommand)
        {
            nSqlCommand._serialize(ref mStatusId, @"statusId", SqlFieldId_.mPrimary_ | SqlFieldId_.mNotNull_ | SqlFieldId_.mZeroFill_);
            nSqlCommand._serialize(ref mAccountId, @"accountId", SqlFieldId_.mNotNull_ | SqlFieldId_.mZeroFill_);
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
            return SqlType_.mCreate_;
        }

        public StatusTableCreateB(uint nTableId, uint nAccountMgrId)
        {
            mAccountMgrId = nAccountMgrId;
            mTableId = nTableId;
            mStatusId = 0;
            mAccountId = 0;
            mTicks = 0;
            mText = null;
            mType = (uint)StatusType_.mText_;
            mAttachments = null;
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
