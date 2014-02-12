using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using platform;

namespace money.core
{
    public class MoneyLoadB : ISqlHeadstream
    {
        public void _runSelect(ISqlCommand nSqlCommand)
        {
            nSqlCommand._serialize(ref mMoneyB, @"moneys");
        }

        public void _runWhere(ISqlCommand nSqlCommand)
        {
            nSqlCommand._serialize(ref mAccountId, @"WHERE accountId=");
        }

        public string _tableName()
        {
            return string.Format(@"money_{0}", mAccountMgrId);
        }

        public SqlType_ _sqlType()
        {
            return SqlType_.mSelect_;
        }

        public void _initMoneyMgr(MoneyMgr nMoneyMgr)
        {
            foreach (MoneyB i in mMoneyB)
            {
                i._initMoneyMgr(nMoneyMgr);
            }
        }

        public MoneyLoadB(uint nAccountMgrId, uint nAccountId)
        {
            mAccountMgrId = nAccountMgrId;
            mAccountId = nAccountId;
            mMoneyB = new List<MoneyB>();
        }

        List<MoneyB> mMoneyB;
        uint mAccountMgrId;
        uint mAccountId;
    }
}
