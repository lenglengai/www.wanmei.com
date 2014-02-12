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
        [HttpGet]
        public AccountError_ _createAccount(string nName, string nNick, string nPassward)
        {
            AccountService accountService_ = __singleton<AccountService>._instance();
            return accountService_._createAccount(nName, nNick, nPassward);
        }

        [HttpGet]
        public AccountLoginC _loginAccount(string nName, string nPassward, uint nDeviceType)
        {
            AccountService accountService_ = __singleton<AccountService>._instance();
            return accountService_._loginAccount(nName, nPassward, nDeviceType);
        }

        [HttpGet]
        public AccountError_ _logoutAccount(string nName, long nDeviceId, uint nDeviceType, uint nServerId)
        {
            AccountService accountService_ = __singleton<AccountService>._instance();
            return accountService_._logoutAccount(nName, nDeviceId, nDeviceType, nServerId);
        }
    }
}
