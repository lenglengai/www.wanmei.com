using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using platform;

namespace account.core
{
    public class AccountService : PropertySink, IHeadstream
    {
        public void _headSerialize(ISerialize nSerialize) {
            nSerialize._serialize(ref mAccountMgrCount, @"accountMgrCount");
        }

        public string _streamName() {
            return @"accountService";
        }

        public int _createAccount(int nPlatform, string nAccountName, 
            string nNickname, string nPassward, string nGetPassward) {
            uint hashName_ = GenerateId._runTableId(nAccountName);
            uint accountMgrIndex_ = hashName_ % mAccountMgrCount;
            AccountMgr accountMgr_ = mAccountMgrs[accountMgrIndex_];
            return accountMgr_._createAccount(nPlatform, nAccountName,
                nNickname, nPassward, nGetPassward);
        }

        public AccountLoginC _loginAccount(string nAccountName,
            string nPassward, uint nDeviceType) {
            uint hashName_ = GenerateId._runTableId(nAccountName);
            uint accountMgrIndex_ = hashName_ % mAccountMgrCount;
            AccountMgr accountMgr_ = mAccountMgrs[accountMgrIndex_];
            return accountMgr_._loginAccount(nAccountName,
                nPassward, nDeviceType);
        }

        public int _logoutAccount(int nPlatformId, string nAccountName,
            uint nStamp, uint nDeviceId, int nServerId) {
            int result_ = this._checkServerId(nServerId);
            if (AccountError_.mSucess_ == result_) {
                uint hashName_ = GenerateId._runTableId(nAccountName);
                uint accountMgrIndex_ = hashName_ % mAccountMgrCount;
                AccountMgr accountMgr_ = mAccountMgrs[accountMgrIndex_];
                result_ = accountMgr_._logoutAccount(nAccountName,
                    nStamp, nDeviceId);
            }
            return result_;
        }

        public void _getAccountInfo(out uint nAccountMgrId,
            out uint nAccountId, string nAccountName) {
            uint hashName_ = GenerateId._runTableId(nAccountName);
            nAccountMgrId = hashName_ % mAccountMgrCount;
            nAccountId = GenerateId._runNameId(nAccountName);
        }

        public Account _getAccount(AccountGet nAccountGet) {
            uint hashName_ = GenerateId._runTableId(nAccountGet.m_tName);
            uint accountMgrIndex_ = hashName_ % mAccountMgrCount;
            AccountMgr accountMgr_ = mAccountMgrs[accountMgrIndex_];
            return accountMgr_._getAccount(nAccountGet);
        }

        public Account _getAccount(string nAccountName) {
            uint hashName_ = GenerateId._runTableId(nAccountName);
            uint accountMgrIndex_ = hashName_ % mAccountMgrCount;
            AccountMgr accountMgr_ = mAccountMgrs[accountMgrIndex_];
            return accountMgr_._getAccount(nAccountName);
        }

        int _checkServerId(int nServerId) {
            int result_ = AccountError_.mSucess_;
            SettingService settingService_ = 
                __singleton<SettingService>._instance();
            if (!settingService_._checkServerId(nServerId)) {
                result_ = AccountError_.mServerId_;
            }
            return result_;
        }

        public void _runPreinit() {
            this._initConfig();
        }

        void _initConfig() {
            string accountConfigUrl_ = @"config/accountConfig.xml";
            XmlReader xmlReader_ = new XmlReader();
            xmlReader_._openUrl(accountConfigUrl_);
            xmlReader_._selectStream(_streamName());
            this._headSerialize(xmlReader_);
            xmlReader_._runClose();
        }

        public void _runInit() {
            this._initAccountMgr();
        }

        void _initAccountMgr(){
            for (uint i = 0; i < mAccountMgrCount; ++i) {
                AccountMgr accountMgr_ = new AccountMgr(i);
                this._runCreate(accountMgr_);
                mAccountMgrs[i] = accountMgr_;
            }
        }

        public IDictionary<uint, AccountMgr> _getAccountMgrs() {
            return mAccountMgrs;
        }

        public AccountService() {
            mAccountMgrs = new Dictionary<uint, AccountMgr>();
            mAccountMgrCount = 0;
        }

        Dictionary<uint, AccountMgr> mAccountMgrs;
        uint mAccountMgrCount;
    }
}
