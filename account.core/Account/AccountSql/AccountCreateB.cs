using System;

using platform;

namespace account.core
{
    public class AccountCreateB : ISqlHeadstream
    {
        public void _runSelect(ISqlCommand nSqlCommand)
        {
            nSqlCommand._serialize(ref mAccountId, @"accountId");
            nSqlCommand._serialize(ref mApplicationId, @"applicationId");
            nSqlCommand._serialize(ref mAccountName, @"accountName");
            nSqlCommand._serialize(ref mNickName, @"nickName");
            nSqlCommand._serialize(ref mPassward, @"passward");
            nSqlCommand._serialize(ref mTicks, @"createTime");
            nSqlCommand._serialize(ref mClusterID, @"clusterID");
            nSqlCommand._serialize(ref mServerID, @"serverID");
            nSqlCommand._serialize(ref mDatabaseId, @"databaseId");
            nSqlCommand._serialize(ref mTableId, @"tableId");
        }

        public void _runWhere(ISqlCommand nSqlCommand)
        {
        }

        public string _tableName()
        {
            return ("account_" + mAccountMgrId);
        }

        public SqlType_ _sqlType()
        {
            return SqlType_.mInsert_;
        }

        public AccountCreateB(string nAccountName, string nNickname, string nPassward, uint nAccountMgrId)
        {
            mApplicationId = 0;
            mAccountId = GenerateId._runNameId(nAccountName);
            mClusterID = GenerateId._runClusterID(nAccountName);
            mServerID = GenerateId._runServerID(nAccountName);
            mDatabaseId = GenerateId._runDatabaseId(nAccountName);
            mTableId = GenerateId._runTableId(nAccountName);
            mAccountName = nAccountName;
            mAccountMgrId = nAccountMgrId;
            mNickName = nNickname;
            mPassward = nPassward;
            mTicks = DateTime.Now.Ticks;
        }

        uint mAccountId;
        uint mApplicationId;
        string mAccountName;
        string mNickName;
        string mPassward;
        long mTicks;
        uint mClusterID;
        uint mServerID;
        uint mDatabaseId;
        uint mTableId;
        uint mAccountMgrId;
    }
}
