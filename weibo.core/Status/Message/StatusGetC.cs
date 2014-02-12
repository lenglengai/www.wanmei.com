using System.Collections.Generic;

namespace weibo.core
{
    public class StatusGetC
    {
        public StatusError_ m_tErrorCode { get; set; }
        public long m_tTicks { get; set; }
        public List<StatusC> m_tStatusCs { get; set; }
    }
}
