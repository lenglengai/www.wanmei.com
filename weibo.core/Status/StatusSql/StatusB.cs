using System;

using platform;
using account.core;

namespace weibo.core
{
    public class StatusB : ISqlStream
    {
        public void _runSelect(ISqlCommand nSqlCommand)
        {
            nSqlCommand._serialize(ref mStatusId, @"statusId");
            nSqlCommand._serialize(ref mText, @"text");
            nSqlCommand._serialize(ref mType, @"type");
            nSqlCommand._serialize(ref mTicks, @"createTime");
            nSqlCommand._serialize(ref mAttachments, @"attachments");
        }

        public void _runWhen(ISqlCommand nSqlCommand)
        {
        }

        public StatusC _getStatusC()
        {
            StatusC result_ = new StatusC();
            result_.m_tAttachments = mAttachments;
            result_.m_tText = mText;
            result_.m_tTicks = mTicks;
            result_.m_tType = (int)mType;
            result_.m_tStatusId = mStatusId;
            return result_;
        }

        public StatusB()
        {
            mStatusId = 0;
            mText = null;
            mType = (uint)StatusType_.mText_;
            mAttachments = null;
            mTicks = default(long);
        }
        string mAttachments;
        long mStatusId;
        long mTicks;
        string mText;
        uint mType;
    }
}
