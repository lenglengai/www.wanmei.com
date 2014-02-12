using System;

using platform;

namespace account.core
{
    public class AccountLoginB : ISqlHeadstream
    {
        public void _runSelect(ISqlCommand nSqlCommand)
        {
            nSqlCommand._serialize(ref mNickName, @"nickName");
            nSqlCommand._serialize(ref mPassward, @"passward");
            nSqlCommand._serialize(ref mTicks, @"createTime");
        }

        public void _runWhere(ISqlCommand nSqlCommand)
        {
            nSqlCommand._serialize(ref mAccountId, @"WHERE accountId = ");
        }

        public AccountError_ _checkPassward(string nPassward)
        {
            AccountError_ result_ = AccountError_.mSucess_;
            if ( (null == nPassward) || (null == mNickName) || (0 == mTicks) )
            {
                result_ = AccountError_.mNoAccount_;
            }
            if (AccountError_.mSucess_ == result_)
            {
                uint loginPassward_ = GenerateId._runPasswardId(nPassward);
                uint hashPassward_ = GenerateId._runPasswardId(mPassward);
                if (loginPassward_ != hashPassward_)
                {
                    result_ = AccountError_.mPassward_;
                }
            }
            return result_;
        }

        public string _tableName()
        {
            return ("account_" + mAccountMgrId);
        }

        public SqlType_ _sqlType()
        {
            return SqlType_.mSelect_;
        }

        public Account _createAccount()
        {
            Account result_ = new Account();
            result_._setId(mAccountId);
            result_._setNick(mNickName);
            result_._setTicks(DateTime.Now.Ticks);
            AccountCreator accountCreator_ = __singleton<AccountCreator>._instance();
            accountCreator_._runCreate(result_);
            return result_;
        }

        public uint _getAccountId()
        {
            return mAccountId;
        }

        public string _getNick()
        {
            return mNickName;
        }

        public long _getTicks()
        {
            return mTicks;
        }

        public AccountLoginB(string nAccountName, uint nAccountMgrId)
        {
            mAccountId = GenerateId._runNameId(nAccountName);
            mAccountName = nAccountName;
            mAccountMgrId = nAccountMgrId;
        }

        uint mAccountId;
        string mAccountName;
        string mNickName;
        string mPassward;
        long mTicks;
        uint mAccountMgrId;
    }
}
