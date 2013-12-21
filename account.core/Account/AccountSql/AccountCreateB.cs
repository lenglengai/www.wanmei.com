using System;

using platform;

namespace account.core
{
    public class AccountCreateB : ISqlHeadstream
    {
        public void _runSelect(ISqlCommand nSqlCommand) {
            nSqlCommand._serialize(ref mAccountId, @"accountId");
            nSqlCommand._serialize(ref mPlatform, @"platformId");
            nSqlCommand._serialize(ref mAccountName, @"accountName");
            nSqlCommand._serialize(ref mNickName, @"nickName");
            nSqlCommand._serialize(ref mPassward, @"passward");
            nSqlCommand._serialize(ref mGetPassward, @"getPassward");
            nSqlCommand._serialize(ref mTicks, @"createTime");
        }

        public void _runWhere(ISqlCommand nSqlCommand) {
        }

        public string _tableName() {
            return ("account_" + mAccountMgrId);
        }

        public SqlType_ _sqlType() {
            return SqlType_.mInsert_;
        }

        public AccountCreateB(int nPlatform, string nAccountName, string nNickname, 
            string nPassward, string nGetPassward, uint nAccountMgrId) {
            mAccountId = GenerateId._runNameId(nAccountName);
            mPlatform = nPlatform;
            mAccountName = nAccountName;
            mAccountMgrId = nAccountMgrId;
            mNickName = nNickname;
            mPassward = nPassward;
            mGetPassward = nGetPassward;
            mTicks = DateTime.Now.Ticks;
        }

        uint mAccountId;
        int mPlatform;
        string mAccountName;
        string mNickName;
        string mPassward;
        string mGetPassward;
        long mTicks;
        uint mAccountMgrId;
    }
}
