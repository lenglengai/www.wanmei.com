using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using platform;
using weibo.core;

namespace webstart.Controllers
{
    public class WeiboController : ApiController
    {
        [HttpPost]
        public StatusCreateC _createStatus(StatusCreateS nStatusCreateS)
        {
            StatusService statusService_ = __singleton<StatusService>._instance();
            return statusService_._createStatus(nStatusCreateS);
        }

        [HttpPost]
        public StatusGetC _getStatus(StatusGetS nStatusGetS)
        {
            StatusService statusService_ = __singleton<StatusService>._instance();
            return statusService_._getStatus(nStatusGetS);
        }
    }
}
