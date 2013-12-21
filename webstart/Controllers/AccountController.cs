using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using platform;
using account.core;

namespace webstart.Controllers
{
    public class AccountController : ApiController
    {
        [HttpPost]
        public int _createAccount(AccountCreateS nAccountCreateS) {
            AccountService accountService_ = __singleton<AccountService>._instance();
            return accountService_._createAccount(nAccountCreateS.m_tPlatform, nAccountCreateS.m_tName, 
                nAccountCreateS.m_tNick, nAccountCreateS.m_tPassward, nAccountCreateS.m_tGetPassward);
        }

        [HttpPost]
        public AccountLoginC _loginAccount(AccountLoginS nAccountLoginS) {
            AccountService accountService_ = __singleton<AccountService>._instance();
            return accountService_._loginAccount(nAccountLoginS.m_tName,
                nAccountLoginS.m_tPassward, (uint)(nAccountLoginS.m_tDeviceType));
        }

        [HttpPost]
        public int _logoutAccount(AccountLogoutS nAccountLogoutS) {
            AccountService accountService_ = __singleton<AccountService>._instance();
            return accountService_._logoutAccount(nAccountLogoutS.m_tPlatform, nAccountLogoutS.m_tName, 
                (uint)(nAccountLogoutS.m_tStamp),  (uint)(nAccountLogoutS.m_tDeviceId), nAccountLogoutS.m_tServerId);
        }
    }
}
