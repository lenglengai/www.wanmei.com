using System;
using System.Collections.Generic;

using platform;
using account.core;

namespace weibo.core
{
    public class StatusService : PropertyId<StatusOption>
    {
        public StatusCreateC _createStatus(StatusCreateS nStatusCreateS)
        {
            StatusCreateC result_ = new StatusCreateC();
            result_.m_tId = nStatusCreateS.m_tId;
            AccountService accountService_ = __singleton<AccountService>._instance();
            Account account_ = accountService_._getAccount(nStatusCreateS.m_tAccount);
            if (null != account_)
            {
                uint propertyId_ = PropertyId<StatusMgr>._classId();
                StatusMgr statusMgr_ = account_._getProperty<StatusMgr>(propertyId_);
            }
            else
            {
                result_.m_tErrorCode = StatusError_.mAccount_;
            }
            return result_;
        }

        public StatusGetC _getStatus(StatusGetS nStatusGetS)
        {
            StatusGetC result_ = new StatusGetC();
            AccountService accountService_ = __singleton<AccountService>._instance();
            Account account_ = accountService_._getAccount(nStatusGetS.m_tAccountGet);
            if (null == account_)
            {
                result_.m_tErrorCode = StatusError_.mAccount_;
                return result_;
            }
            if ((nStatusGetS.m_tPlayer == nStatusGetS.m_tAccountGet.m_tName) || (null == nStatusGetS.m_tPlayer))
            {
                this._getStatus(result_, account_, nStatusGetS.m_tTicks);
            }
            else
            {
                this._getStatus(result_, nStatusGetS.m_tPlayer, nStatusGetS.m_tTicks, nStatusGetS.m_tServer);
            }
            return result_;
        }

        void _getStatus(StatusGetC nStatusGetC, Account nAccount, long nTicks)
        {
            AccountMgr accountMgr_ = nAccount._getAccountMgr();
            uint accountMgrId_ = accountMgr_._getId();
            uint accountId_ = nAccount._getId();
            uint propertyId_ = PropertyId<StatusMgr>._classId();
            StatusMgr statusMgr_ = nAccount._getProperty<StatusMgr>(propertyId_);
            if (statusMgr_._getTicks() == nTicks)
            {
                nStatusGetC.m_tErrorCode = StatusError_.mSucessTicks_;
                return;
            }
            statusMgr_._getStatus(nStatusGetC, nTicks, accountMgrId_, accountId_);
        }

        void _getStatus(StatusGetC nStatusGetC, string nAccountName, long nTicks, uint nServer)
        {
            SettingService settingService_ = __singleton<SettingService>._instance();
            if (!settingService_._checkServerId(nServer))
            {
                nStatusGetC.m_tErrorCode = StatusError_.mServerId_;
                return;
            }
            AccountService accountService_ = __singleton<AccountService>._instance();
            Account account_ = accountService_._getAccount(nAccountName);
            if (null != account_)
            {
                this._getStatus(nStatusGetC, account_, nTicks);
            }
            else
            {
                this._getStatus(nStatusGetC, nAccountName, nTicks);
            }
        }

        void _getStatus(StatusGetC nStatusGetC, string nAccountName, long nTicks)
        {
            AccountService accountService_ = __singleton<AccountService>._instance();
            uint accountMgrId_ = default(uint);
            uint accountId_ = default(uint);
            accountService_._getAccountInfo(out accountMgrId_, out accountId_, nAccountName);
            StatusMgr statusMgr_ = new StatusMgr();
            statusMgr_._runAccountLogin(accountMgrId_, accountId_);
            statusMgr_._getStatus(nStatusGetC, nTicks, accountMgrId_, accountId_);
        }

        public void _runInit()
        {
            InitService initService_ = __singleton<InitService>._instance();
            initService_.m_tRunSave += this._saveStatusOption;
        }

        public void _runStart()
        {
            this._startStatusOption();
        }

        void _startStatusOption()
        {
            SqlCommand sqlCommand_ = new SqlCommand();
            StatusOptionSelectB statusOptionSelectB_ = new StatusOptionSelectB();
            sqlCommand_._addHeadstream(statusOptionSelectB_);
            SqlService sqlService_ = __singleton<SqlService>._instance();
            if (sqlService_._runSqlCommand(sqlCommand_, statusOptionSelectB_))
            {
                statusOptionSelectB_._runInit();
            }
        }

        void _saveStatusOption()
        {
            SqlCommand sqlCommand_ = new SqlCommand();
            StatusOptionInsertB statusOptionInsertB_ = new StatusOptionInsertB();
            statusOptionInsertB_._runInit();
            sqlCommand_._addHeadstream(statusOptionInsertB_);
            SqlService sqlService_ = __singleton<SqlService>._instance();
            sqlService_._runSqlCommand(sqlCommand_);
        }
    }
}
