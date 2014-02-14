using System.Collections.Generic;

using platform;
using account.core;

namespace money.core
{
    public class MoneyService : IHeadstream
    {
        public void _headSerialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mMoneyConfig, @"moneys");
        }

        public string _streamName()
        {
            return @"moneyService"; 
        }

        public void _initMoneyMgr(MoneyMgr nMoneyMgr)
        {
            foreach (MoneyConfig i in mMoneyConfig)
            {
                Money money_ = new Money(i._getId());
                nMoneyMgr._addMoney(money_);
            }
        }

        public void _runInit()
        {
            this._initConfig();
            this._initProperty();
        }

        void _initConfig()
        {
            string accountConfigUrl_ = @"config/moneyConfig.xml";
            XmlReader xmlReader_ = new XmlReader();
            xmlReader_._openUrl(accountConfigUrl_);
            xmlReader_._selectStream(_streamName());
            this._headSerialize(xmlReader_);
            xmlReader_._runClose();
        }

        void _initProperty()
        {
            AccountCreator accountCreator_ = __singleton<AccountCreator>._instance();
            accountCreator_._registerCreate(new PropertyId<MoneyMgr>());
        }

        public MoneyService()
        {
            mMoneyConfig = new List<MoneyConfig>();
        }

        List<MoneyConfig> mMoneyConfig;
    }
}
