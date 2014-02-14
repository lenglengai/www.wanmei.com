using System;
using System.Text;
using System.Collections.Generic;

using platform;
using account.core;

namespace weibo.core
{
    public class StatusMgr : Property, IHeadstream
    {
        public void _headSerialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mStatusIds, @"statusIds");
        }

        public string _streamName()
        {
            return "statusMgr";
        }

        public void _createStatus(Account nAccount, StatusCreateS nStatusCreateS, StatusCreateC nStatusCreateC)
        {
            AccountMgr accountMgr_ = nAccount._getAccountMgr();
            uint statusServiceId_ = StatusService._classId();
            StatusOption statusOption_ = accountMgr_._getProperty<StatusOption>(statusServiceId_);
            uint tableId_ = statusOption_._getTableId();
            uint accountMgrId_ = accountMgr_._getId();
            SqlCommand sqlCommand_ = new SqlCommand();
            if (statusOption_._createTable())
            {
                tableId_ = statusOption_._generateTableId();
                StatusTableCreateB statusTableCreateB_ = new StatusTableCreateB(tableId_, accountMgrId_);
                sqlCommand_._addHeadstream(statusTableCreateB_);
            }
            StatusCreateB statusCreateB_ = new StatusCreateB(nAccount, tableId_, accountMgrId_, nStatusCreateS);
            sqlCommand_._addHeadstream(statusCreateB_);
            SqlService sqlService_ = __singleton<SqlService>._instance();
            if (sqlService_._runSqlCommand(sqlCommand_))
            {
                long statusId_ = statusCreateB_._statusId();
                mTicks = statusCreateB_._getTicks();
                nStatusCreateC.m_tErrorCode = StatusError_.mSucess_;
                nStatusCreateC.m_tStatusId = statusId_;
                nStatusCreateC.m_tTicks = mTicks;
                mStatusIds.Add(new StatusId(tableId_, statusId_, mTicks));
            }
            else
            {
                nStatusCreateC.m_tErrorCode = StatusError_.mSql_;
            }
        }

        public void _getStatus(StatusGetC nStatusGetC, long nTicks, uint nAccountMgrId, uint nAccountId)
        {
            SqlCommand sqlCommand_ = new SqlCommand();
            this._getStatusCommand(sqlCommand_, nTicks, nAccountMgrId, nAccountId);
            StatusSelectB statusSelectB_ = new StatusSelectB();
            SqlService sqlService_ = __singleton<SqlService>._instance();
            if (sqlService_._runSqlCommand(sqlCommand_, statusSelectB_))
            {
                statusSelectB_._initStatusGetC(nStatusGetC);
                nStatusGetC.m_tErrorCode = StatusError_.mSucess_;
            }
            else
            {
                nStatusGetC.m_tErrorCode = StatusError_.mSql_;
            }
            nStatusGetC.m_tTicks = mTicks;
        }

        void _getStatusCommand(SqlCommand nSqlCommand, long nTicks, uint nAccountMgrId, uint nAccountId)
        {
            int pos = 0;
            foreach (StatusId i in mStatusIds)
            {
                if (i._getTicks() > nTicks)
                {
                    break;
                }
                uint tableId_ = i._getTableId();
                long statusId_ = i._getStatusId();
                StatusSelectB statusSelectB_ = new StatusSelectB(nAccountMgrId, tableId_, nAccountId);
                statusSelectB_._addStatusId(statusId_);
                ++pos;
                if (pos > 5)
                {
                    break;
                }
            }
        }

        public string _getStrStatusIds()
        {
            string result_ = null;
            XmlWriter xmlWriter_ = new XmlWriter();
            xmlWriter_._openString(null);
            xmlWriter_._selectStream(this._streamName());
            this._headSerialize(xmlWriter_);
            result_ = xmlWriter_._getString();
            xmlWriter_._runClose();
            return result_;
        }

        public long _getTicks()
        {
            return mTicks;
        }

        public override void _runInit()
        {
            Account account_ = this._getPropertyMgr<Account>();
            account_.m_tRunLogin += _runAccountLogin;
            account_.m_tRunLogout += _runAccountLogout;
        }

        void _runAccountLogin()
        {
            Account account_ = this._getPropertyMgr<Account>();
            AccountMgr accountMgr_ = account_._getAccountMgr();
            uint accountMgrId_ = accountMgr_._getId();
            uint accountId_ = account_._getId();
            this._runAccountLogin(accountMgrId_, accountId_);
        }

        public void _runAccountLogin(uint nAccountMgrId, uint nAccountId)
        {
            SqlCommand sqlCommand_ = new SqlCommand();
            StatusMgrSelectB statusMgrSelectB_ = new StatusMgrSelectB(nAccountMgrId, nAccountId);
            sqlCommand_._addHeadstream(statusMgrSelectB_);
            SqlService sqlService_ = __singleton<SqlService>._instance();
            if (sqlService_._runSqlCommand(sqlCommand_, statusMgrSelectB_))
            {
                mTicks = statusMgrSelectB_._getTicks();
                string value_ = statusMgrSelectB_._getString();
                if (null != value_)
                {
                    this._initStatusIds(value_);
                }
            }
        }

        void _initStatusIds(string nValue)
        {
            XmlReader xmlReader_ = new XmlReader();
            xmlReader_._openString(nValue);
            xmlReader_._selectStream(this._streamName());
            this._headSerialize(xmlReader_);
            xmlReader_._runClose();
        }

        void _runAccountLogout()
        {
            SqlCommand sqlCommand_ = new SqlCommand();
            StatusMgrInsertB statusMgrInsertB_ = new StatusMgrInsertB(this);
            sqlCommand_._addHeadstream(statusMgrInsertB_);
            SqlService sqlService_ = __singleton<SqlService>._instance();
            sqlService_._runSqlCommand(sqlCommand_);
        }

        public StatusMgr()
        {
            mStatusIds = new List<StatusId>();
            mTicks = 0;
        }

        List<StatusId> mStatusIds;
        long mTicks;
    }
}
