using platform;

namespace account.core
{
    public class AccountLoginC
    {
        public AccountError_ m_tErrorCode { get; set; }
        public uint m_tAccountId { get; set; }
        public string m_tNickName { get; set; }
        public uint m_tServerId { get; set; }
        public long m_tTicks { get; set; }
        public long m_tDeviceId { get; set; }
        public uint m_tDeviceType { get; set; }
    }
}
