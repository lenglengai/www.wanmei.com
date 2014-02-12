using account.core;

namespace weibo.core
{
    public class StatusCreateS
    {
        public AccountGet m_tAccount { get; set; }
        public uint m_tId { get; set; }
        public string m_tText { get; set; }
        public StatusType_ m_tStatusType { get; set; }
        public string m_tAttachments { get; set; }
    }
}
