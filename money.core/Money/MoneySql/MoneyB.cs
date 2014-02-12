using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using platform;

namespace money.core
{
    public class MoneyB : ISqlStream
    {
        public void _runSelect(ISqlCommand nSqlCommand)
        {
            nSqlCommand._serialize(ref mId, @"id");
            nSqlCommand._serialize(ref mValue, @"value");
            nSqlCommand._serialize(ref mTotal, @"total");
            nSqlCommand._serialize(ref mDayInc, @"dayInc");
            nSqlCommand._serialize(ref mDayDec, @"dayDec");
            nSqlCommand._serialize(ref mMaxInc, @"maxInc");
            nSqlCommand._serialize(ref mMaxDec, @"maxDec");
            nSqlCommand._serialize(ref mDebts, @"debts");
        }

        public void _runWhen(ISqlCommand nSqlCommand)
        {
        }

        public void _initMoneyMgr(MoneyMgr nMoneyMgr)
        {
            Money money_ = nMoneyMgr._getMoney(mId);
            if (null == money_)
            {
                LogService logService_ = __singleton<LogService>._instance();
                logService_._logError(string.Format(@"MoneyB _initMoneyMgr _getMoney:{0}", mId));
                return;
            }
            money_._setValue(mValue);
            money_._setTotal(mTotal);
            money_._setDayInc(mDayInc);
            money_._setDayDec(mDayDec);
            money_._setMaxDec(mMaxDec);
            money_._setMaxInc(mMaxInc);
            money_._setDebts(mDebts);
        }

        public MoneyB()
        {
            mId = 0;
            mValue = 0;
            mTotal = 0;
            mDayInc = 0;
            mDayDec = 0;
            mMaxInc = 0;
            mMaxDec = 0;
            mDebts = 0;
        }

        uint mId;
        uint mValue;
        uint mTotal;
        uint mDayInc;
        uint mDayDec;
        uint mMaxInc;
        uint mMaxDec;
        uint mDebts;
    }
}
