namespace platform
{
    public class InitService
    {
        public _RunSlot m_tRunInit;
        public _RunSlot m_tRunStart;
        public _RunSlot m_tRunExit;
        public _RunSlot m_tRunSave;

        public InitService()
        {
            m_tRunInit = null;
            m_tRunStart = null;
            m_tRunExit = null;
            m_tRunSave = null;
        }
    }
}
