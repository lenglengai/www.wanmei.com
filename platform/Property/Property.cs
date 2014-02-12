namespace platform
{
    public class Property
    {
        public __t _getPropertyMgr<__t>() where __t : PropertyMgr
        {
            return mPropertyMgr as __t;
        }

        public void _setPropertyMgr(PropertyMgr nPropertyMgr)
        {
            mPropertyMgr = nPropertyMgr;
        }

        public virtual void _runInit()
        {
        }

        public virtual void _runStart()
        {
        }

        public Property()
        {
            mPropertyMgr = null;
        }

        PropertyMgr mPropertyMgr;
    }
}
