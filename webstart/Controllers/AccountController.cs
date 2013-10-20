using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using account.core;

namespace webstart.Controllers
{
    public class AccountController : ApiController
    {
        [HttpGet]
        public AccountError _createAccount(string nName, string nNick, string nPassward)
        {
            return AccountError.mSucess_;
        }
    }
}
