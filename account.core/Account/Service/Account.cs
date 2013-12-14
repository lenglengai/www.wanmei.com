using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using platform;

namespace account.core
{
    public class Account : PropertyMgr
    {
        public int _checkErrorCode(long nDeviceId, uint nDeviceType) {
            int result_ = AccountError_.mSucess_;
            DeviceStatus deviceStatus_ = this._getDeviceStatus(nDeviceType);
            if (null == deviceStatus_) {
                result_ = AccountError_.mDeviceType_;
            }
            if ((null != deviceStatus_) && (deviceStatus_._getId() != nDeviceId)) {
                result_ = AccountError_.mDeviceId_;
            }
            return result_;
        }

        public int _logout(long nDeviceId, uint nDeviceType) {
            int result_ = AccountError_.mSucess_;
            DeviceStatus deviceStatus_ = this._getDeviceStatus(nDeviceType);
            if (null == deviceStatus_)
            {
                result_ = AccountError_.mDeviceType_;
            }
            if ((null != deviceStatus_) && (deviceStatus_._getId() != nDeviceId))
            {
                result_ = AccountError_.mDeviceId_;
            }
            if (AccountError_.mSucess_ == result_)
            {
                mDeviceStatus.Remove(nDeviceType);
            }
            return result_;
        }

        public bool _isOnline()
        {
            return (mDeviceStatus.Count > 0);
        }

        public void _addDeviceType(uint nDeviceType)
        {
            long id_ = GenerateId._runId(@"account");
            DeviceStatus deviceStatus_ = new DeviceStatus(id_, nDeviceType);
            mDeviceStatus[nDeviceType] = deviceStatus_;
        }

        public DeviceStatus _getDeviceStatus(uint nDeviceType)
        {
            DeviceStatus result_ = null;
            if (mDeviceStatus.ContainsKey(nDeviceType))
            {
                result_ = mDeviceStatus[nDeviceType];
            }
            return result_;
        }

        public void _setAccountMgr(AccountMgr nAccountMgr)
        {
            mAccountMgr = nAccountMgr;
        }

        public AccountMgr _getAccountMgr()
        {
            return mAccountMgr;
        }

        public void _setNick(string nNick)
        {
            mNick = nNick;
        }

        public string _getNick()
        {
            return mNick;
        }

        public void _setTicks(long nTicks)
        {
            mTicks = nTicks;
        }

        public long _getTicks()
        {
            return mTicks;
        }

        public void _setId(uint nId)
        {
            mId = nId;
        }

        public uint _getId()
        {
            return mId;
        }

        public _RunSlot m_tRunLogin;
        public _RunSlot m_tRunLogout;

        public Account(string nNick, AccountMgr nAccountMgr) {
            mDeviceStatus = new Dictionary<uint, DeviceStatus>();
            mAccountMgr = nAccountMgr;
            m_tRunLogin = null;
            m_tRunLogout = null;
            mNick = nNick;
            mId = 0;
            mTicks = 0;
        }

        Dictionary<uint, DeviceStatus> mDeviceStatus;
        AccountMgr mAccountMgr;
        string mNick;
        long mTicks;
        uint mId;
    }
}
