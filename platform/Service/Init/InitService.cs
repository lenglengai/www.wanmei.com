namespace platform
{
    public class InitService
    {
        public _RunSlot m_tRunExit;
        public void _runExit()
        {
            this._runSave();
            if (null != m_tRunExit)
            {
                this.m_tRunExit();
            }
        }

        public _RunSlot m_tRunSave;
        public void _runSave()
        {
            if (null != m_tRunSave)
            {
                this.m_tRunSave();
            }
        }

        public InitService()
        {
            m_tRunExit = null;
            m_tRunSave = null;
        }
    }
}
