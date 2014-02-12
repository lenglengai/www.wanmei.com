using System.Collections.Generic;

using platform;
using account.core;

namespace money.core
{
    public class MoneyMgr : Property
    {
        public Money _getMoney(uint nId)
        {
            Money result_ = null;
            if (mMoneys.ContainsKey(nId))
            {
                result_ = mMoneys[nId];
            }
            return result_;
        }

        public void _addMoney(Money nMoney)
        {
            uint id_ = nMoney._getId();
            if (mMoneys.ContainsKey(id_))
            {
                LogService logService_ = __singleton<LogService>._instance();
                logService_._logError(string.Format(@"MoneyMgr _addMoney ContainsKey {0}", id_));
                return;
            }
            mMoneys[nMoney._getId()] = nMoney;
        }

        public override void _runInit()
        {
            MoneyService moneyService_ = __singleton<MoneyService>._instance();
            moneyService_._initMoneyMgr(this);
        }

        public override void _runStart()
        {
            Account account_ = this._getPropertyMgr<Account>();
            AccountMgr accountMgr_ = account_._getAccountMgr();
            SqlCommand sqlCommand_ = new SqlCommand();
            MoneyLoadB moneyLoadB_ = new MoneyLoadB(accountMgr_._getId(), account_._getId());
            sqlCommand_._addHeadstream(moneyLoadB_);
            SqlService sqlService_ = __singleton<SqlService>._instance();
            if (sqlService_._runSqlCommand(sqlCommand_, moneyLoadB_))
            {
                moneyLoadB_._initMoneyMgr(this);
            }
        }

        public MoneyMgr()
        {
            mMoneys = new Dictionary<uint, Money>();
        }

        Dictionary<uint, Money> mMoneys;
    }
}
